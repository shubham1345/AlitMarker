using Alit.Marker.DAL.Settings.ApplicationSettings;
using Alit.Marker.DAL.Users.User;
using Alit.Marker.Model.Account.Account;
using Alit.Marker.WinForm.Settings.Compnay;
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
    public partial class frmNavigationDashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SettingsDAL SettingsDAL;
        UserDAL UserDAL;
        public static frmNavigationDashboard DashBoard { get; private set; }

        public frmNavigationDashboard()
        {
            DashBoard = this;
            InitializeComponent();
            ribbonMain.Minimized = true;

            //--
            DAL.Settings.Compnay.CompanyDAL CompanyDAL = new DAL.Settings.Compnay.CompanyDAL();
            SettingsDAL = new SettingsDAL();
            UserDAL = new UserDAL();

            // Loading Settings at level 0
            Model.CommonProperties.LoginInfo.SoftwareSettings = SettingsDAL.GetSetting();

            // Loading theme from settings
            SkinHelper.InitSkinGallery(rgbiSkins);
            //UserLookAndFeel.Default.SkinName = Model.CommonProperties.LoginInfo.SoftwareSettings.GUIThemeSkinName;
            UserLookAndFeel.Default.SetSkinStyle(Model.CommonProperties.LoginInfo.SoftwareSettings.GUIThemeSkinName,
                Model.CommonProperties.LoginInfo.SoftwareSettings.GUIThemeSvgPellateName);
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;

            this.Text = Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName 
                + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName 
                + " " + Model.CommonProperties.DevelopmentCompanyInfo.ApplicationVersion;

            lblCompanyName.Caption = "";
            lblFinPeriod.Caption = "";
            lblLoginTime.Caption = "";
            lblUserName.Caption = "";
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                form.Close();
            }
            Logout();
        }

        void Logout()
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
            Login(true);
        }

        void Login(bool ShowLoginFormForcibly = false)
        {

            if (ShowLoginFormForcibly == false && Properties.Settings.Default.UserLoginRememberMe)
            {
                Model.CommonProperties.LoginInfo.LoggedinUser = UserDAL.GetUserDetailModelById(Properties.Settings.Default.UserLoginRememberMeUserID);
            }
            if (Model.CommonProperties.LoginInfo.LoggedinUser == null)
            {
                using (Users.frmUserLogin frmLogin = new Users.frmUserLogin())
                {
                    if (frmLogin.ShowDialog(this) != DialogResult.OK || Model.CommonProperties.LoginInfo.LoggedinUser == null)
                    {
                        Application.Exit();
                        return;
                    }
                }
            }
            lblUserName.Caption = Model.CommonProperties.LoginInfo.LoggedinUser.UserName;
            lblLoginTime.Caption = "Login at : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            if (DAL.Settings.Compnay.CompanyDAL.CompanyCount() == 1)
            {
                Model.CommonProperties.LoginInfo.LoggedInCompany = DAL.Settings.Compnay.CompanyDAL.GetFirstCompany();
                if (DAL.Settings.FinancialPeriod.FinPeriodDAL.FinPeriodsCount(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID) == 1)
                {
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod = DAL.Settings.FinancialPeriod.FinPeriodDAL.GetFirstFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                    btnSwitchCompanyFP.Visibility = BarItemVisibility.Never;
                }

            }

            if (Model.CommonProperties.LoginInfo.LoggedInFinPeriod == null)
            {
                btnSwitchCompanyFP.Visibility = BarItemVisibility.Always;
                using (frmCompanySelection frm = new frmCompanySelection())
                {
                    if (frm.ShowDialog(this) != DialogResult.OK || Model.CommonProperties.LoginInfo.LoggedInFinPeriod == null)
                    {
                        Application.Exit();
                        return;
                    }
                }
            }

            if (Model.CommonProperties.LoginInfo.LoggedinUser != null && Model.CommonProperties.LoginInfo.LoggedInCompany != null && Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null)
            {
                lblCompanyName.Caption = "Company : " + Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName;
                lblFinPeriod.Caption = "(" + Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + " - " + (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : "*") + ")";

                //this.Text = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName 
                //    + " " + lblFinPeriod.Caption 
                //    + " - " + Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName 
                //    + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName 
                //    + " " + Model.CommonProperties.DevelopmentCompanyInfo.ApplicationVersion;

                SettingsDAL.GetSetting(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, Model.CommonProperties.LoginInfo.SoftwareSettings);

                Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel = DAL.Settings.Compnay.CompanyDAL.GetCompanyDetailReportModel(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);

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

            ribbonMain.Minimized = false;
        }

        protected async override void OnShown(EventArgs e)
        {
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Arial", 10, FontStyle.Bold);
            if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
            {
                await SMS.SMSHandler.UpdateDisplaySMSBalanceAsync(0);
            }
            base.OnShown(e);

            //if (CompanyDAL.GetFirstCompany() == null)
            //{
            //    bool ContCompany = false;
            //    do
            //    {
            //        Settings.frmCompany frmComp = new Settings.frmCompany();
            //        frmComp.StartPosition = FormStartPosition.CenterScreen;
            //        frmComp.ShowDialog();

            //        if (CompanyDAL.GetFirstCompany() == null)
            //        {
            //            if (Alit.WinformControls.MessageBox.Show(this, "You don't have a company to start. Do you want to create a new company ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                ContCompany = true;
            //            }
            //            else
            //            {
            //                Application.Exit();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ContCompany = false;
            //        }
            //    } while (ContCompany);
            //}

            //CheckForRegistrationDetail();

            Login(false);
            navBarControl1_GroupExpanded(navBarControl1, new DevExpress.XtraNavBar.NavBarGroupEventArgs(nbgSale));
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.ribbonMain.ApplicationCaption = this.Text;
            base.OnTextChanged(e);
        }
        

        public void CheckForRegistrationDetail()
        {
            //// Checking registration info.
            //DAL.Registration.RegistrationDAL RegistationDAL = new DAL.Registration.RegistrationDAL();
            //Model.CommonProperties.CurrentRegistration = RegistationDAL.GetSavedRegistration();
            //if (Model.CommonProperties.CurrentRegistration != null)
            //{
            //    btnSetting_Registration.Caption = "Registration";
            //    lblRegistrationName.Caption = "Registered to " + Model.CommonProperties.CurrentRegistration.FullName;
            //}
            //else
            //{
            //    btnSetting_Registration.Caption = "Register Now";
            //    lblRegistrationName.Caption = "Software not registered";
            //}
        }

        public void ApplySettingsOnMenus()
        {
            //// Applying Settings
            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts)
            //{
            //    btnSale_ProductMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    btnSale_PriceList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnSale_ProductMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    btnSale_PriceList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}

            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
            //{
            //    lblSmsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    btnOthers_SMSLog.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    lblSmsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    btnOthers_SMSLog.Visibility = BarItemVisibility.Never;
            //}

            //if(Model.CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder)
            //{
            //    btnSale_SaleOrder.Visibility = BarItemVisibility.Always;

            //    if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoPrefix)
            //    {
            //        btnSale_SaleOrderNoPrefix.Visibility = BarItemVisibility.Always;
            //    }
            //}
            //else
            //{
            //    btnSale_SaleOrder.Visibility = BarItemVisibility.Never;
            //    btnSale_SaleOrderNoPrefix.Visibility = BarItemVisibility.Never;
            //}

            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNo &&
            //    Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix)
            //{
            //    btnSaleReturnNoPrefix.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnSaleReturnNoPrefix.Visibility = BarItemVisibility.Never;
            //}

            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNo && 
            //    Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoPrefix)
            //{
            //    btnPurchaseReceiptNoPrefix.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnPurchaseReceiptNoPrefix.Visibility = BarItemVisibility.Never;
            //}

            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNo &&
            //    Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoPrefix)
            //{
            //    btnPurchaseReturnNoPrefix.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnPurchaseReturnNoPrefix.Visibility = BarItemVisibility.Never;
            //}

            //if (Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNo &&
            //    Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix)
            //{
            //    btnReceiptNoPrefix.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnReceiptNoPrefix.Visibility = BarItemVisibility.Never;
            //}
        }

        public static void ShowForm<T>(params object[] obj)
        { 
            object frm = GetFormInstance<T>();
            if (frm != null && frm is Form)
            {
                ((Form)frm).Activate();
            }
            else
            {
                Type t = Type.GetType(typeof(T).ToString());
                Form newFrm = null;
                if (obj.Count() > 0)
                {
                    newFrm = (Form)Activator.CreateInstance(t, obj);
                }
                else
                {
                    newFrm = (Form)Activator.CreateInstance(t, false);
                }
                
                //if (newFrm is Template.frmDashboardTemplate)
                //{
                //    ((Template.frmDashboardTemplate)newFrm).MenuOptionID = MenuOptionID;
                //}
                ShowForm(newFrm);
            }
        }
        public static void ShowForm(Form frm)
        {
            try
            {
                if (DashBoard != null && !DashBoard.IsDisposed && !DashBoard.Disposing)
                {
                    frm.MdiParent = DashBoard;
                    frm.FormClosed += Chiled_FormClosed;
                    frm.Show();
                    //DashBoard.ribbonMain.Minimized = true;
                }
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
            //if (DashBoard.MdiChildren.Count() <= 1)
            //{
            //    DashBoard.ribbonMain.Minimized = false;
            //}
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            SettingsDAL.SaveSettingL0("GUIThemeSkinName", UserLookAndFeel.Default.SkinName);
            SettingsDAL.SaveSettingL0("GUIThemeSvgPellateName", UserLookAndFeel.Default.ActiveSvgPaletteName);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Properties.Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            //Properties.Settings.Default.Save();
            //--
            Application.Exit();
            base.OnClosing(e);
        }

        private void navBarControl1_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            if (e.Group == null)
            {
                return;
            }

            if (e.Group == nbgSetting)
            {
                nbiUser_LinkClicked(null, null);
            }
            else if(e.Group == nbgSale)
            {
                ShowForm<ERP.Transaction.Sales.frmSaleTransactionDashboard>();
            }
        }

        private void ribbonMain_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            DevExpress.XtraBars.Ribbon.RibbonControl control = e.MergeOwner;//((DevExpress.XtraBars.Ribbon.RibbonControl)sender);
            control.SelectedPage = control.TotalPageCategory.GetPageByText("Home");
        }

        private void nbiUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Users.User.frmUserDashboard>();
        }

        private void nbiCompany_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Settings.Compnay.frmCompanyDashboard>();
        }

        private void nbiCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Account.frmCustomerDashboard>();  
            //ShowForm<Account.Account.frmAccountDashboard>(eAccountFormType.Customer);
            //ShowForm<Account.Account.frmAccountDashboard>((int)eAccountFormType.Customer);
        }

        private void nbiProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Inventory.Masters.StockItem.frmStockItemDashboard>();
        }

        private void nbiSaleInvoice_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Transaction.Sales.SaleInvoice.frmSaleInvoiceDashboard>();
        }

        private void nbiSaleOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Transaction.Sales.SaleOrder.frmSaleOrderDashboard>();
        }

        private void nbiSaleReturn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Transaction.Sales.SaleReturn.frmSaleReturnDashboard>();
        }

        private void nbiReceipt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Transactions.Receipt.frmReceiptDashboard>();
        }

        private void nbiPurchaseBill_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Transaction.Purchase.PurchaseBill.frmPurchaseBillDashboard>();
        }

        private void btnPurchaseReturn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Transaction.Purchase.PurchaseReturn.frmPurchaseReturnDashboard>();
        }

        private void btnPayment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Transactions.Payment.frmPaymentDashboard>();
        }

        private void nbiStockIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Inventory.Transaction.StockIn.frmStockInDashboard>();
        }

        private void nbiStockOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Inventory.Transaction.StockOut.frmStockOutDashboard>();
        }

        private void nbiProductFormula_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Manufacturing.Process.frmProcessDashboard>();
        }

        private void nbiSoftwareSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (Settings.ApplicationSettings.frmApplicationSettings frm = new Settings.ApplicationSettings.frmApplicationSettings())
            {
                frm.ShowDialog(this);
            }
        }

        private void nbiAdditionalDiscountTax_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<ERP.Masters.AdditionalItems.frmAdditionalItemDashboard>();
        }

        private void nbiCity_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<City.City.frmCityGridCrud>();
        }

        private void nbiInventoryDashboard_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WinForm.Inventory.frmInventoryDefaultDashboard obj = new Inventory.frmInventoryDefaultDashboard();
            obj.ShowDialog();
        }

        private void nbiAccountGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Group.frmAccountGroupDashboard>();
        }

        private void nbiAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            ShowForm<Account.Account.frmAccountDashboard>();
        }

        private void nbiSupplier_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ShowForm<Account.Account.frmAccountDashboard>((int)eAccountFormType.Supplier);
            //ShowForm<Account.Account.frmAccountDashboard>(null);

            //object[] obj = new object[1];
            //obj[0] = eAccountFormType.Supplier;

            //ShowForm<Account.Account.frmAccountDashboard>(eAccountFormType.Supplier);
            ShowForm<Account.Account.frmSupplierDashboard>();
        }

        private void nbiJournalVoucher_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Transactions.JournalVoucher.frmJournalVoucherDashboard>();
        }

        private void nbiVoucherType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.VoucherType.frmVoucherTypeDashboard>();
        }

        private void nbiContraVoucher_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Transactions.ContraVoucher.frmContraVoucherDashboard>();
        }

        private void nbiLedger_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Reports.Accounts.Transactions.frmRepLedger>();
        }

        private void nbiBalanceReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Reports.Accounts.Transactions.frmRepBalance>();
        }

        private void nbiDayBookReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Reports.Accounts.Transactions.frmRepDayBook>();
        }

        private void btnChangePassword_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Settings.ChangePassword.frmChangePassword frm= new Settings.ChangePassword.frmChangePassword();
            frm.ShowDialog();
        }


        private void btnSwitchCompanyFP_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmCompanySelection frm = new frmCompanySelection(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID))
            {
                if (frm.ShowDialog(this) != DialogResult.OK || Model.CommonProperties.LoginInfo.LoggedinUser == null)
                {
                    return;
                }
            
                if (Model.CommonProperties.LoginInfo.LoggedinUser != null && Model.CommonProperties.LoginInfo.LoggedInCompany != null && Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null)
                {
                    lblCompanyName.Caption = "Company : " + Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName;
                    lblFinPeriod.Caption = "(" + Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + " - " + (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : "*") + ")";
                }
                if (DAL.Settings.Compnay.CompanyDAL.CompanyCount() == 1)
                {
                    if (DAL.Settings.FinancialPeriod.FinPeriodDAL.FinPeriodsCount(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID) == 1)
                    {
                        btnSwitchCompanyFP.Visibility = BarItemVisibility.Never;
                    }
                    else
                    {
                        btnSwitchCompanyFP.Visibility = BarItemVisibility.Always;
                    }

                }
                else
                {
                    btnSwitchCompanyFP.Visibility = BarItemVisibility.Always;
                }
            }
        }

        private void btnLogoutLarge_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                form.Close();
            }
            Logout();

        }

        private void nbiBankReconciliation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<Account.Transactions.Bank.frmBankReconciliation>();
        }

        private void nbiOpeningStock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowForm<WinForm.Inventory.frmOpeningStockGridCRUD>();
        }

        private void frmNavigationDashboard_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
