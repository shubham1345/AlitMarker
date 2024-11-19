using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            // Add handler to handle the exception raised by additional threads
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //DevExpress.Utils.AppearanceObject.DefaultFont = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.Name, 9);
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Arial", 10, FontStyle.Bold);
            string DataPath = Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath) + ".\\..\\Data");
            //MessageBox.Show(DataPath);
            AppDomain.CurrentDomain.SetData("DataDirectory", DataPath);

            Template.CommonPropperties.IsRunTime = true;
            Model.CommonProperties.DevelopmentCompanyInfo.ApplicationVersion = GetApplicationVersion();
            Application.Run(new Navigation.frmNavigationDashboard());

            // Stop the application and all the threads in suspended state.
            Environment.Exit(-1);
        }

        public static string GetApplicationVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        static async void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // All exceptions thrown by the main thread are handled over this method
             await ShowExceptionDetails(e.Exception);
        }

        static async void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method
             await ShowExceptionDetails(e.ExceptionObject as Exception);

            // Suspend the current thread for now to stop the exception from throwing.
            
            //Thread.CurrentThread.Suspend();
        }

        static async Task ShowExceptionDetails(Exception Ex)
        {
            while (Ex != null && Ex.Message == " occurred while updating the entries. See the inner exception for details.")
            {
                Ex = Ex.InnerException;
            }

            string ValidationError = "";
            if (Ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
            {
                ValidationError = "Database Entity Validation Errors : \r\n\r\n";

                System.Data.Entity.Validation.DbEntityValidationException ValidationException = (System.Data.Entity.Validation.DbEntityValidationException)Ex;

                foreach (System.Data.Entity.Validation.DbEntityValidationResult ValidRes in ValidationException.EntityValidationErrors)
                {
                    foreach (System.Data.Entity.Validation.DbValidationError ValidError in ValidRes.ValidationErrors)
                    {
                        ValidationError += ValidError.PropertyName + " = " + ValidError.ErrorMessage + "\r\n";
                    }
                    ValidationError += "\r\n";
                }
            }

            var message =
                //"<h2>Registration Info:</h2></br>" +
                //$"<h3>Registered Firm : {Model.CommonProperties.CurrentRegistration.CompanyName}, {Model.CommonProperties.CurrentRegistration.CityName}</h3></br>" +
                //$"<h3>Contact Details : Phone : {Model.CommonProperties.CurrentRegistration.PhoneNo}, Mobile : {Model.CommonProperties.CurrentRegistration.MobileNo}, Email : {Model.CommonProperties.CurrentRegistration.EMailID} </h3></br></br></br>" +

                "<html><body><h2>Login Details : </h2>" +
                $"</br><h3>User : {(Model.CommonProperties.LoginInfo.LoggedinUser != null ? Model.CommonProperties.LoginInfo.LoggedinUser.UserName : "")}</h3>" +
                $"</br><h3>Company Name : {(Model.CommonProperties.LoginInfo.LoggedInCompany != null ? Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName : "")}</h3>" + 
                $"</br><h3>Financial Period : {(Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodName : "")}</h3>" +

                "<h2>Error details :</h2>" +                  
                $"<h3>Validation Error : {ValidationError}.</h3></br><h3>Exception : {Ex.Message}</h3></br><h3>Stack Trace </h3></br></p>{Ex.StackTrace}</p>"+
                "</body></html>";

            //Model.CommonFunctions.SendEmailFromNoReply("support@alittech.com",
            //    $"Error occured in {Model.CommonProperties.DevelopmentCompanyInfo.ProductName}",
            //    message,
            //    TakeScreenShotPrimaryScreen());

            Model.CommonFunctions.SendEmailFromNoReply("support@alittech.com",
                $"Error in {Model.CommonProperties.DevelopmentCompanyInfo.ProductName}, {(Model.CommonProperties.LoginInfo.LoggedInCompany != null ? Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName : "")}",
                message);

            Task sendEmail = Model.CommonFunctions.SendEmailFromNoReplyAsync("support@alittech.com",
                $"Screen shot : Error occured in {Model.CommonProperties.DevelopmentCompanyInfo.ProductName}",
                message,
                new System.Net.Mail.Attachment( TakeScreenShotPrimaryScreen(), "screenshot.jpg"));

            MessageBox.Show(Ex.Message, @"Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            await sendEmail;
        }

        static Stream TakeScreenShotPrimaryScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            return new MemoryStream(Alit.Marker.Model.CommonFunctions.ConvertImageToBinary(bitmap).ToArray());
            //bitmap.Save("c:\\screenshot.jpeg", ImageFormat.Jpeg);
        }
    }
}

