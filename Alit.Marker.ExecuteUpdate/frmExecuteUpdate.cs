using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alit.Marker.Model;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Alit.Marker.Model.Template;
using Alit.Marker.DBO;

namespace Alit.Marker.ExecuteUpdate
{
    public partial class frmExecuteUpdate : Alit.Marker.WinForm.Template.frmNormalTemplate
    {
        HttpClient client;
        Model.Settings.ApplicationSettings.ApplicationSettingsViewModel ApplicationSetting;
        Service.Update.Model.SoftwareVersionViewModel LatestSoftwareVersion;
        DAL.Settings.ApplicationSettings.SettingsDAL SettingDALObj;
        string UpdatingDatabaseName;
        public frmExecuteUpdate()
        {
            InitializeComponent();
            client = new HttpClient();
            SettingDALObj = new DAL.Settings.ApplicationSettings.SettingsDAL();
        }

        protected override void OnLoadFormValues()
        {
            using (dbMarkerEntities db = new dbMarkerEntities())
            {
                var cn = db.Database.Connection.ConnectionString.Split(';');
                if(cn.Length > 0)
                {
                    UpdatingDatabaseName = cn[0].Replace("data source=","");
                }
            }
            base.OnLoadFormValues();
        }
        protected override void OnAssignFormValues()
        {
            txtUpdatingDatabaseName.Text = UpdatingDatabaseName;
            base.btnSave.PerformClick();
            base.OnAssignFormValues();
        }

        string RarPath = null;
        string UnRarPath = null;
        string LogDirectory = null;
        string DatabaseUpdateLogFileName = null;
        string DatabaseUpdateLogFilePath = null;
        StreamWriter DatabaseUpdateLogFile = null;

        protected override async void OnAfterSaving(Model.Template.SavingParemeter Paras)
        {
            bool RestartUpdateApplication = false;
            /// Creating log file
            LogDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\Logs\\UpdateLog\\");
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
            DatabaseUpdateLogFileName = "UpdateLog_" + DateTime.Now.ToString("yyyyMMddHHmmtt") + ".txt";
            DatabaseUpdateLogFilePath = LogDirectory + DatabaseUpdateLogFileName;

            int LogFileCreateTry = 0;
            while (LogFileCreateTry < 5)
            {
                try
                {
                    DatabaseUpdateLogFile = File.CreateText(DatabaseUpdateLogFilePath);//, FileMode.OpenOrCreate);
                    break;
                }
                catch (Exception ex)
                {
                    DAL.CommonFunctions.GetFinalError(ex);
                    WriteToFile(DatabaseUpdateLogFile, $"Error creating log file {DatabaseUpdateLogFilePath}. Error : {ex.Message}");
                    DatabaseUpdateLogFileName = DatabaseUpdateLogFileName + "_Try_" + ((LogFileCreateTry + 1).ToString());
                    DatabaseUpdateLogFilePath = LogDirectory + DatabaseUpdateLogFileName;
                }
            }
            if (DatabaseUpdateLogFile == null)
            {
                txtStatus.Text = "Update Aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Can not create update log file. Log file is already in use or lack of permissions.");
                MessageBox.Show("Update aborted. Can not create update log file. Log file is already in use or lack of permissions. Please try after 5 minutes.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Finalizer;
            }

            WriteToFile(DatabaseUpdateLogFile, "Update started. Application directory : " + Application.StartupPath);
            WriteToFile(DatabaseUpdateLogFile, "Detecting current version.");

            ApplicationSetting = SettingDALObj.GetSetting();
            txtCurrentVersion.Text = ApplicationSetting.GUIVersionMajor.ToString() + "." + ApplicationSetting.GUIVersionMinor.ToString();

            WriteToFile(DatabaseUpdateLogFile, "Current version : " + txtCurrentVersion.Text);
            WriteToFile(DatabaseUpdateLogFile, "Detecting Latest version.");
            //--

            try
            {
                var response = await client.GetAsync(CommonProperties.CheckUpdateAPIBaseAddress + CommonProperties.GetLatestVersionNumberAPIAddress);
                if (response.IsSuccessStatusCode)
                {
                    Service.Update.Model.PostResultViewModel<Service.Update.Model.SoftwareVersionViewModel> resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<Service.Update.Model.SoftwareVersionViewModel>>();
                    if (resultModel != null && resultModel.ResultObject != null)
                    {
                        LatestSoftwareVersion = resultModel.ResultObject;
                        WriteToFile(DatabaseUpdateLogFile, "Latest version : " + LatestSoftwareVersion.MajorVersion.ToString() + "." + LatestSoftwareVersion.MinorVersion.ToString());
                    }
                    else
                    {
                        var ErrMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

                        txtStatus.Text = "Update aborted.";
                        pictureEdit1.Image = Properties.Resources.Close_Window_32;
                        WriteToFile(DatabaseUpdateLogFile, "Unable to get Version details. Following error recieved. " + ErrMsg);
                        MessageBox.Show("Update aborted. Unable to get version detail. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        goto Finalizer;
                    }
                }
            }
            catch(System.Net.Http.HttpRequestException ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error occured while trying to download latest version information. Error : " + ex.Message);
                MessageBox.Show("Update aborted. Error occured while trying to fetch latest version detail. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }
            //--

            if (LatestSoftwareVersion != null)
            {
                txtVersionNumber.Text = LatestSoftwareVersion.MajorVersion.ToString() + "." + LatestSoftwareVersion.MinorVersion.ToString();
            }
            else
            {
                txtVersionNumber.Text = "No data fetched.";
            }

            if (ApplicationSetting.GUIVersionMajor >= LatestSoftwareVersion.MajorVersion && ApplicationSetting.GUIVersionMinor >= LatestSoftwareVersion.MinorVersion)
            {
                txtStatus.Text = "Software is already updated to latest version.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "No update found. Update aborted.");
                MessageBox.Show("Software is already updated to latest version.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto Finalizer;
            }


            var AlitPocesses = System.Diagnostics.Process.GetProcessesByName("Alit.Marker.WinForm");
            if(AlitPocesses.Count() > 0)
            {
                if(MessageBox.Show("Software is in use, do you want to close it ? Make sure software must be close on all work station on network also. Otherwise update can not be executed successfully. Do you want to close application ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    foreach(var p in AlitPocesses)
                    {
                        p.CloseMainWindow();
                        if (!p.WaitForExit(3000))
                        {
                            p.Kill();
                        }
                    }
                }
                else
                {
                    txtStatus.Text = "Update aborted.";
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, "Application was is in use. User chose no to close application.");
                    MessageBox.Show("Application was is in use and unable to close application.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Finalizer;
                }
            }


            txtStatus.Text = "Update process is going on, please wait...";
            Application.DoEvents();

            WriteToFile(DatabaseUpdateLogFile, $"checking for rar.exe");

            if (!System.IO.File.Exists(RarPath))
            {
                RarPath = Application.StartupPath + @"\Rar.exe";
                WriteToFile(DatabaseUpdateLogFile, $"Rar.exe is not found. Extracting {RarPath}");
                try
                {
                    ExtractResource("Alit.Marker.ExecuteUpdate.Resources.Rar.exe", RarPath);
                    WriteToFile(DatabaseUpdateLogFile, "Rar.exe is extracted successfully.");
                }
                catch (Exception ex)
                {
                    DAL.CommonFunctions.GetFinalError(ex);
                    WriteToFile(DatabaseUpdateLogFile, "Error in extracting Rar.exe : " + ex.Message);
                }
            }

            UnRarPath = Application.StartupPath + @"\UnRAR.exe";
            WriteToFile(DatabaseUpdateLogFile, $"checking for UnRAR.exe");

            if (!System.IO.File.Exists(UnRarPath))
            {
                WriteToFile(DatabaseUpdateLogFile, $"UnRAR.exe is not found. Extracting {UnRarPath}");
                try
                {
                    ExtractResource("Alit.Marker.ExecuteUpdate.Resources.UnRAR.exe", UnRarPath);
                    WriteToFile(DatabaseUpdateLogFile, "UnRAR.exe is extracted successfully.");
                }
                catch (Exception ex)
                {
                    DAL.CommonFunctions.GetFinalError(ex);
                    WriteToFile(DatabaseUpdateLogFile, "Error in extracting UnRAR.exe : " + ex.Message);
                }
            }

            if (!System.IO.File.Exists(RarPath) || !System.IO.File.Exists(UnRarPath))
            {
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Update aborted.");
                MessageBox.Show("WinRAR is not found on the disk, thus software is unable to take automatic backup, please take a manual backup before click ok button.\r\nNote:We are not responsible any data loss after update, thus backup is required at your end.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            string BackupFolderPath = Path.GetFullPath(Application.StartupPath + @"\..\Backup");
            WriteToFile(DatabaseUpdateLogFile, "Creating backup directory.");
            if (!System.IO.Directory.Exists(BackupFolderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(BackupFolderPath);
                    WriteToFile(DatabaseUpdateLogFile, "Backup directory created " + BackupFolderPath);
                }
                catch (Exception ex)
                {
                    DAL.CommonFunctions.GetFinalError(ex);
                    txtStatus.Text = "Update aborted.";
                    WriteToFile(DatabaseUpdateLogFile, "Error in creating backup directory : " + ex.Message);
                    WriteToFile(DatabaseUpdateLogFile, "Update aborted.");
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    MessageBox.Show("Update aborted. Backup directory was not created. Possibly permission issue causing this problem. Please contact your system admin and software provider.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }
            }

            string BackupRARFileName = $@"{BackupFolderPath}\BackupMarker{txtCurrentVersion.Text}_" + DateTime.Now.ToString("yyyyMMdd_hhmmtt") + ".rar";
            string DirectoryToCompress = Path.GetFullPath(Application.StartupPath + "\\..\\");
            WriteToFile(DatabaseUpdateLogFile, "Making compressed file of directory " +  DirectoryToCompress + " ~~~ To ~~~ "+ BackupRARFileName);
            try
            {
                CompressFolderIntoRAR(BackupRARFileName, DirectoryToCompress, RarPath, BackupFolderPath);
                WriteToFile(DatabaseUpdateLogFile, "Backup File created.");
            }
            catch (Exception ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error in creating backup file : " + ex.Message);
                WriteToFile(DatabaseUpdateLogFile, "Update aborted.");
                MessageBox.Show("Update aborted. Unable to create backup file. Possibly permission issue causing this problem. Please contact your system admin and software provider.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            // Update procedure

            // Getting FTP Details 
            WriteToFile(DatabaseUpdateLogFile, "Fetching FTP details");
            string[] FTPAddress = null;
            try
            {
                var response = await client.GetAsync(CommonProperties.CheckUpdateAPIBaseAddress + CommonProperties.GetFTPAddress);
                if (response.IsSuccessStatusCode)
                {
                    Service.Update.Model.PostResultViewModel<string[]> resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<string[]>>();
                    if (resultModel != null && resultModel.ResultObject != null)
                    {
                        FTPAddress = resultModel.ResultObject;
                    }
                }
                else
                {
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

                    txtStatus.Text = "Update aborted.";
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, "Unable to get FTP details. Following error recieved. " + ErrMsg);
                    MessageBox.Show("Update aborted. Error occured while trying to contact server. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error occured while trying to get ftp details. Error : " + ex.Message);
                MessageBox.Show("Update aborted. Error occured while trying to contact server. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            if (FTPAddress == null || FTPAddress.Count() < 3)
            {
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                Application.DoEvents();
                MessageBox.Show("Can not update. Unable to contact server, please check update log and provide details to your provider.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                goto Finalizer;
            }

            //while (1 == 1)
            //{
            //    Application.DoEvents();
            //}
            
            // Getting version numbers
            WriteToFile(DatabaseUpdateLogFile, "Fetching next versions.");
            List<Service.Update.Model.SoftwareVersionViewModel> NextVersion = null;
            try
            {
                var response = await client.GetAsync(CommonProperties.CheckUpdateAPIBaseAddress + CommonProperties.GetNextVersions +
                    $"?MajorVersion={ApplicationSetting.GUIVersionMajor.ToString()}&MinorVersion={ApplicationSetting.GUIVersionMinor.ToString()}");
                if (response.IsSuccessStatusCode)
                {
                    Service.Update.Model.PostResultViewModel<List<Service.Update.Model.SoftwareVersionViewModel>> resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<List<Service.Update.Model.SoftwareVersionViewModel>>>();
                    if (resultModel != null && resultModel.ResultObject != null)
                    {
                        NextVersion = resultModel.ResultObject;

                        string rfv = "";
                        foreach (var r in NextVersion)
                        {
                            rfv += r.MajorVersion + "." + r.MajorVersion + ", ";
                        }
                        if (rfv != "")
                        {
                            WriteToFile(DatabaseUpdateLogFile, "Version to be updated are " + rfv.Substring(0, rfv.Length - 2));
                        }
                    }
                }
                else
                {
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

                    txtStatus.Text = "Update aborted.";
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, "Unable to get next versions. Following error recieved. " + ErrMsg);
                    MessageBox.Show("Update aborted. Unable to get next version. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error occured while trying to download next version information. Error : " + ex.Message);
                MessageBox.Show("Update aborted. Error occured while trying to fetch next version detail. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            // Creating temp directory
            string tempFolder = Path.GetFullPath(Path.GetTempPath() + @"\Marker\Update\");
            WriteToFile(DatabaseUpdateLogFile, "Creating temporary directory " + tempFolder);

            try
            {
                Directory.CreateDirectory(tempFolder);
            }
            catch(Exception ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error creating temporary directory " + tempFolder + ". Check following error " + ex.Message);
                MessageBox.Show("Can not update. Unable to create temporary directories. Possibly permission issue causing this problem. Please contact your system admin and software provider.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            // Downloading update scripts for next versions.
            WriteToFile(DatabaseUpdateLogFile, "Downloading database update scripts.");
            List<Service.Update.Model.DatabaseUpdateScriptViewModel> dbUpdateScripts = null;
            try
            {
                var response = await client.GetAsync(CommonProperties.CheckUpdateAPIBaseAddress + CommonProperties.GetDatabaseUpdateScript +
                    $"?MajorVersion={ApplicationSetting.GUIVersionMajor.ToString()}&MinorVersion={ApplicationSetting.GUIVersionMinor.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    Service.Update.Model.PostResultViewModel<List<Service.Update.Model.DatabaseUpdateScriptViewModel>> resultModel = await response.Content.ReadAsAsync<Service.Update.Model.PostResultViewModel<List<Service.Update.Model.DatabaseUpdateScriptViewModel>>>();
                    if (resultModel != null && resultModel.ResultObject != null)
                    {
                        dbUpdateScripts = resultModel.ResultObject;
                    }
                }
                else
                {
                    txtStatus.Text = "Update aborted.";
                    var ErrMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, "Unable to dowload database update scripts. Following error recieved. " + ErrMsg);
                    MessageBox.Show("Update aborted. Unable to download database update script. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                DAL.CommonFunctions.GetFinalError(ex);
                txtStatus.Text = "Update aborted.";
                pictureEdit1.Image = Properties.Resources.Close_Window_32;
                WriteToFile(DatabaseUpdateLogFile, "Error occured while trying to download update script. Error : " + ex.Message);
                MessageBox.Show("Update aborted. Error occured while trying to fetch update script. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Finalizer;
            }

            foreach (var rVersion in NextVersion)
            {
                string DownloadVersion = rVersion.MajorVersion.ToString() + "." + rVersion.MinorVersion.ToString();
                bool ExecuteUpdateExeIsReplaced = false;
                /// if version required to download files or the very last version then download files.
                if (rVersion.RequiredFileDownload || (rVersion.SoftwareVersionID == LatestSoftwareVersion.SoftwareVersionID))
                {

                    //Downloading update executable files
                    WriteToFile(DatabaseUpdateLogFile, "Downloading files for version " + DownloadVersion);

                    string UpdateRARFileName = DownloadVersion + ".rar";
                    string UpdateRARDownloadFilePath = Path.GetFullPath(tempFolder + "//" + DownloadVersion);
                    string UpdateRARDownloadFileName = Path.GetFullPath(tempFolder + "//" + UpdateRARFileName);

                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            WriteToFile(DatabaseUpdateLogFile, $"downloading file {UpdateRARFileName}");

                            client.Credentials = new NetworkCredential(FTPAddress[1], FTPAddress[2]);
                            await client.DownloadFileTaskAsync(new Uri(FTPAddress[0] + UpdateRARFileName), UpdateRARDownloadFileName);

                            WriteToFile(DatabaseUpdateLogFile, $"File downloaded {UpdateRARDownloadFileName}");
                        }
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Message == "The remote server returned an error: (550) File unavailable (e.g., file not found, no access).")
                        {
                            WriteToFile(DatabaseUpdateLogFile, $"File not found on server {UpdateRARFileName}. Skipping this update version");
                            //continue;
                        }
                        else
                        {
                            DAL.CommonFunctions.GetFinalError(ex);
                            txtStatus.Text = "Update aborted.";
                            pictureEdit1.Image = Properties.Resources.Close_Window_32;
                            WriteToFile(DatabaseUpdateLogFile, $"Error occured while downloading file {UpdateRARFileName}. Error : " + ex.Message);
                            MessageBox.Show("Can not update. Error occured while tryign to download update files. Please provide following details to your provider.\r\n\r\n" + ex.Message,
                                "Update", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            goto Finalizer;
                        }
                    }
                    //--

                    if (File.Exists(UpdateRARDownloadFileName))
                    {
                        // Extracking .rar 
                        WriteToFile(DatabaseUpdateLogFile, $"Extracting compressed file {UpdateRARDownloadFileName} to {UpdateRARDownloadFilePath}");
                        try
                        {
                            DeCompressRARintoDirectory(UpdateRARDownloadFileName, UpdateRARDownloadFilePath, UnRarPath);
                        }
                        catch (Exception ex)
                        {
                            DAL.CommonFunctions.GetFinalError(ex);
                            txtStatus.Text = "Update aborted.";
                            pictureEdit1.Image = Properties.Resources.Close_Window_32;
                            WriteToFile(DatabaseUpdateLogFile, "Unable to extract rar file. Error : " + ex.Message);
                            MessageBox.Show("Update aborted. Unable to extract rar file. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            goto Finalizer;
                        }
                        //--

                        // Copieng binary files 
                        string ApplicationFolderPath = Path.GetFullPath(Application.StartupPath + @"\..\");
                        WriteToFile(DatabaseUpdateLogFile, $"Files are copeing from {UpdateRARDownloadFilePath} to {ApplicationFolderPath}");

                        try
                        {
                            DirectoryCopy(UpdateRARDownloadFilePath, ApplicationFolderPath, true);
                        }
                        catch (Exception ex)
                        {
                            DAL.CommonFunctions.GetFinalError(ex);
                            WriteToFile(DatabaseUpdateLogFile, $"Unable to copy files. Error : " + ex.Message);
                        }
                        //

                        string ExecuteUpdateFileName = "Alit.Marker.ExecuteUpdate.exe";
                        string ExecuteUpdateFilePath = UpdateRARDownloadFilePath + "\\BIN\\" + ExecuteUpdateFileName;
                        string ExecuteUpdateDestinationFilePath = Application.StartupPath + "\\" + ExecuteUpdateFileName;
                        if (File.Exists(ExecuteUpdateFilePath))
                        {
                            WriteToFile(DatabaseUpdateLogFile, $"Copeing from {UpdateRARDownloadFilePath + "\\BIN\\" + ExecuteUpdateFileName} to {ExecuteUpdateDestinationFilePath}");
                            try
                            {
                                RenamingCurrentExe(ExecuteUpdateFilePath, ExecuteUpdateDestinationFilePath);
                                ExecuteUpdateExeIsReplaced = true;
                            }
                            catch (Exception ex)
                            {
                                DAL.CommonFunctions.GetFinalError(ex);
                                WriteToFile(DatabaseUpdateLogFile, $"Unable to copy ExecuteUpdate.exe . Error : " + ex.Message);
                            }
                        }
                    }
                }


                /// Executing update script for this version.
                if (dbUpdateScripts != null)
                {
                    using (dbMarkerEntities db = new dbMarkerEntities())
                    {
                        WriteToFile(DatabaseUpdateLogFile, "Executing database update scripts");

                        var recordsUpdateScript = dbUpdateScripts.Where(r => r.SoftwareVersionID == rVersion.SoftwareVersionID);
                        if (recordsUpdateScript.Count() > 0)
                        {
                            foreach (var rdbScript in recordsUpdateScript.OrderBy(r => r.MajorVersion).ThenBy(r => r.MinorVersion))
                            {
                                if (db.tblUpdateScriptLogs.Where(r => r.Executed).FirstOrDefault(r => r.UpdateScriptID == rdbScript.dbUpdateScriptID) != null)
                                {
                                    WriteToFile(DatabaseUpdateLogFile, $"Script was already executed.");
                                    continue;
                                }
                                else
                                {
                                    WriteToFile(DatabaseUpdateLogFile, $"Executing -Version {rdbScript.MajorVersion.ToString()}.{rdbScript.MinorVersion.ToString()} -ScripTitle {rdbScript.ScriptTitle}");
                                }
                                try
                                {
                                    await db.Database.ExecuteSqlCommandAsync(rdbScript.dbScript);

                                    db.tblUpdateScriptLogs.Add(new tblUpdateScriptLog()
                                    {
                                        UpdateScriptID = rdbScript.dbUpdateScriptID,
                                        Executed = true,
                                        ExecutionDateTime = DateTime.Now,
                                    });
                                    await db.SaveChangesAsync();
                                }
                                catch (Exception ex)
                                {
                                    DAL.CommonFunctions.GetFinalError(ex);
                                    WriteToFile(DatabaseUpdateLogFile, "Error occured while executing update script. Error " + ex.Message);
                                }
                            }
                        }
                    }
                }

                WriteToFile(DatabaseUpdateLogFile, $"Updating version to {LatestSoftwareVersion.MajorVersion}.{LatestSoftwareVersion.MinorVersion}");

                DAL.Settings.ApplicationSettings.SettingsDAL settingDALObj = new DAL.Settings.ApplicationSettings.SettingsDAL();
                SavingResult res = settingDALObj.SaveSettingL0("GUIVersionMajor", LatestSoftwareVersion.MajorVersion);
                if (res.ExecutionResult != eExecutionResult.CommitedSucessfuly)
                {
                    txtStatus.Text = "Update aborted.";
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, $"Error occured while trying to update major version to {LatestSoftwareVersion.MajorVersion}");
                    MessageBox.Show("Update aborted. Unable to update major version number. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }

                res = settingDALObj.SaveSettingL0("GUIVersionMinor", LatestSoftwareVersion.MinorVersion);
                if (res.ExecutionResult != eExecutionResult.CommitedSucessfuly)
                {
                    txtStatus.Text = "Update aborted.";
                    pictureEdit1.Image = Properties.Resources.Close_Window_32;
                    WriteToFile(DatabaseUpdateLogFile, $"Error occured while trying to update minor version to {LatestSoftwareVersion.MinorVersion}");
                    MessageBox.Show("Update aborted. Unable to updat minor version number. Please contact to your vendor and provide update log.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Finalizer;
                }


                /// if ExecuteUpdate.exe is replaced than break the application and restart it again with new exe.
                if(ExecuteUpdateExeIsReplaced)
                {
                    txtStatus.Text = "Restarting update application. Please wait...";
                    WriteToFile(DatabaseUpdateLogFile, $"ExecuteUpdate.exe has replaced and restarting update application.");
                    RestartUpdateApplication = true;
                    goto Finalizer;
                }
            }

            txtStatus.Text = "Software updated successfully.";
            pictureEdit1.Image = Properties.Resources.Checked_Checkbox_32;
            WriteToFile(DatabaseUpdateLogFile, $"Update successfully executed.");
            MessageBox.Show("Software updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Finalizer:
            if (DatabaseUpdateLogFile != null)
            {
                CloseLogFile(DatabaseUpdateLogFile);
            }
            this.Close();
            Application.Exit();
            //--
            if (RestartUpdateApplication)
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath+ "//Alit.Marker.ExecuteUpdate.exe");
            }

            base.OnSaveRecord(Paras);
        }

        // extracts [resource] into the the file specified by [path]
        void ExtractResource(string resource, string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resource);
            byte[] bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// make rar of a folder
        /// </summary>
        /// <param name="RARFileName">Rar File Path</param>
        /// <param name="RARExePath">WinRAR.exe path</param>
        public string CompressFolderIntoRAR(string RARFileName, string DirectoryToCompress, string RARExePath, string ExcludeFolders)
        {
            string error = "";
            try
            {
                System.Diagnostics.ProcessStartInfo sdp = new System.Diagnostics.ProcessStartInfo();
                string cmdArgs = $"a -r {RARFileName} {DirectoryToCompress} -x{ExcludeFolders}";
                sdp.ErrorDialog = false;
                sdp.UseShellExecute = true;
                sdp.Arguments = cmdArgs;
                sdp.FileName = RARExePath;//Winrar.exe path
                sdp.CreateNoWindow = false;
                sdp.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(sdp);
                process.WaitForExit();
                error = "OK";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }

        public string DeCompressRARintoDirectory(string RARFileName, string DirectoryToExtractFiles, string UnRARExePath)
        {
            string error = "";
            try
            {
                System.Diagnostics.ProcessStartInfo sdp = new System.Diagnostics.ProcessStartInfo();
                string cmdArgs = $"x -o+ {RARFileName} *.* {DirectoryToExtractFiles}\\";
                sdp.ErrorDialog = false;
                sdp.UseShellExecute = true;
                sdp.Arguments = cmdArgs;
                sdp.FileName = UnRARExePath;//Winrar.exe path
                sdp.CreateNoWindow = false;
                sdp.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(sdp);
                process.WaitForExit();
                error = "OK";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }

        public void RenamingCurrentExe(string sourceFile, string destinationFile)
        {
            // Assumes: using System.Reflection;
            Assembly currentAssembly = Assembly.GetEntryAssembly();
            if (currentAssembly == null)
                currentAssembly = Assembly.GetCallingAssembly();
            if (currentAssembly.Location.ToUpper() == destinationFile.ToUpper())
            {
                // ----- Workaround code here.
            }
            // Assumes: using System.IO;
            string appFolder = Path.GetDirectoryName(currentAssembly.Location);
            string appName = Path.GetFileNameWithoutExtension(currentAssembly.Location);
            string appExtension = Path.GetExtension(currentAssembly.Location);
            string archivePath = Path.Combine(appFolder, appName + "_OldVersion" + appExtension);
            if (File.Exists(archivePath))
            {
                try
                {
                    File.Delete(archivePath);
                }
                catch(Exception)
                {
                    string archivePathNew = null;
                    int renametry = 0;
                    do
                    {
                        archivePathNew = Path.Combine(appFolder, appName + "_OldVersion" + (renametry++).ToString() + appExtension);
                    } while ((File.Exists(archivePath)));
                    File.Move(archivePath, archivePathNew);
                }
            }
            File.Move(destinationFile, archivePath);
            // ----- The "true" argument permits overwriting.
            File.Copy(sourceFile, destinationFile, true);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void WriteToFile(StreamWriter File, string line)
        {
            txtProcessStatus.Text = line;
            Application.DoEvents();
            line = System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt ") + line;
            File.WriteLine(line);
            //byte[] byteline = Encoding.ASCII.GetBytes(line);
            //File.Write(byteline, 0, byteline.Count());
        }
        private Task WriteToFileAsync(StreamWriter File, string line)
        {
            txtProcessStatus.Text = line;
            Application.DoEvents();
            line = System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt ") + line;
            return File.WriteLineAsync(line);
            //byte[] byteline = Encoding.ASCII.GetBytes(line);
            //return File.WriteAsync(byteline, 0, byteline.Count());
        }

        private void CloseLogFile(StreamWriter File)
        {
            DatabaseUpdateLogFile.Flush();
            DatabaseUpdateLogFile.Close();
            DatabaseUpdateLogFile.Dispose();
        }
    }
}
