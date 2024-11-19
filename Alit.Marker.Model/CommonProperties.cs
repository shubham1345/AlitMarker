using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model
{
    public static class CommonProperties
    {
        public static class DevelopmentCompanyInfo
        {
            public const string CompanyName = "Alit Technologies";

            public const string CompanyShortName = "Alit";

            public const string ProductName = "Marker";

            public const string CompanyEmailSMTPHost = "mail.alittech.com";
            public const int CompanyEmailSMTPPort = 25;

            public static string ApplicationVersion { get; set; }
        }

        /// <summary>
        /// User Interface Data Formats
        /// </summary>
        public static class UIDataFormats
        {
            public static int AmountDecimalLen { get { return 2; } }

            public static int QuantityDecimalLen { get { return 2; } }

            public static int RateDecimalLen { get { return 2; } }

            public static string AmountFormat { get { return "n" + "".PadRight(AmountDecimalLen, '0'); } }

            public static string QuantityFormat { get { return "n" + "".PadRight(QuantityDecimalLen, '0'); } }

            public static string RateFormat { get { return "n" + "".PadRight(RateDecimalLen, '0'); } }

            public const string CurrencyMask = "n2";
        }

        private static Bitmap BlankImage_;
        public static Bitmap BlankImage
        {
            get
            {
                if (BlankImage_ == null)
                {
                    BlankImage_ = new Bitmap(1, 1);
                }
                return BlankImage_;
            }
        }


        public static class LoginInfo
        {
            private static Users.User.UserDetailModel LoggedinUser_;
            public static Users.User.UserDetailModel LoggedinUser
            {
                get { return LoggedinUser_; }
                set
                {
                    LoggedinUser_ = value;
                }
            }

            private static Settings.Compnay.CompanyDetailViewModel LoggedInCompany_;
            public static Settings.Compnay.CompanyDetailViewModel LoggedInCompany
            {
                get { return LoggedInCompany_; }
                set
                {
                    LoggedInCompany_ = value;
                }
            }

            static Settings.FinancialPeriod.FinPeriodDetailModel LoggedInFinPeriod_;
            public static Settings.FinancialPeriod.FinPeriodDetailModel LoggedInFinPeriod
            {
                get { return LoggedInFinPeriod_; }
                set
                {
                    LoggedInFinPeriod_ = value;
                }
            }


            private static Settings.ApplicationSettings.ApplicationSettingsViewModel SoftwareSettings_;
            public static Settings.ApplicationSettings.ApplicationSettingsViewModel SoftwareSettings
            {
                get { return SoftwareSettings_; }
                set
                {
                    SoftwareSettings_ = value;
                }
            }

            public static Model.Reports.CompanyDetailReportModel LoggedInCompanyReportModel
            {
                get;
                set;
            }

            public static List<Model.Users.UserGroup.MenuOptionPermissionViewModel> UserPermission { get; set; }

            //Others.ReportSettingsView ReportSettings_;
            //public Others.ReportSettingsView ReportSettings
            //{
            //    get { return ReportSettings_; }
            //    set
            //    {
            //        ReportSettings_ = value;
            //    }
            //}

            //public string DefaultConnectionString
            //{
            //    get
            //    {
            //        return Model.Properties.Settings.Default.AMWSMConnectionString;
            //    }
            //    set
            //    {
            //        Model.Properties.Settings.Default.AMWSMConnectionString = value;
            //    }
            //}
        }

        //public static Service.Update.Model.SoftwareRegistrationViewModel CurrentRegistration { get; set; }

        public const string MarkerAdminURL = "http://markeradmin.alittech.com/";
        public const string MarkerAdminAPIURL = "http://markeradmin.alittech.com/api/";
    }


}
