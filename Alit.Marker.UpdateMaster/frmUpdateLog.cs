using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.UpdateMaster
{
    public partial class frmUpdateLog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmUpdateLog()
        {
            InitializeComponent();
            ribbonControl1.Minimized = true;
        }

        protected override async void OnLoad(EventArgs e)
        {
            await LoadSoftwareVersionRows();
            base.OnLoad(e);
        }

        async Task LoadSoftwareVersionRows()
        {
            using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
            {
                var res = from r in db.tblSoftwareVersions
                          orderby r.ReleaseDateTime descending
                          select new SoftwareVersionViewModel()
                          {
                              SoftwareVersionID = r.SoftwareVersionID,
                              MajorVersion = r.GUIVersionMajor,
                              MinorVersion = r.GUIVersionMinor,
                              ReleaseDateTime = r.ReleaseDateTime,
                          };
                softwareVersionViewModelBindingSource.DataSource = await res.ToListAsync();
                gridControlSoftwareVersions.RefreshDataSource();
            }
        }

        private async void gridViewSoftwareVersion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetRow(e.FocusedRowHandle);
            if (row == null) return;
            //--
            using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
            {
                var res = await db.tbldbUpdateScripts.Where(r => r.SoftwareVersionID == row.SoftwareVersionID).Select(r=> new DatabaseUpdateScriptViewModel()
                {
                    DatabaseUpdateScriptID = r.UpdateScriptID,
                    ScriptTitle = r.dbScriptTitle,
                    ExecutionIndex = r.ExecutionIndex,
                }).ToListAsync();
                databaseUpdateScriptViewModelBindingSource.DataSource = res;
                gridViewDatabaseScript.RefreshData();
            }
        }

        private async void gridViewSoftwareVersion_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if(e.Row == null)
            {
                return;
            }
            SoftwareVersionViewModel row = (SoftwareVersionViewModel)e.Row;
            using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
            {
                DAL.tblSoftwareVersion SaveModel = null;
                if (row.SoftwareVersionID == 0)
                {
                    SaveModel = new DAL.tblSoftwareVersion();
                    db.tblSoftwareVersions.Add(SaveModel);
                }
                else
                {
                    SaveModel = await db.tblSoftwareVersions.FindAsync(row.SoftwareVersionID);
                    db.tblSoftwareVersions.Attach(SaveModel);
                    db.Entry(SaveModel).State = EntityState.Modified;
                }

                SaveModel.GUIVersionMajor = row.MajorVersion;
                SaveModel.GUIVersionMinor = row.MinorVersion;
                SaveModel.ReleaseDateTime = row.ReleaseDateTime;

                try
                {
                    await db.SaveChangesAsync();
                    row.SoftwareVersionID = SaveModel.SoftwareVersionID;
                }
                catch(Exception ex)
                {
                    CommonFunctions.GetFinalError(ex);
                    MessageBox.Show("Following error occured while trying to save software version.\r\n\r\n" + ex.Message);
                }
            }
        }

        private void gridViewSoftwareVersion_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            SoftwareVersionViewModel row = (SoftwareVersionViewModel)gridViewDatabaseScript.GetRow(e.RowHandle);
            if(row != null)
            {
                row.ReleaseDateTime = DateTime.Now;
            }
        }

        private async void repitembtnDeleteSoftwareVersion_Click(object sender, EventArgs e)
        {
            SoftwareVersionViewModel row = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetRow(gridViewSoftwareVersion.FocusedRowHandle);
            if (row != null)
            {
                gridViewSoftwareVersion.DeleteRow(gridViewSoftwareVersion.FocusedRowHandle);
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    db.tblSoftwareVersions.Remove(await db.tblSoftwareVersions.FindAsync(row.SoftwareVersionID));
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Task loadrows = LoadSoftwareVersionRows();
                        CommonFunctions.GetFinalError(ex);
                        MessageBox.Show("Following error occured while trying to save software version.\r\n\r\n" + ex.Message);
                        await loadrows;
                    }
                }
            }
        }

        private void gridViewSoftwareVersion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SoftwareVersionViewModel row = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetRow(e.RowHandle);
            if(row != null)
            {
                if(row.SoftwareVersionID != 0)
                {
                    gridViewSoftwareVersion.PostEditor();
                }
            }
        }

        private async void repitemBtnEditdbScript_Click(object sender, EventArgs e)
        {
            if(gridViewSoftwareVersion.GetFocusedRow() == null)
            {
                return;
            }
            gridViewSoftwareVersion.UpdateCurrentRow();
            gridViewDatabaseScript.UpdateCurrentRow();
            //-
            SoftwareVersionViewModel SoftwareVersionRow = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetFocusedRow();
            if(SoftwareVersionRow == null)
            {
                return;
            }
            //--
            DatabaseUpdateScriptViewModel row = (DatabaseUpdateScriptViewModel)gridViewDatabaseScript.GetRow(gridViewDatabaseScript.FocusedRowHandle);
            if (row != null)
            {
                splashScreenManager1.ShowWaitForm();
                string dbScript = "";
                if (row.DatabaseUpdateScriptID != 0)
                {
                    using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                    {
                        var SaveModel = await db.tbldbUpdateScripts.FindAsync(row.DatabaseUpdateScriptID);
                        if(SaveModel != null)
                        {
                            dbScript = SaveModel.dbScript ?? "";
                        }
                    }
                }
                splashScreenManager1.CloseWaitForm();
                //--
                frmdbScriptEditor frm = new frmdbScriptEditor(dbScript);
                frm.ShowDialog(this);
                if(frm.DialogResult == DialogResult.OK)
                {
                    dbScript = frm.dbScript;

                    splashScreenManager1.ShowWaitForm();
                    using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                    {
                        DAL.tbldbUpdateScript SaveModel = null;
                        if (row.DatabaseUpdateScriptID != 0)
                        {
                            SaveModel = await db.tbldbUpdateScripts.FindAsync(row.DatabaseUpdateScriptID);
                        }
                        if (SaveModel == null)
                        {
                            SaveModel = new DAL.tbldbUpdateScript();
                            SaveModel.rcdt = DateTime.Now;
                            db.tbldbUpdateScripts.Add(SaveModel);
                        }
                        else
                        {
                            SaveModel.redt = DateTime.Now;
                            db.tbldbUpdateScripts.Attach(SaveModel);
                            db.Entry(SaveModel).State = EntityState.Modified;
                        }

                        SaveModel.dbScriptTitle = row.ScriptTitle;
                        SaveModel.dbScript = dbScript;
                        SaveModel.ExecutionIndex = row.ExecutionIndex;
                        SaveModel.SoftwareVersionID = SoftwareVersionRow.SoftwareVersionID;

                        try
                        {
                            await db.SaveChangesAsync();
                            row.DatabaseUpdateScriptID = SaveModel.UpdateScriptID;
                        }
                        catch (Exception ex)
                        {
                            CommonFunctions.GetFinalError(ex);
                            splashScreenManager1.CloseWaitForm();
                            MessageBox.Show("Following error occured while trying to save software version.\r\n\r\n" + ex.Message);
                            return;
                        }
                        splashScreenManager1.CloseWaitForm();
                    }
                }
            }
        }

        private void gridViewDatabaseScript_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DatabaseUpdateScriptViewModel row = (DatabaseUpdateScriptViewModel)gridViewDatabaseScript.GetRow(e.RowHandle);
            row.ExecutionIndex = 
                (databaseUpdateScriptViewModelBindingSource.List.Cast<DatabaseUpdateScriptViewModel>().Max(r => (decimal?)r.ExecutionIndex) ?? 0 )+ 1;
        }

        private void gridViewDatabaseScript_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DatabaseUpdateScriptViewModel row = (DatabaseUpdateScriptViewModel)e.Row;
            if(row != null)
            {
                e.Valid = !String.IsNullOrWhiteSpace(row.ScriptTitle);
            }
        }

        private void gridViewDatabaseScript_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewDatabaseScript.PostEditor();
        }

        private async void gridViewDatabaseScript_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gridViewSoftwareVersion.GetFocusedRow() == null)
            {
                return;
            }
            gridViewSoftwareVersion.UpdateCurrentRow();
            gridViewDatabaseScript.UpdateCurrentRow();
            //-
            SoftwareVersionViewModel SoftwareVersionRow = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetFocusedRow();
            if (SoftwareVersionRow == null)
            {
                return;
            }
            //--
            DatabaseUpdateScriptViewModel row = (DatabaseUpdateScriptViewModel)gridViewDatabaseScript.GetRow(gridViewDatabaseScript.FocusedRowHandle);
            if (row != null)
            {
                //splashScreenManager1.ShowWaitForm();
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    DAL.tbldbUpdateScript SaveModel = null;
                    if (row.DatabaseUpdateScriptID != 0)
                    {
                        SaveModel = await db.tbldbUpdateScripts.FindAsync(row.DatabaseUpdateScriptID);
                    }
                    if (SaveModel == null)
                    {
                        SaveModel = new DAL.tbldbUpdateScript();
                        SaveModel.rcdt = DateTime.Now;
                        db.tbldbUpdateScripts.Add(SaveModel);
                    }
                    else
                    {
                        SaveModel.redt = DateTime.Now;
                        db.tbldbUpdateScripts.Attach(SaveModel);
                        db.Entry(SaveModel).State = EntityState.Modified;
                    }

                    SaveModel.dbScriptTitle = row.ScriptTitle;
                    SaveModel.ExecutionIndex = row.ExecutionIndex;
                    SaveModel.SoftwareVersionID = SoftwareVersionRow.SoftwareVersionID;

                    try
                    {
                        await db.SaveChangesAsync();
                        row.DatabaseUpdateScriptID = SaveModel.UpdateScriptID;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(ex);
                        //splashScreenManager1.CloseWaitForm();
                        MessageBox.Show("Following error occured while trying to save software version.\r\n\r\n" + ex.Message);
                        return;
                    }
                    //splashScreenManager1.CloseWaitForm();
                }
            }
        }

        private async void repitembtnDeleteScriptRow_Click(object sender, EventArgs e)
        {
            DatabaseUpdateScriptViewModel row = (DatabaseUpdateScriptViewModel)gridViewDatabaseScript.GetRow(gridViewDatabaseScript.FocusedRowHandle);
            if (row != null)
            {
                gridViewDatabaseScript.DeleteRow(gridViewDatabaseScript.FocusedRowHandle);
                using (DAL.DB_A05B1F_markerupdateEntities db = new DAL.DB_A05B1F_markerupdateEntities())
                {
                    db.tbldbUpdateScripts.Remove(await db.tbldbUpdateScripts.FindAsync(row.DatabaseUpdateScriptID));
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Task loadrows = LoadSoftwareVersionRows();
                        CommonFunctions.GetFinalError(ex);
                        MessageBox.Show("Following error occured while trying to save software version.\r\n\r\n" + ex.Message);
                        await loadrows;
                    }
                }
            }
        }

        bool IsFileUploading;
        private async void btnUploadZip_Click(object sender, EventArgs e)
        {
            if(IsFileUploading)
            {
                MessageBox.Show("File uploading is in progress please wait.", "Uploading", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SoftwareVersionViewModel SoftwareVersionRow = (SoftwareVersionViewModel)gridViewSoftwareVersion.GetFocusedRow();
            if (SoftwareVersionRow == null)
            {
                MessageBox.Show("No software version selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(txtZipFileName.Text == "" && !System.IO.File.Exists(txtZipFileName.Text))
            {
                MessageBox.Show("Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string localFilePath = txtZipFileName.Text;
            System.IO.FileInfo fi = new System.IO.FileInfo(localFilePath);
            string filename = fi.Name;//.Replace(fi.Extension, "");

            if (filename.Replace(fi.Extension, "") != (SoftwareVersionRow.MajorVersion.ToString() + "." + SoftwareVersionRow.MinorVersion.ToString()))
            {
                MessageBox.Show("File name should match with version number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("alittech-001", "786Sakina52");
                this.btnUploadZip.ImageOptions.Image = global::Alit.Marker.UpdateMaster.Properties.Resources.loading_small;
                IsFileUploading = true;
                await client.UploadFileTaskAsync(new Uri("ftp://ftp.site4now.net/markerupdate/Updatefiles/" + filename), "STOR", localFilePath);
                IsFileUploading = false;
                this.btnUploadZip.ImageOptions.Image = global::Alit.Marker.UpdateMaster.Properties.Resources.icons8_upload_to_ftp_32;
                MessageBox.Show($"File {fi.FullName} uploaded successfully ", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (IsFileUploading)
            {
                e.Cancel = true;
                MessageBox.Show("File uploading is in progress please wait.", "Uploading", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            base.OnClosing(e);
        }

        private void txtZipFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(.rar)|*.rar|(.zip)|*.zip";
            ofd.DefaultExt = ".rar";
            if(ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtZipFileName.Text = ofd.FileName;
            }
        }
    }

    public class SoftwareVersionViewModel
    {
        [Browsable(false)]
        public int SoftwareVersionID { get; set; }

        [DisplayName("Major Version")]
        public int MajorVersion { get; set; }

        [DisplayName("Minor Version")]
        public int MinorVersion { get; set; }

        [DisplayName("Release Date & Time")]
        public DateTime ReleaseDateTime { get; set; }
    }

    public class DatabaseUpdateScriptViewModel
    {
        [Browsable(false)]
        public int DatabaseUpdateScriptID { get; set; }

        [DisplayName("Execution Index")]
        public decimal ExecutionIndex { get; set; }

        [DisplayName("Script Title")]
        public string ScriptTitle { get; set; }
    }
}
