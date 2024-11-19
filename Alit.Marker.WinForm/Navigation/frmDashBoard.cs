using Alit.Marker.DAL.Settings;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Navigation
{
    public partial class frmDashBoard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SettingsDAL SettingsDAL;
        public static frmDashBoard DashBoard { get; private set; }

        public frmDashBoard()
        {
            DashBoard = this;
            InitializeComponent();
            ribbonMain.Minimized = true;

            //--
            DAL.Settings.CompanyDAL CompanyDAL = new DAL.Settings.CompanyDAL();
            SettingsDAL = new SettingsDAL();

            // Loading Settings at level 0
            Model.CommonProperties.LoginInfo.SoftwareSettings = SettingsDAL.GetSetting();

            // Loading theme from settings
            SkinHelper.InitSkinGallery(rgbiSkins);
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            UserLookAndFeel.Default.SkinName = Model.CommonProperties.LoginInfo.SoftwareSettings.GUIThemeSkinName; //Properties.Settings.Default["ApplicationSkinName"].ToString();

            this.Text = Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName + " " + GetApplicationVersion();
            lblCompanyName.Caption = "";
            lblFinPeriod.Caption = "";
            lblLoginTime.Caption = "";
            lblUserName.Caption = "";
        }

        private async void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach(var form in this.MdiChildren)
            {
                form.Close();
            }
            await Logout();
        }

        public static string GetApplicationVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        async Task Logout()
        {
            lblCompanyName.Caption = "";
            lblFinPeriod.Caption = "";
            lblLoginTime.Caption = "";
            lblUserName.Caption = "";
            lblSmsBalance.Caption = "";
            Model.CommonProperties.LoginInfo.LoggedinUser = null;
            Model.CommonProperties.LoginInfo.UserPermission = null;
            Model.CommonProperties.LoginInfo.LoggedInCompany = null;
            Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel = null;
            Model.CommonProperties.LoginInfo.LoggedInFinPeriod = null;
            await Login();
        }

        async Task Login()
        {
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.AutoUserLogin && DAL.Settings.CompanyDAL.CompanyCount() == 1)
            {
                Model.CommonProperties.LoginInfo.LoggedInCompany = DAL.Settings.CompanyDAL.GetFirstCompany();
                if (DAL.Settings.FinPeriodDAL.FinPeriodsCount(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID) == 1)
                {
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod = DAL.Settings.FinPeriodDAL.GetFirstFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                }
            }

            if (!Model.CommonProperties.LoginInfo.SoftwareSettings.AutoUserLogin || Model.CommonProperties.LoginInfo.LoggedInCompany == null || Model.CommonProperties.LoginInfo.LoggedInFinPeriod == null)
            {
                Users.frmUserLogin frmLogin = new Users.frmUserLogin();
                frmLogin.ShowDialog(this);
            }
            else
            {
                btnLogout.Visibility = BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.LoggedinUser != null && Model.CommonProperties.LoginInfo.LoggedInCompany != null && Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null)
            {
                lblUserName.Caption = Model.CommonProperties.LoginInfo.LoggedinUser.UserName;
                lblCompanyName.Caption = "Company : " + Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName;
                lblFinPeriod.Caption = "(" + Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + " - " + (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : "*") + ")";
                lblLoginTime.Caption = "Login at : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

                this.Text = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName + " " + lblFinPeriod.Caption + " - " + Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName + " " + GetApplicationVersion();

                SettingsDAL.GetSetting(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, Model.CommonProperties.LoginInfo.SoftwareSettings);

                Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel = DAL.Settings.CompanyDAL.GetCompanyDetailReportModel(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);

                if (!Model.CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                {
                    /// Setting visibility of bar items according to permission
                    foreach (BarItem item in ribbonMain.Items)
                    {
                        if (item.Tag != null)
                        {
                            long MenuOptionID = CommonFunctions.ParseLong(item.Tag.ToString());
                            var perm = Model.CommonFunctions.GetCurreUserPermission(MenuOptionID);
                            if (perm != null)
                            {
                                if (perm.CanView)
                                {
                                    item.Visibility = BarItemVisibility.Always;
                                }
                                else
                                {
                                    item.Visibility = BarItemVisibility.Never;
                                }
                            }
                            else
                            {
                                item.Visibility = BarItemVisibility.Never;
                            }
                        }
                    }
                }
            }
            else
            {
                this.Close();
                return;
            }

            ApplySettingsOnMenus();

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
            {
                await SMS.SMSHandler.UpdateDisplaySMSBalanceAsync(0);
            }

            ribbonMain.Minimized = false;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (CompanyDAL.GetFirstCompany() == null)
            {
                bool ContCompany = false;
                do
                {
                    Settings.frmCompany frmComp = new Settings.frmCompany();
                    frmComp.StartPosition = FormStartPosition.CenterScreen;
                    frmComp.ShowDialog();

                    if (CompanyDAL.GetFirstCompany() == null)
                    {
                        if (Alit.WinformControls.MessageBox.Show(this, "You don't have a company to start. Do you want to create a new company ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ContCompany = true;
                        }
                        else
                        {
                            Application.Exit();
                            return;
                        }
                    }
                    else
                    {
                        ContCompany = false;
                    }
                } while (ContCompany);
            }

            CheckForRegistrationDetail();

            await Login();
        }

        public void CheckForRegistrationDetail()
        {
            // Checking registration info.
            DAL.Registration.RegistrationDAL RegistationDAL = new DAL.Registration.RegistrationDAL();
            Model.CommonProperties.CurrentRegistration = RegistationDAL.GetSavedRegistration();
            if (Model.CommonProperties.CurrentRegistration != null)
            {
                btnSetting_Registration.Caption = "Registration";
                lblRegistrationName.Caption = "Registered to " + Model.CommonProperties.CurrentRegistration.FullName;
            }
            else
            {
                btnSetting_Registration.Caption = "Register Now";
                lblRegistrationName.Caption = "Software not registered";
            }
        }

        public void ApplySettingsOnMenus()
        {
            // Applying Settings
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            {
                btnSale_ProductMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnSale_PriceList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSale_ProductMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSale_PriceList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
            {
                lblSmsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnOthers_SMSLog.Visibility = BarItemVisibility.Always;
            }
            else
            {
                lblSmsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnOthers_SMSLog.Visibility = BarItemVisibility.Never;
            }

            if(Model.CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            {
                btnSale_SaleOrder.Visibility = BarItemVisibility.Always;

                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoPrefix)
                {
                    btnSale_SaleOrderNoPrefix.Visibility = BarItemVisibility.Always;
                }
            }
            else
            {
                btnSale_SaleOrder.Visibility = BarItemVisibility.Never;
                btnSale_SaleOrderNoPrefix.Visibility = BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNo &&
                Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix)
            {
                btnSaleReturnNoPrefix.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnSaleReturnNoPrefix.Visibility = BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNo && 
                Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoPrefix)
            {
                btnPurchaseReceiptNoPrefix.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnPurchaseReceiptNoPrefix.Visibility = BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNo &&
                Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoPrefix)
            {
                btnPurchaseReturnNoPrefix.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnPurchaseReturnNoPrefix.Visibility = BarItemVisibility.Never;
            }

            if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNo &&
                Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix)
            {
                btnReceiptNoPrefix.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnReceiptNoPrefix.Visibility = BarItemVisibility.Never;
            }
        }

        public static void ShowForm<T>(long MenuOptionID)
        {
            object frm = GetFormInstance<T>();
            if (frm != null && frm is Form)
            {
                ((Form)frm).Activate();
            }
            else
            {
                Type t = Type.GetType(typeof(T).ToString());
                Form newFrm = (Form)Activator.CreateInstance(t, false);

                if (newFrm is Template.BaseTemplate)
                {
                    ((Template.BaseTemplate)newFrm).MenuOptionID = MenuOptionID;
                }

                ShowForm(newFrm);
            }
        }
        public static void ShowForm(Form frm)
        {
            try
            {
                frm.MdiParent = DashBoard;
                frm.FormClosed += Chiled_FormClosed;
                frm.Show();
                DashBoard.ribbonMain.Minimized = true;
            }
            catch (ObjectDisposedException)
            { }
        }

        public static object GetFormInstance<T>()
        {
            return DashBoard.MdiChildren.OfType<T>().FirstOrDefault();
        }

        static void Chiled_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DashBoard.MdiChildren.Count() <= 1)
            {
                DashBoard.ribbonMain.Minimized = false;
            }
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            SettingsDAL.SaveSettingL0("GUIThemeSkinName", UserLookAndFeel.Default.SkinName);
        }


        private void btnSettingsUser_UserRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Users.frmUserGroup>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSettingsUser_UserMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Users.frmUser>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Properties.Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            //Properties.Settings.Default.Save();
            //--
            Application.Exit();
            base.OnClosing(e);
        }

        private void btnOtherMasters_StateMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<City.frmState>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnOtherMasters_CountryMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<City.frmCountry>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnOtherMasters_CityMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<City.frmCity>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSettingsInstitue_InstitueMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmCompany>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSettingsInstitue_FinancialPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmFinancialPeriod>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_StudentMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Customer.frmCustomer>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_PriceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Product.frmPriceList>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_ProductMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Product.frmProduct>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_AdditionalItemMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmAdditionalsMaster>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_TaxMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmTaxMaster>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_SaleInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSale>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_SaleInvoiceNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSaleInvoiceNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Transport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmTransport>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_ProductUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Product.frmUnit>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSettingsApplicationSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmApplicationSettings>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_InvoicePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Sales.frmInvoicePrint>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_SaleRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Sales.frmSaleRegister>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnTransactions_Receipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<CashBank.frmReceipt>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Reports_ReceiptPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Receipt.frmReceiptPrint>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnOther_Tools_CalculateCustomersBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Customer.frmCalculateCustomerBalance>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_TransactionRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.TransactionReports.frmRepTransactionRegister>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_SaleSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Sales.frmSaleSummary>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSetting_Registration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Registration.frmRegistration>(0);
        }

        private void tsbtnHelp_AboutUs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ShowForm(new Help.frmAboutUs());
            Help.frmAboutUs frm = new Help.frmAboutUs();
            frm.ShowDialog(this);
        }

        private void btnInv_StockIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Inventory.frmStockIn>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnInv_StockOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Inventory.frmStockOut>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnPurchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Purchase.frmPurchaseBill>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_SaleOrderNoPrefix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSaleOrderNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_SaleOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSaleOrder>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_SaleReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSaleReturn>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnPurchaseReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Purchase.frmPurchaseReturn>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnInventory_Rep_StockInHand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Inventory.frmStockInHand>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_CustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Reports.Customer.frmCustomerList>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnCustomerOpeningBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Customer.frmCustomerOpeningBalance>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Inventory.frmOpeningStock>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_ColorMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Inventory.frmStockLedger>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TransactionReports.frmRepCustomerBalanceReport>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Payment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<CashBank.frmPayment>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnOthers_SMSLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<SMS.frmSMSLog>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnInventory_ProductTaxCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Product.frmProductTaxCategory>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSaleReturnNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Sales.frmSaleReturnNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnPurchaseReceiptNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Purchase.frmPurchaseReceiptNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnPurchaseReturnNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Purchase.frmPurchaseReturnNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSale_Report_TaxRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Sales.frmRepTaxRegister>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnSettings_CheckUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            while (Model.CommonProperties.CurrentRegistration == null)
            {
                if (MessageBox.Show("Software registration is required before update. Click Yes to register.", "Register now", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Registration.frmRegistration frm = new Registration.frmRegistration();
                    frm.ShowDialog(this);
                }
                else
                {
                    return;
                }
            }
            string ExecuteUpdateEXEFilePath = Application.StartupPath + "\\" + "Alit.Marker.ExecuteUpdate.exe";
            if (System.IO.File.Exists(ExecuteUpdateEXEFilePath))
            {
                System.Diagnostics.Process.Start(ExecuteUpdateEXEFilePath);
                //this.Close();
                //Application.Exit();
            }
        }

        private void lblRegistrationName_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSetting_Registration_ItemClick(btnSetting_Registration, e);
        }

        private void btnReceiptNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<CashBank.frmReceiptNoPrefix>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnManufacturingFormula_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Manufacturing.frmProductFormula>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }

        private void btnManufacturingProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Manufacturing.frmProcess>(CommonFunctions.ParseLong(e.Item.Tag.ToString()));
        }
    }
}
