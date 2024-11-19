using Alit.Marker.DAL.Customer;
using Alit.Marker.DAL.ERP.Masters.AdditionalItems;
using Alit.Marker.Model;
using Alit.Marker.Model.ERP.Masters.AdditionalItems;
using Alit.Marker.Model.Settings.ApplicationSettings;
using Alit.Marker.Model.Template;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.Marker.WinForm.Settings.ApplicationSettings
{
    public partial class frmApplicationSettings : Template.frmNormalTemplate
    {
        DevExpress.XtraEditors.TokenEditToken SaleInvoiceNoSeriesPrefixToken;
        DevExpress.XtraEditors.TokenEditToken SaleOrderNoSeriesPrefixToken;
        DevExpress.XtraEditors.TokenEditToken SaleReturnNoSeriesPrefixToken;
        DevExpress.XtraEditors.TokenEditToken PurchaseRecNoSeriesPrefixToken;
        DevExpress.XtraEditors.TokenEditToken PurchaseReturnNoSeriesPrefixToken;
        DevExpress.XtraEditors.TokenEditToken ReceiptNoSeriesPrefixToken;

        DAL.Settings.ApplicationSettings.SettingsDAL DALObject;
        DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix.SaleInvoiceNoPrefixDAL PrefixDAL;
        DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix.SaleOrderNoPrefixDAL SOPrefixDAL;
        DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix.SaleReturnNoPrefixDAL SRPrefixDAL;
        DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL PReceiptPrefixDAL;
        DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL PReturnPrefixDAL;
        DAL.Account.Transactions.Receipt.ReceiptNoPrefix.ReceiptNoPrefixDAL ReceiptNoPrefixDAL;
        CustomerDAL CustomerDAL;
        AdditionalItemDAL AddLessItemMasterDALObj;


        object dsSaleInvoiceNoPrefix;
        object dsSaleOrderNoPrefix;
        object dsSaleReturnNoPrefix;
        object dsPurchaseReceiptNoPrefix;
        object dsPurchaseReturnNoPrefix;
        object dsReceiptNoPrefix;
        object dsCustomer;
        object dsAddLessItems;
        public frmApplicationSettings()
        {
            InitializeComponent();
            tabbedControlGroupSale.SelectedTabPageIndex = 0;
            tabbedControlGroupMain.SelectedTabPageIndex = 0;
            

            ExitButtonCaption = "Cancel";

            DALObject = new DAL.Settings.ApplicationSettings.SettingsDAL();
            PrefixDAL = new DAL.ERP.Transaction.Sales.SaleInvoice.SaleInvoiceNoPrefix.SaleInvoiceNoPrefixDAL();
            SOPrefixDAL = new DAL.ERP.Transaction.Sales.SaleOrder.SaleOrderNoPrefix.SaleOrderNoPrefixDAL();
            SRPrefixDAL = new DAL.ERP.Transaction.Sales.SaleReturn.SaleReturnNoPrefix.SaleReturnNoPrefixDAL();
            PReceiptPrefixDAL = new DAL.ERP.Transaction.Purchase.PurchaseBill.PurchaseReciptNo.PurchaseReceiptNoPrefixDAL();
            PReturnPrefixDAL = new DAL.ERP.Transaction.Purchase.PurchaseReturn.PurchaseReturnNoPrefix.PurchaseReturnNoPrefixDAL();
            ReceiptNoPrefixDAL = new DAL.Account.Transactions.Receipt.ReceiptNoPrefix.ReceiptNoPrefixDAL();
            CustomerDAL = new CustomerDAL();
            AddLessItemMasterDALObj = new AdditionalItemDAL();

            SaleInvoiceNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");
            SaleOrderNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");
            SaleReturnNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");
            PurchaseRecNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");
            PurchaseReturnNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");
            ReceiptNoSeriesPrefixToken = new DevExpress.XtraEditors.TokenEditToken("Prefix", "Prefix");

            this.tokenEditSaleInvoiceNoSeries.Properties.Separators.AddRange(new string[] {" + "});
            this.tokenEditSaleInvoiceNoSeries.Properties.Tokens.Add(SaleInvoiceNoSeriesPrefixToken);
            this.tokenEditSaleInvoiceNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditSaleInvoiceNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditSaleInvoiceNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            this.tokenEditSaleOrderNoSeries.Properties.Separators.AddRange(new string[] { "," });
            this.tokenEditSaleOrderNoSeries.Properties.Tokens.Add(SaleOrderNoSeriesPrefixToken);
            this.tokenEditSaleOrderNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditSaleOrderNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditSaleOrderNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            this.tokenEditSaleReturnNoSeries.Properties.Separators.AddRange(new string[] { "," });
            this.tokenEditSaleReturnNoSeries.Properties.Tokens.Add(SaleReturnNoSeriesPrefixToken);
            this.tokenEditSaleReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditSaleReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditSaleReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            this.tokenEditPurchaseRecNoSeries.Properties.Separators.AddRange(new string[] { "," });
            this.tokenEditPurchaseRecNoSeries.Properties.Tokens.Add(PurchaseRecNoSeriesPrefixToken);
            this.tokenEditPurchaseRecNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditPurchaseRecNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditPurchaseRecNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            this.tokenEditPurchaseReturnNoSeries.Properties.Separators.AddRange(new string[] { "," });
            this.tokenEditPurchaseReturnNoSeries.Properties.Tokens.Add(PurchaseReturnNoSeriesPrefixToken);
            this.tokenEditPurchaseReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditPurchaseReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditPurchaseReturnNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            this.tokenEditReceiptNoSeries.Properties.Separators.AddRange(new string[] { "," });
            this.tokenEditReceiptNoSeries.Properties.Tokens.Add(ReceiptNoSeriesPrefixToken);
            this.tokenEditReceiptNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Date", "Date"));
            this.tokenEditReceiptNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("MonthYear", "MonthYear"));
            this.tokenEditReceiptNoSeries.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken("Year", "Year"));

            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.ChallanNo, "Challan No", CheckState.Unchecked, true);
            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.ChallanDate, "Challan Date", CheckState.Unchecked, true);
            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OrderNo, "Order No.", CheckState.Unchecked, true);
            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OrderDate, "Order Date", CheckState.Unchecked, true);
            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.SupplierRefNo, "Supplier Reference No.", CheckState.Unchecked, true);
            chkblistSaleInvoiceChallanDetails.Items.Add((int)Model.Settings.ApplicationSettings.eSaleInvoiceChallanElements.OtherRefNo, "Other Reference No.", CheckState.Unchecked, true);

            //
            CommonFunctions.SetQuantityMask(txtSaleInvoiceDefaultQuan);
        }

        protected override void OnLoadFormValues()
        {

            dsSaleInvoiceNoPrefix = PrefixDAL.GetLookupList();
            dsSaleOrderNoPrefix = SOPrefixDAL.GetLookupList();
            dsSaleReturnNoPrefix = SRPrefixDAL.GetLookupList();
            dsPurchaseReceiptNoPrefix  = PReceiptPrefixDAL.GetLookupList();
            dsPurchaseReturnNoPrefix = PReturnPrefixDAL.GetLookupList();
            dsReceiptNoPrefix = ReceiptNoPrefixDAL.GetLookupList();
            dsCustomer = CustomerDAL.GetLookupList();
            dsAddLessItems = AddLessItemMasterDALObj.GetLookupListFinal(Model.TransactionsCommon.eAdditionalItemType.AdditionalItem);

            base.OnLoadFormValues();
        }

        protected override void OnAssignFormValues()
        {
            tswitchSaleInvoiceNo_Toggled(tswitchSaleInvoiceNo, null);
            tswitchSaleInvoiceNoPrefix_Toggled(tswitchSaleInvoiceNoPrefix, null);
            tswitchSaleInvoiceNoAutoGenerate_Toggled(tswitchSaleInvoiceNoAutoGenerate, null);

            tswitchSaleOrderNo_Toggled(tswitchSaleOrderNo, null);
            tswitchSaleOrderNoPrefix_Toggled(tswitchSaleOrderNoPrefix, null);
            tswitchSaleOrderNoAutoGenerate_Toggled(tswitchSaleOrderNoAutoGenerate, null);

            tswitchSaleReturnNo_Toggled(tswitchSaleReturnNo, null);
            tswitchSaleReturnNoPrefix_Toggled(tswitchSaleReturnNoPrefix, null);
            tswitchSaleReturnNoAutoGenerate_Toggled(tswitchSaleReturnNoAutoGenerate, null);

            tswitchPurchaseRecNo_Toggled(tswitchPurchaseRecNo, null);
            tswitchPurchaseRecNoPrefix_Toggled(tswitchPurchaseRecNoPrefix, null);
            tswitchPurchaseRecNoAutoGenerate_Toggled(tswitchPurchaseRecNoAutoGenerate, null);

            tswitchPurchaseReturnNo_Toggled(tswitchPurchaseReturnNo, null);
            tswitchPurchaseReturnNoPrefix_Toggled(tswitchPurchaseReturnNoPrefix, null);
            tswitchPurchaseReturnNoAutoGenerate_Toggled(tswitchPurchaseReturnNoAutoGenerate, null);

            tswitchReceiptNo_Toggled(tswitchReceiptNo, null);
            tswitchReceiptNoPrefix_Toggled(tswitchReceiptNoPrefix, null);
            tswitchReceiptNoAutoGenerate_Toggled(tswitchReceiptNoAutoGenerate, null);
            //--

            ledSaleInvoiceNoPrefix.Properties.ValueMember = "SaleInvoiceNoPrefixID";
            ledSaleInvoiceNoPrefix.Properties.DisplayMember = "SIPrefixName";
            ledSaleInvoiceNoPrefix.Properties.DataSource = dsSaleInvoiceNoPrefix;

            ledSaleOrderNoPrefix.Properties.ValueMember = "SaleOrderNoPrefixID";
            ledSaleOrderNoPrefix.Properties.DisplayMember = "SOPrefixName";
            ledSaleOrderNoPrefix.Properties.DataSource = dsSaleOrderNoPrefix;

            ledSaleReturnNoPrefix.Properties.ValueMember = "SaleReturnNoPrefixID";
            ledSaleReturnNoPrefix.Properties.DisplayMember = "PrefixName";
            ledSaleReturnNoPrefix.Properties.DataSource = dsSaleReturnNoPrefix;

            ledPurchaseRecPrefix.Properties.ValueMember = "PurchaseReceiptNoPrefixID";
            ledPurchaseRecPrefix.Properties.DisplayMember = "PrefixName";
            ledPurchaseRecPrefix.Properties.DataSource = dsPurchaseReceiptNoPrefix;

            ledPurchaseReturnNoPrefix.Properties.ValueMember = "PurchaseReturnNoPrefixID";
            ledPurchaseReturnNoPrefix.Properties.DisplayMember = "PrefixName";
            ledPurchaseReturnNoPrefix.Properties.DataSource = dsPurchaseReturnNoPrefix;

            ledReceiptNoPrefix.Properties.ValueMember = "ReceiptNoPrefixID";
            ledReceiptNoPrefix.Properties.DisplayMember = "PrefixName";
            ledReceiptNoPrefix.Properties.DataSource = dsReceiptNoPrefix;

            lookUpSaleInvoiceDefaultCashCustomer.Properties.ValueMember = "CustomerID";
            lookUpSaleInvoiceDefaultCashCustomer.Properties.DisplayMember = "CustomerName";
            lookUpSaleInvoiceDefaultCashCustomer.Properties.DataSource = dsCustomer;

            /// Sale Invoie Print
            lookupReports_SInvP_DefaultInvPrintingFormat.Properties.DisplayMember = "FormatName";
            lookupReports_SInvP_DefaultInvPrintingFormat.Properties.ValueMember = "SaleInvoicePrintFormatID";
            lookupReports_SInvP_DefaultInvPrintingFormat.Properties.DataSource = Model.ERP.Transaction.Sales.SaleInvoice.SaleInvoicePrintingFormatViewModel.GetGeneraliseFormatList();

            lookupSale_RoundOffAddLessItem.Properties.DisplayMember = "AddnitionalItemName";
            lookupSale_RoundOffAddLessItem.Properties.ValueMember = "AdditionalItemID";
            lookupSale_RoundOffAddLessItem.Properties.DataSource = dsAddLessItems;

            InitializeSettingValues();

            base.OnAssignFormValues();
        }

        protected override void OnClearValues()
        {
            base.OnClearValues();
            InitializeSettingValues();
        }

        void InitializeSettingValues()
        {
            #region Level 1
            #region Sale Invoice
            cmbSaleInvoiceMemoTypes.SelectedIndex = (int)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceMemoTypeApplies;
            cmbSaleInvoiceDefaultMemoType.SelectedIndex = (int)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultMemoType;

            tswitchSaleInvoiceAskCustomer.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAskCustomer;
            lookUpSaleInvoiceDefaultCashCustomer.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultCustomerID;

            tswitchSaleInvoiceNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNo;
            tswitchSaleInvoiceNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoPrefix;
            ledSaleInvoiceNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleInvoiceNoPrefixID;
            tswitchSaleInvoiceNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAutoGenerate;
            tokenEditSaleInvoiceNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoSeries ?? "";
            tswitchSaleInvoiceNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceNoAllowEdit;

            string[] ChallanElemets = (Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceChallanInfo ?? "").Split(',');
            IEnumerable<CheckedListBoxItem> CheckedListItems = chkblistSaleInvoiceChallanDetails.Items.Cast<CheckedListBoxItem>();
            
            foreach(string ChE in ChallanElemets)
            {
                int ChallElementID = 0;
                if(int.TryParse(ChE, out ChallElementID))
                {
                    CheckedListBoxItem Item =  CheckedListItems.FirstOrDefault(r => r.Value != null && (int)r.Value == ChallElementID);
                    Item.CheckState = CheckState.Checked;
                }
            }

            tswitchSaleInvoiceAskDisptchInfo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDispatchInfo;

            #region Product details
            tswitchSaleInvoiceProdSelByProductCode.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductCode;
            tswitchSaleInvoiceProdSelByBarcode.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByBarcode;
            tswitchSaleInvoiceProdSelByProductName.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceProductSelectionByProductName;
            tswitchSaleInvoiceAllowEditProductDescr.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditProductDescr;
            tswitchSaleInvoiceCursorStopOnQuan.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnQuan;
            txtSaleInvoiceDefaultQuan.Text = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceDefaultQuan.ToString();
            tswitchSaleInvoiceCursorStopOnRate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnRate;
            tswitchSaleInvoiceAllowEditRate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditRate;
            tswitchSaleInvoiceAddDiscountColumn.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddDiscountColumn;
            tswitchSaleInvoiceCursorStopOnDiscount.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnDisc;
            tswitchSaleInvoiceAddTaxColumn.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddTaxColumn;
            tswitchSaleInvoiceCursorStopOnTax.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnTax;
            tswitchSaleInvoiceAddUnitColumn.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAddUnitColumn;
            tswitchSaleInvoiceCursorStopOnUnit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceCursorStopOnUnit;
            tswitchSaleInvoiceAllowEditAmt.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceAllowEditGAmt;
            cmbSaleInvoiceAmtEditReverseEffectOn.SelectedIndex = (int)Model.CommonProperties.LoginInfo.SoftwareSettings.SaleInvoiceGAmtEditReverseEffectOn;
            #endregion

            tswitchSale_ApplyRoundOff.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ApplyRoundOff;
            lookupSale_RoundOffAddLessItem.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.RoundOffAddLessID;

            #region Sale Invoice Print
            lookupReports_SInvP_DefaultInvPrintingFormat.EditValue = CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintDefaultFormatNo;
            txtCustomSaleInvoiceFormatFileName.Text = CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintCustomFormatFileName ?? "";
            tswitchReports_SInv_IsDirectPrint.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintIsDirectPrint;
            txtReports_Sinv_DiectPrint_NoCopies.EditValue = null;
            txtReports_Sinv_DiectPrint_NoCopies.EditValue = CommonProperties.LoginInfo.SoftwareSettings.SaleInvoicePrintNoCopies.ToString();

            #endregion
            #endregion

            #region Sale Order
            tswitchActivateSaleOrder.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ActivateSaleOrder;

            tswitchSaleOrderNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNo;
            tswitchSaleOrderNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoPrefix;
            ledSaleOrderNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleOrderNoPrefixID;
            tswitchSaleOrderNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoAutoGenerate;
            tokenEditSaleOrderNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoSeries ?? "";
            tswitchSaleOrderNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleOrderNoAllowEdit;
            #endregion

            #region Sale Return
            tswitchSaleReturnNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNo;
            tswitchSaleReturnNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoPrefix;
            ledSaleReturnNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultSaleReturnNoPrefixID;
            tswitchSaleReturnNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAutoGenerate;
            tokenEditSaleReturnNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoSeries ?? "";
            tswitchSaleReturnNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.SaleReturnNoAllowEdit;
            #endregion

            #region Purchase

            tswitchPurchaseBillReceiptDate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseBillReceiptDate;
            tswitchPurchaseBillStopCursorOnReceiptDate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseBillStopCursorOnReceiptDate;

            #region Purchase Receipt No
            tswitchPurchaseRecNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNo;
            tswitchPurchaseRecNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoPrefix;
            ledPurchaseRecPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultPurchaseReceiptNoPrefixID;
            tswitchPurchaseRecNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoAutoGenerate;
            tokenEditPurchaseRecNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoSeries ?? "";
            tswitchPurchaseRecNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReceiptNoAllowEdit;
            #endregion

            #endregion

            #region Purchase Return
            tswitchPurchaseReturnNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNo;
            tswitchPurchaseReturnNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoPrefix;
            ledPurchaseReturnNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultPurchaseReturnNoPrefixID;
            tswitchPurchaseReturnNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoAutoGenerate;
            tokenEditPurchaseReturnNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoSeries ?? "";
            tswitchPurchaseReturnNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.PurchaseReturnNoAllowEdit;
            #endregion

            #region Receipt
            #region Receipt No.
            tswitchReceiptNo.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNo;
            tswitchReceiptNoPrefix.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoPrefix;
            ledReceiptNoPrefix.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.DefaultReceiptNoPrefixID;
            tswitchReceiptNoAutoGenerate.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAutoGenerate;
            tokenEditReceiptNoSeries.EditValue = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoSeries ?? "";
            tswitchReceiptNoAllowEdit.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ReceiptNoAllowEdit;
            #endregion

            #region Receipt Print
            tswitchReports_Receipt_DirectPrint.IsOn = CommonProperties.LoginInfo.SoftwareSettings.ReceiptPrintIsDirectPrint;
            txtReports_Receipt_DirectPrintCopies.EditValue = null;
            txtReports_Receipt_DirectPrintCopies.EditValue = CommonProperties.LoginInfo.SoftwareSettings.ReceiptPrintNoCopies.ToString();
            #endregion
            #endregion

            #region Product Master
            tswitchMaintainProductMaster.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.MaintainProducts;

            tswitchProductCode.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ProductCode;
            tswitchProductBarcode.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.ProductBarcode;
            tswitchProductHSNCode.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.HSNCode;
            #endregion

            #region SMS
            tswitchSMS_Activate.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSActivated;
            txtSMS_AuthKey.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSAuthKey;

            tswitchSMS_SendSMSinSaleInvoice.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleInvoice;
            txtSMS_SaleInvoiceSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceSenderID;
            memoSms_SaleInvoiceTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleInvoiceTemplate;

            tswitchSMS_SendSMSinSaleReturn.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleReturn;
            txtSMS_SaleReturnSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnSenderID;
            memoSms_SaleReturnTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleReturnTemplate;

            tswitchSMS_SendSMSinSaleOrder.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInSaleOrder;
            txtSMS_SaleOrderSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleOrderSenderID;
            memoSms_SaleOrderTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSSaleOrderTemplate;

            tswitchSMS_SendSMSinPurchaseBill.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPurchaseBill;
            txtSMS_PurchaseBillSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPurchaseBillSenderID;
            memoSms_PurchaseBillTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPurchaseBillTemplate;

            tswitchSMS_SendSMSinPurchaseReturn.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPurchaseReturn;
            txtSMS_PurchaseReturnSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPurchaseReturnSenderID;
            memoSms_PurchaseReturnTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPurchaseReturnTemplate;

            tswitchSMS_SendSMSInReciept.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInReceipt;
            txtSMS_ReceiptSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSReceiptSenderID;
            memoSMS_RecieptTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSReceiptTemplate;

            tswitchSMS_SendSMSInPayment.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInPurchaseReturn;
            txtSMS_PaymentSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentSenderID;
            memoSms_PaymentTemplate.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSPaymentTemplate;

            tswitchSMS_SendSMSinCBR.IsOn = CommonProperties.LoginInfo.SoftwareSettings.SMSSendInCustomerBalanceReport;
            txtSMS_CBRSenderID.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSCustomerBalanceReportSenderID;
            memoSms_CBRTemp.Text = CommonProperties.LoginInfo.SoftwareSettings.SMSCustomerBalanceReportTemplate;

            lcgSMSTemplate.Visibility = (tswitchSMS_Activate.IsOn ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            #endregion

            #endregion

            #region Level 0
            tswitchUserAutoLogin.IsOn = Model.CommonProperties.LoginInfo.SoftwareSettings.AutoUserLogin;

            #endregion
        }

        protected override void OnSaveRecord(SavingParemeter Paras)
        {
            ApplicationSettingsViewModel ApplicationSetting = CommonProperties.LoginInfo.SoftwareSettings;

            #region Level 0
            ApplicationSetting.AutoUserLogin = tswitchUserAutoLogin.IsOn;
            #endregion

            #region Level 1

            #region Sale Invoice
            ApplicationSetting.SaleInvoiceMemoTypeApplies = (eSaleInvoiceMemoTypeApplies) cmbSaleInvoiceMemoTypes.SelectedIndex;

            eSaleInvoiceMemoTypeApplies MemoTypeApplies = (eSaleInvoiceMemoTypeApplies)cmbSaleInvoiceMemoTypes.SelectedIndex;
            ApplicationSetting.SaleInvoiceDefaultMemoType = (MemoTypeApplies == eSaleInvoiceMemoTypeApplies.Cash ? Alit.Marker.Model.TransactionsCommon.eMemoType.Cash :
                (MemoTypeApplies == eSaleInvoiceMemoTypeApplies.Credit ? Alit.Marker.Model.TransactionsCommon.eMemoType.Credit :
                (Alit.Marker.Model.TransactionsCommon.eMemoType)(cmbSaleInvoiceDefaultMemoType.SelectedIndex)));

            ApplicationSetting.SaleInvoiceAskCustomer = tswitchSaleInvoiceAskCustomer.IsOn;
            ApplicationSetting.SaleInvoiceDefaultCustomerID = (long?)lookUpSaleInvoiceDefaultCashCustomer.EditValue;

            ApplicationSetting.SaleInvoiceNo = tswitchSaleInvoiceNo.IsOn;
            ApplicationSetting.SaleInvoiceNoAutoGenerate = tswitchSaleInvoiceNoAutoGenerate.IsOn;
            ApplicationSetting.SaleInvoiceNoPrefix = tswitchSaleInvoiceNoPrefix.IsOn;
            ApplicationSetting.DefaultSaleInvoiceNoPrefixID = (long?)ledSaleInvoiceNoPrefix.EditValue;
            ApplicationSetting.SaleInvoiceNoSeries = (tokenEditSaleInvoiceNoSeries.EditValue == null ? "" : tokenEditSaleInvoiceNoSeries.EditValue.ToString());
            ApplicationSetting.SaleInvoiceNoAllowEdit = tswitchSaleInvoiceNoAllowEdit.IsOn;

            string ChallanInfos = "";
            foreach (CheckedListBoxItem Item in chkblistSaleInvoiceChallanDetails.CheckedItems)
            {
                ChallanInfos += (ChallanInfos.Length > 0 ? "," : "") + Item.Value.ToString();
            }

            ApplicationSetting.SaleInvoiceChallanInfo = ChallanInfos;

            ApplicationSetting.SaleInvoiceDispatchInfo = tswitchSaleInvoiceAskDisptchInfo.IsOn;

            #region Product Selection
            ApplicationSetting.SaleInvoiceProductSelectionByProductCode = tswitchSaleInvoiceProdSelByProductCode.IsOn;
            ApplicationSetting.SaleInvoiceProductSelectionByBarcode = tswitchSaleInvoiceProdSelByBarcode.IsOn;
            ApplicationSetting.SaleInvoiceProductSelectionByProductName = tswitchSaleInvoiceProdSelByProductName.IsOn;
            ApplicationSetting.SaleInvoiceAllowEditProductDescr = tswitchSaleInvoiceAllowEditProductDescr.IsOn;
            ApplicationSetting.SaleInvoiceCursorStopOnQuan = tswitchSaleInvoiceCursorStopOnQuan.IsOn;
            decimal DefaultQuan = 0;
            decimal.TryParse(txtSaleInvoiceDefaultQuan.Text, out DefaultQuan);
            ApplicationSetting.SaleInvoiceDefaultQuan = DefaultQuan;
            ApplicationSetting.SaleInvoiceCursorStopOnRate = tswitchSaleInvoiceCursorStopOnRate.IsOn;
            ApplicationSetting.SaleInvoiceAllowEditRate = tswitchSaleInvoiceAllowEditRate.IsOn;
            ApplicationSetting.SaleInvoiceAddDiscountColumn = tswitchSaleInvoiceAddDiscountColumn.IsOn;
            ApplicationSetting.SaleInvoiceCursorStopOnDisc = tswitchSaleInvoiceCursorStopOnDiscount.IsOn;
            ApplicationSetting.SaleInvoiceAddTaxColumn = tswitchSaleInvoiceAddTaxColumn.IsOn;
            ApplicationSetting.SaleInvoiceCursorStopOnTax = tswitchSaleInvoiceCursorStopOnTax.IsOn;
            ApplicationSetting.SaleInvoiceAddUnitColumn = tswitchSaleInvoiceAddUnitColumn.IsOn;
            ApplicationSetting.SaleInvoiceCursorStopOnUnit = tswitchSaleInvoiceCursorStopOnUnit.IsOn;
            ApplicationSetting.SaleInvoiceAllowEditGAmt = tswitchSaleInvoiceAllowEditAmt.IsOn;
            ApplicationSetting.SaleInvoiceGAmtEditReverseEffectOn = (eSaleinvoiceGAmtEditReverseEffectOn) cmbSaleInvoiceAmtEditReverseEffectOn.SelectedIndex;
            #endregion

            ApplicationSetting.ApplyRoundOff = tswitchSale_ApplyRoundOff.IsOn;
            ApplicationSetting.RoundOffAddLessID = (long?)lookupSale_RoundOffAddLessItem.EditValue;

            #region Sale Invoice Print

            ApplicationSetting.SaleInvoicePrintDefaultFormatNo = (long?)lookupReports_SInvP_DefaultInvPrintingFormat.EditValue ?? (long)Model.ERP.Transaction.Sales.SaleInvoice.eInvoiceFormats.Standard_A4;
            ApplicationSetting.SaleInvoicePrintCustomFormatFileName = txtCustomSaleInvoiceFormatFileName.Text ?? "";
            ApplicationSetting.SaleInvoicePrintIsDirectPrint = tswitchReports_SInv_IsDirectPrint.IsOn;
            int NoCopies = 0;
            int.TryParse(txtReports_Sinv_DiectPrint_NoCopies.Text, out NoCopies);
            ApplicationSetting.SaleInvoicePrintNoCopies = Math.Max(NoCopies, 1);
            #endregion
            #endregion

            #region Sale Order


            #region Sale Order No
            ApplicationSetting.ActivateSaleOrder = tswitchActivateSaleOrder.IsOn;
            ApplicationSetting.SaleOrderNo = tswitchSaleOrderNo.IsOn;
            ApplicationSetting.SaleOrderNoAutoGenerate = tswitchSaleOrderNoAutoGenerate.IsOn;
            ApplicationSetting.SaleOrderNoPrefix = tswitchSaleOrderNoPrefix.IsOn;
            ApplicationSetting.DefaultSaleOrderNoPrefixID = (long?)ledSaleOrderNoPrefix.EditValue;
            ApplicationSetting.SaleOrderNoSeries = (tokenEditSaleOrderNoSeries.EditValue == null ? "" : tokenEditSaleOrderNoSeries.EditValue.ToString());
            ApplicationSetting.SaleOrderNoAllowEdit = tswitchSaleOrderNoAllowEdit.IsOn;
            #endregion -- End Sale Order No

            #endregion -- End Sale ORder

            #region Sale Return
            ApplicationSetting.SaleReturnNo = tswitchSaleReturnNo.IsOn;
            ApplicationSetting.SaleReturnNoAutoGenerate = tswitchSaleReturnNoAutoGenerate.IsOn;
            ApplicationSetting.SaleReturnNoPrefix = tswitchSaleReturnNoPrefix.IsOn;
            ApplicationSetting.DefaultSaleReturnNoPrefixID = (long?)ledSaleReturnNoPrefix.EditValue;
            ApplicationSetting.SaleReturnNoSeries = (tokenEditSaleReturnNoSeries.EditValue == null ? "" : tokenEditSaleReturnNoSeries.EditValue.ToString());
            ApplicationSetting.SaleReturnNoAllowEdit = tswitchSaleReturnNoAllowEdit.IsOn;
            #endregion

            #region Purchase 

            ApplicationSetting.PurchaseBillReceiptDate = tswitchPurchaseBillReceiptDate.IsOn;
            ApplicationSetting.PurchaseBillStopCursorOnReceiptDate = tswitchPurchaseBillStopCursorOnReceiptDate.IsOn;

            #region Purchase Receipt No.
            ApplicationSetting.PurchaseReceiptNo = tswitchPurchaseRecNo.IsOn;
            ApplicationSetting.PurchaseReceiptNoAutoGenerate = tswitchPurchaseRecNoAutoGenerate.IsOn;
            ApplicationSetting.PurchaseReceiptNoPrefix = tswitchPurchaseRecNoPrefix.IsOn;
            ApplicationSetting.DefaultPurchaseReceiptNoPrefixID = (long?)ledPurchaseRecPrefix.EditValue;
            ApplicationSetting.PurchaseReceiptNoSeries = (tokenEditPurchaseRecNoSeries.EditValue == null ? "" : tokenEditPurchaseRecNoSeries.EditValue.ToString());
            ApplicationSetting.PurchaseReceiptNoAllowEdit = tswitchPurchaseRecNoAllowEdit.IsOn;
            #endregion

            #endregion

            #region Purchase Return
            ApplicationSetting.PurchaseReturnNo = tswitchPurchaseReturnNo.IsOn;
            ApplicationSetting.PurchaseReturnNoAutoGenerate = tswitchPurchaseReturnNoAutoGenerate.IsOn;
            ApplicationSetting.PurchaseReturnNoPrefix = tswitchPurchaseReturnNoPrefix.IsOn;
            ApplicationSetting.DefaultPurchaseReturnNoPrefixID = (long?)ledPurchaseReturnNoPrefix.EditValue;
            ApplicationSetting.PurchaseReturnNoSeries = (tokenEditPurchaseReturnNoSeries.EditValue == null ? "" : tokenEditPurchaseReturnNoSeries.EditValue.ToString());
            ApplicationSetting.PurchaseReturnNoAllowEdit = tswitchPurchaseReturnNoAllowEdit.IsOn;
            #endregion

            #region Receipt
            #region Receipt No
            ApplicationSetting.ReceiptNo = tswitchReceiptNo.IsOn;
            ApplicationSetting.ReceiptNoAutoGenerate = tswitchReceiptNoAutoGenerate.IsOn;
            ApplicationSetting.ReceiptNoPrefix = tswitchReceiptNoPrefix.IsOn;
            ApplicationSetting.DefaultReceiptNoPrefixID = (long?)ledReceiptNoPrefix.EditValue;
            ApplicationSetting.ReceiptNoSeries = (tokenEditReceiptNoSeries.EditValue == null ? "" : tokenEditReceiptNoSeries.EditValue.ToString());
            ApplicationSetting.ReceiptNoAllowEdit = tswitchReceiptNoAllowEdit.IsOn;
            #endregion

            #region Receipt Print
            ApplicationSetting.ReceiptPrintIsDirectPrint = tswitchReports_Receipt_DirectPrint.IsOn;
            NoCopies = 0;
            int.TryParse(txtReports_Receipt_DirectPrintCopies.Text, out NoCopies);
            ApplicationSetting.ReceiptPrintNoCopies = Math.Max(NoCopies, 1);
            #endregion
            #endregion

            #region Product Master
            ApplicationSetting.MaintainProducts = tswitchMaintainProductMaster.IsOn;
            ApplicationSetting.ProductCode = tswitchProductCode.IsOn;
            ApplicationSetting.ProductBarcode = tswitchProductBarcode.IsOn;
            ApplicationSetting.HSNCode = tswitchProductHSNCode.IsOn;
            #endregion

            #region Report

            
            #endregion

            #region SMS
            ApplicationSetting.SMSActivated = tswitchSMS_Activate.IsOn;
            ApplicationSetting.SMSAuthKey = txtSMS_AuthKey.Text;

            ApplicationSetting.SMSSendInSaleInvoice = tswitchSMS_SendSMSinSaleInvoice.IsOn;
            ApplicationSetting.SMSSaleInvoiceSenderID = txtSMS_SaleInvoiceSenderID.Text;
            ApplicationSetting.SMSSaleInvoiceTemplate = memoSms_SaleInvoiceTemplate.Text;

            ApplicationSetting.SMSSendInSaleReturn = tswitchSMS_SendSMSinSaleReturn.IsOn;
            ApplicationSetting.SMSSaleReturnSenderID = txtSMS_SaleReturnSenderID.Text;
            ApplicationSetting.SMSSaleReturnTemplate = memoSms_SaleReturnTemplate.Text;

            ApplicationSetting.SMSSendInSaleOrder = tswitchSMS_SendSMSinSaleOrder.IsOn;
            ApplicationSetting.SMSSaleOrderSenderID = txtSMS_SaleOrderSenderID.Text;
            ApplicationSetting.SMSSaleOrderTemplate = memoSms_SaleOrderTemplate.Text;

            ApplicationSetting.SMSSendInPurchaseBill = tswitchSMS_SendSMSinPurchaseBill.IsOn;
            ApplicationSetting.SMSPurchaseBillSenderID = txtSMS_PurchaseBillSenderID.Text;
            ApplicationSetting.SMSPurchaseBillTemplate = memoSms_PurchaseBillTemplate.Text;

            ApplicationSetting.SMSSendInPurchaseReturn = tswitchSMS_SendSMSinPurchaseReturn.IsOn;
            ApplicationSetting.SMSPurchaseReturnSenderID = txtSMS_PurchaseReturnSenderID.Text;
            ApplicationSetting.SMSPurchaseReturnTemplate = memoSms_PurchaseReturnTemplate.Text;

            ApplicationSetting.SMSSendInReceipt = tswitchSMS_SendSMSInReciept.IsOn;
            ApplicationSetting.SMSReceiptSenderID = txtSMS_ReceiptSenderID.Text;
            ApplicationSetting.SMSReceiptTemplate = memoSMS_RecieptTemplate.Text;

            ApplicationSetting.SMSSendInPayment = tswitchSMS_SendSMSInPayment.IsOn;
            ApplicationSetting.SMSPaymentSenderID = txtSMS_PaymentSenderID.Text;
            ApplicationSetting.SMSPaymentTemplate = memoSms_PaymentTemplate.Text;

            ApplicationSetting.SMSSendInCustomerBalanceReport = tswitchSMS_SendSMSinCBR.IsOn;
            ApplicationSetting.SMSCustomerBalanceReportSenderID = txtSMS_CBRSenderID.Text;
            ApplicationSetting.SMSCustomerBalanceReportTemplate = memoSms_CBRTemp.Text;
            #endregion

            #endregion

            Paras.SavingResult = DALObject.SaveSettings(ApplicationSetting, CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
            //Model.CommonProperties.LoginInfo.SoftwareSettings = DALObject.GetSetting();
            base.OnSaveRecord(Paras);
        }

        protected override void OnAfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                Navigation.frmNavigationDashboard.DashBoard.ApplySettingsOnMenus();
                if (Model.CommonProperties.LoginInfo.SoftwareSettings.SMSActivated)
                {
                    SMS.SMSHandler.UpdateDisplaySMSBalance();
                }
                this.Close();
            }
            base.OnAfterSaving(Paras);
        }

        #region Sale Invoice
        private void tswitchSaleInvoiceNo_Toggled(object sender, EventArgs e)
        {
            if(tswitchSaleInvoiceNo.IsOn)
            {
                tswitchSaleInvoiceNoAutoGenerate.Enabled = true;
                tswitchSaleInvoiceNoPrefix.Enabled = true;
                tswitchSaleInvoiceNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchSaleInvoiceNoAutoGenerate.IsOn = false;
                tswitchSaleInvoiceNoPrefix.IsOn = false;
                tswitchSaleInvoiceNoAllowEdit.IsOn = false;

                tswitchSaleInvoiceNoAutoGenerate.Enabled = false;
                tswitchSaleInvoiceNoPrefix.Enabled = false;
                tswitchSaleInvoiceNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchSaleInvoiceNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if(tswitchSaleInvoiceNoAutoGenerate.IsOn == false)
            {
                tswitchSaleInvoiceNoAllowEdit.IsOn = true;
                tswitchSaleInvoiceNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchSaleInvoiceNoAllowEdit.IsOn = false;
                tswitchSaleInvoiceNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchSaleInvoiceNoPrefix_Toggled(object sender, EventArgs e)
        {
            if(tswitchSaleInvoiceNoPrefix.IsOn)
            {
                if (!tokenEditSaleInvoiceNoSeries.Properties.Tokens.Contains(SaleInvoiceNoSeriesPrefixToken))
                {
                    tokenEditSaleInvoiceNoSeries.Properties.Tokens.Add(SaleInvoiceNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditSaleInvoiceNoSeries.Properties.Tokens.Remove(SaleInvoiceNoSeriesPrefixToken);
                
                if(tokenEditSaleInvoiceNoSeries.SelectedItems.Contains(SaleInvoiceNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditSaleInvoiceNoSeries.SelectedItems.Clone();
                    tokenEditSaleInvoiceNoSeries.ResetText();


                    string NewValue = "";
                    foreach(TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != SaleInvoiceNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditSaleInvoiceNoSeries.EditValue = NewValue;
                }
                
            }
        }

        private void cmbSaleInvoiceMemoTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((eSaleInvoiceMemoTypeApplies)cmbSaleInvoiceMemoTypes.SelectedIndex) == eSaleInvoiceMemoTypeApplies.CashCreditBoth)
            {
                lciSaleInvoiceDefaultMemoType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciSaleInvoiceDefaultMemoType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            if ((eSaleInvoiceMemoTypeApplies)cmbSaleInvoiceMemoTypes.SelectedIndex == eSaleInvoiceMemoTypeApplies.Credit)
            {
                tswitchSaleInvoiceAskCustomer.Enabled = false;
                tswitchSaleInvoiceAskCustomer.IsOn = true;
            }
            else
            {
                tswitchSaleInvoiceAskCustomer.Enabled = true;
            }

        }

        private void lookUpSaleInvoiceDefaultCashCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpSaleInvoiceDefaultCashCustomer.EditValue == null)
            {
                ErrorProvider.SetError(lookUpSaleInvoiceDefaultCashCustomer, "Please select sale invoice default cash customer");
            }
            else
            {
                ErrorProvider.SetError(lookUpSaleInvoiceDefaultCashCustomer, "");
            }
        }

        private void tswitchMaintainProductMaster_Toggled(object sender, EventArgs e)
        {
            DevExpress.XtraLayout.Utils.LayoutVisibility lciVisibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            if(!tswitchMaintainProductMaster.IsOn)
            {
                tswitchProductCode.IsOn = false;
                tswitchProductBarcode.IsOn = false;

                tswitchSaleInvoiceProdSelByProductCode.IsOn = false;
                tswitchSaleInvoiceProdSelByBarcode.IsOn = false;
                tswitchSaleInvoiceProdSelByProductName.IsOn = false;
                tswitchSaleInvoiceAllowEditProductDescr.IsOn = true;
                tswitchSaleInvoiceCursorStopOnRate.IsOn = true;
                tswitchSaleInvoiceAllowEditRate.IsOn = true;
                tswitchSaleInvoiceCursorStopOnDiscount.IsOn = true;
                tswitchSaleInvoiceCursorStopOnTax.IsOn = true;

                lciVisibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciVisibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            lcgProductSettings.Visibility = lciVisibility;


            lciSaleInvoiceProdSelByProductCode.Visibility = lciVisibility;

            lciSaleInvoiceProdSelByBarcode.Visibility = lciVisibility;

            lciSaleInvoiceProdSelByProductName.Visibility = lciVisibility;

            lciSaleInvoiceAllowEditProductDescr.Visibility = lciVisibility;

            lciSaleInvoiceCursorStopOnRate.Visibility = lciVisibility;

            lciSaleInvoiceAllowEditRate.Visibility = lciVisibility;

            lciSaleInvoiceCursorStopOnDiscount.Visibility = lciVisibility;

            lciSaleInvoiceCursorStopOnTax.Visibility = lciVisibility;

            lcgSaleInvoiceProductSelectionBy.Visibility = lciVisibility;
        }

        private void tswitchSaleInvoiceAddDiscountColumn_Toggled(object sender, EventArgs e)
        {
            if(!tswitchSaleInvoiceAddDiscountColumn.IsOn)
            {
                tswitchSaleInvoiceCursorStopOnDiscount.IsOn = false;
                lciSaleInvoiceCursorStopOnDiscount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciSaleInvoiceCursorStopOnDiscount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void tswitchSaleInvoiceAddTaxColumn_Toggled(object sender, EventArgs e)
        {
            if(!tswitchSaleInvoiceAddTaxColumn.IsOn)
            {
                tswitchSaleInvoiceCursorStopOnTax.IsOn = false;
                lciSaleInvoiceCursorStopOnTax.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciSaleInvoiceCursorStopOnTax.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void tswitchProductCode_Toggled(object sender, EventArgs e)
        {
            if(!tswitchProductCode.IsOn)
            {
                tswitchSaleInvoiceProdSelByProductCode.IsOn = false;
                lciSaleInvoiceProdSelByProductCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciSaleInvoiceProdSelByProductCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void tswitchProductBarcode_Toggled(object sender, EventArgs e)
        {
            if(!tswitchProductBarcode.IsOn)
            {
                tswitchSaleInvoiceProdSelByBarcode.IsOn = false;
                lciSaleInvoiceProdSelByBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciSaleInvoiceProdSelByBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void tswitchSaleInvoiceAddUnitColumn_Toggled(object sender, EventArgs e)
        {
            if (!tswitchSaleInvoiceAddUnitColumn.IsOn)
            {
                tswitchSaleInvoiceCursorStopOnUnit.IsOn = false;
                lciSaleInvoiceCursorStopOnUnit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                lciSaleInvoiceCursorStopOnUnit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void tswitchSaleInvoiceAllowEditAmt_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleInvoiceAllowEditAmt.IsOn)
            {
                lciSaleInvoiceAmtEditReverseEffectOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciSaleInvoiceAmtEditReverseEffectOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void tswitchSale_ApplyRoundOff_Toggled(object sender, EventArgs e)
        {
            if (tswitchSale_ApplyRoundOff.IsOn)
            {
                lciRoundOffItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciRoundOffItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void lookupSale_RoundOffAddLessItem_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSale_ApplyRoundOff.IsOn && lookupSale_RoundOffAddLessItem.EditValue == null)
            {
                ErrorProvider.SetError(lookupSale_RoundOffAddLessItem, "Please select round off item.");
            }
            else
            {
                ErrorProvider.SetError(lookupSale_RoundOffAddLessItem, "");
            }
        }

        private void lookupReports_SInvP_DefaultInvPrintingFormat_EditValueChanged(object sender, EventArgs e)
        {
            long formatno = ((long?)lookupReports_SInvP_DefaultInvPrintingFormat.EditValue ?? 0);
            lcgCustomSaleInvoicePrintFileName.Visibility = (((Model.ERP.Transaction.Sales.SaleInvoice.eInvoiceFormats)formatno) == Model.ERP.Transaction.Sales.SaleInvoice.eInvoiceFormats.Customized ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        private void btnBrowseCustomSaleInvoicePrintFormat_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "REPX|*.repx";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCustomSaleInvoiceFormatFileName.Text = ofd.FileName;
            }
        }
        #endregion

        #region Sale Order
        private void tswitchActivateSaleOrder_Toggled(object sender, EventArgs e)
        {
            lcgSaleOrderNo.Visibility = (tswitchActivateSaleOrder.IsOn ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        private void tswitchSaleOrderNo_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleOrderNo.IsOn)
            {
                tswitchSaleOrderNoAutoGenerate.Enabled = true;
                tswitchSaleOrderNoPrefix.Enabled = true;
                tswitchSaleOrderNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchSaleOrderNoAutoGenerate.IsOn = false;
                tswitchSaleOrderNoPrefix.IsOn = false;
                tswitchSaleOrderNoAllowEdit.IsOn = false;

                tswitchSaleOrderNoAutoGenerate.Enabled = false;
                tswitchSaleOrderNoPrefix.Enabled = false;
                tswitchSaleOrderNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchSaleOrderNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleOrderNoAutoGenerate.IsOn == false)
            {
                tswitchSaleOrderNoAllowEdit.IsOn = true;
                tswitchSaleOrderNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchSaleOrderNoAllowEdit.IsOn = false;
                tswitchSaleOrderNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchSaleOrderNoPrefix_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleOrderNoPrefix.IsOn)
            {
                if (!tokenEditSaleOrderNoSeries.Properties.Tokens.Contains(SaleOrderNoSeriesPrefixToken))
                {
                    tokenEditSaleOrderNoSeries.Properties.Tokens.Add(SaleOrderNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditSaleOrderNoSeries.Properties.Tokens.Remove(SaleOrderNoSeriesPrefixToken);

                if (tokenEditSaleOrderNoSeries.SelectedItems.Contains(SaleOrderNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditSaleOrderNoSeries.SelectedItems.Clone();
                    tokenEditSaleOrderNoSeries.ResetText();


                    string NewValue = "";
                    foreach (TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != SaleOrderNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditSaleOrderNoSeries.EditValue = NewValue;
                }

            }
        }

        
        #endregion

        #region Sale Return
        private void tswitchSaleReturnNo_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleReturnNo.IsOn)
            {
                tswitchSaleReturnNoAutoGenerate.Enabled = true;
                tswitchSaleReturnNoPrefix.Enabled = true;
                tswitchSaleReturnNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchSaleReturnNoAutoGenerate.IsOn = false;
                tswitchSaleReturnNoPrefix.IsOn = false;
                tswitchSaleReturnNoAllowEdit.IsOn = false;

                tswitchSaleReturnNoAutoGenerate.Enabled = false;
                tswitchSaleReturnNoPrefix.Enabled = false;
                tswitchSaleReturnNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchSaleReturnNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleReturnNoAutoGenerate.IsOn == false)
            {
                tswitchSaleReturnNoAllowEdit.IsOn = true;
                tswitchSaleReturnNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchSaleReturnNoAllowEdit.IsOn = false;
                tswitchSaleReturnNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchSaleReturnNoPrefix_Toggled(object sender, EventArgs e)
        {
            if (tswitchSaleReturnNoPrefix.IsOn)
            {
                if (!tokenEditSaleReturnNoSeries.Properties.Tokens.Contains(SaleReturnNoSeriesPrefixToken))
                {
                    tokenEditSaleReturnNoSeries.Properties.Tokens.Add(SaleReturnNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditSaleReturnNoSeries.Properties.Tokens.Remove(SaleReturnNoSeriesPrefixToken);

                if (tokenEditSaleReturnNoSeries.SelectedItems.Contains(SaleReturnNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditSaleReturnNoSeries.SelectedItems.Clone();
                    tokenEditSaleReturnNoSeries.ResetText();


                    string NewValue = "";
                    foreach (TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != SaleReturnNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditSaleReturnNoSeries.EditValue = NewValue;
                }

            }
        }
        #endregion

        #region Purchase Receipt
        private void tswitchPurchaseRecNo_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseRecNo.IsOn)
            {
                tswitchPurchaseRecNoAutoGenerate.Enabled = true;
                tswitchPurchaseRecNoPrefix.Enabled = true;
                tswitchPurchaseRecNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchPurchaseRecNoAutoGenerate.IsOn = false;
                tswitchPurchaseRecNoPrefix.IsOn = false;
                tswitchPurchaseRecNoAllowEdit.IsOn = false;

                tswitchPurchaseRecNoAutoGenerate.Enabled = false;
                tswitchPurchaseRecNoPrefix.Enabled = false;
                tswitchPurchaseRecNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchPurchaseRecNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseRecNoAutoGenerate.IsOn == false)
            {
                tswitchPurchaseRecNoAllowEdit.IsOn = true;
                tswitchPurchaseRecNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchPurchaseRecNoAllowEdit.IsOn = false;
                tswitchPurchaseRecNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchPurchaseRecNoPrefix_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseRecNoPrefix.IsOn)
            {
                if (!tokenEditPurchaseRecNoSeries.Properties.Tokens.Contains(PurchaseRecNoSeriesPrefixToken))
                {
                    tokenEditPurchaseRecNoSeries.Properties.Tokens.Add(PurchaseRecNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditPurchaseRecNoSeries.Properties.Tokens.Remove(PurchaseRecNoSeriesPrefixToken);

                if (tokenEditPurchaseRecNoSeries.SelectedItems.Contains(PurchaseRecNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditPurchaseRecNoSeries.SelectedItems.Clone();
                    tokenEditPurchaseRecNoSeries.ResetText();


                    string NewValue = "";
                    foreach (TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != PurchaseRecNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditPurchaseRecNoSeries.EditValue = NewValue;
                }

            }
        }
        #endregion

        #region Purchase Return
        private void tswitchPurchaseReturnNo_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseReturnNo.IsOn)
            {
                tswitchPurchaseReturnNoAutoGenerate.Enabled = true;
                tswitchPurchaseReturnNoPrefix.Enabled = true;
                tswitchPurchaseReturnNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchPurchaseReturnNoAutoGenerate.IsOn = false;
                tswitchPurchaseReturnNoPrefix.IsOn = false;
                tswitchPurchaseReturnNoAllowEdit.IsOn = false;

                tswitchPurchaseReturnNoAutoGenerate.Enabled = false;
                tswitchPurchaseReturnNoPrefix.Enabled = false;
                tswitchPurchaseReturnNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchPurchaseReturnNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseReturnNoAutoGenerate.IsOn == false)
            {
                tswitchPurchaseReturnNoAllowEdit.IsOn = true;
                tswitchPurchaseReturnNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchPurchaseReturnNoAllowEdit.IsOn = false;
                tswitchPurchaseReturnNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchPurchaseReturnNoPrefix_Toggled(object sender, EventArgs e)
        {
            if (tswitchPurchaseReturnNoPrefix.IsOn)
            {
                if (!tokenEditPurchaseReturnNoSeries.Properties.Tokens.Contains(PurchaseReturnNoSeriesPrefixToken))
                {
                    tokenEditPurchaseReturnNoSeries.Properties.Tokens.Add(PurchaseReturnNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditPurchaseReturnNoSeries.Properties.Tokens.Remove(PurchaseReturnNoSeriesPrefixToken);

                if (tokenEditPurchaseReturnNoSeries.SelectedItems.Contains(PurchaseReturnNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditPurchaseReturnNoSeries.SelectedItems.Clone();
                    tokenEditPurchaseReturnNoSeries.ResetText();


                    string NewValue = "";
                    foreach (TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != PurchaseReturnNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditPurchaseReturnNoSeries.EditValue = NewValue;
                }

            }
        }
        #endregion

        #region Receipt
        private void tswitchReceiptNo_Toggled(object sender, EventArgs e)
        {
            if (tswitchReceiptNo.IsOn)
            {
                tswitchReceiptNoAutoGenerate.Enabled = true;
                tswitchReceiptNoPrefix.Enabled = true;
                tswitchReceiptNoAllowEdit.Enabled = true;
            }
            else
            {
                tswitchReceiptNoAutoGenerate.IsOn = false;
                tswitchReceiptNoPrefix.IsOn = false;
                tswitchReceiptNoAllowEdit.IsOn = false;

                tswitchReceiptNoAutoGenerate.Enabled = false;
                tswitchReceiptNoPrefix.Enabled = false;
                tswitchReceiptNoAllowEdit.Enabled = false;
            }
        }

        private void tswitchReceiptNoAutoGenerate_Toggled(object sender, EventArgs e)
        {
            if (tswitchReceiptNoAutoGenerate.IsOn == false)
            {
                tswitchReceiptNoAllowEdit.IsOn = true;
                tswitchReceiptNoAllowEdit.Enabled = false;
            }
            else
            {
                tswitchReceiptNoAllowEdit.IsOn = false;
                tswitchReceiptNoAllowEdit.Enabled = true;
            }
        }

        private void tswitchReceiptNoPrefix_Toggled(object sender, EventArgs e)
        {
            if (tswitchReceiptNoPrefix.IsOn)
            {
                if (!tokenEditReceiptNoSeries.Properties.Tokens.Contains(ReceiptNoSeriesPrefixToken))
                {
                    tokenEditReceiptNoSeries.Properties.Tokens.Add(ReceiptNoSeriesPrefixToken);
                }
            }
            else
            {
                tokenEditReceiptNoSeries.Properties.Tokens.Remove(ReceiptNoSeriesPrefixToken);

                if (tokenEditReceiptNoSeries.SelectedItems.Contains(ReceiptNoSeriesPrefixToken))
                {
                    TokenEditSelectedItemCollection OldSelectedToken = tokenEditReceiptNoSeries.SelectedItems.Clone();
                    tokenEditReceiptNoSeries.ResetText();


                    string NewValue = "";
                    foreach (TokenEditToken item in OldSelectedToken)
                    {
                        if (item.Value != ReceiptNoSeriesPrefixToken.Value)
                        {
                            NewValue += item.Value + ",";
                        }
                    }

                    if (NewValue.Length > 0) NewValue.Substring(0, NewValue.Length - 1);
                    tokenEditReceiptNoSeries.EditValue = NewValue;
                }

            }
        }
        #endregion

        #region SMS Methods

        private void tswitchSMS_Activate_Toggled(object sender, EventArgs e)
        {
            var visibility = (tswitchSMS_Activate.IsOn ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            lciSMSAuthKey.Visibility = visibility;
            lcgSMSTemplate.Visibility = visibility;
            lcgSMSSaleInvoice.Visibility = visibility;
            lcgSMSSaleReturn.Visibility = visibility;
            lcgSMSSaleOrder.Visibility = visibility;
            lcgPurchase.Visibility = visibility;
            lcgPurchaseReturn.Visibility = visibility;
        }


        #region Sale Invoice 
        private void txtSMS_SaleInvoiceSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinSaleInvoice.IsOn && txtSMS_SaleInvoiceSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_SaleInvoiceSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_SaleInvoiceSenderID, "");
            }
        }

        private void lboSMS_SaleInvoiceSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_SaleInvoiceTemplate.SelectionStart == memoSms_SaleInvoiceTemplate.Text.Length)
            {
                memoSms_SaleInvoiceTemplate.Text += lboSMS_SaleInvoiceSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_SaleInvoiceTemplate.Text = memoSms_SaleInvoiceTemplate.Text.Substring(0, memoSms_SaleInvoiceTemplate.SelectionStart) + lboSMS_SaleInvoiceSMSParas.SelectedItem.ToString() +
                    memoSms_SaleInvoiceTemplate.Text.Substring(memoSms_SaleInvoiceTemplate.SelectionStart, memoSms_SaleInvoiceTemplate.Text.Length - memoSms_SaleInvoiceTemplate.SelectionStart);
            }

        }
        #endregion

        #region Sale Return 
        private void txtSMS_SaleReturnSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinSaleReturn.IsOn && txtSMS_SaleReturnSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_SaleReturnSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_SaleReturnSenderID, "");
            }
        }

        private void lboSMS_SaleReturnSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_SaleReturnTemplate.SelectionStart == memoSms_SaleReturnTemplate.Text.Length)
            {
                memoSms_SaleReturnTemplate.Text += lboSMS_SaleReturnSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_SaleReturnTemplate.Text = memoSms_SaleReturnTemplate.Text.Substring(0, memoSms_SaleReturnTemplate.SelectionStart) + lboSMS_SaleReturnSMSParas.SelectedItem.ToString() +
                    memoSms_SaleReturnTemplate.Text.Substring(memoSms_SaleReturnTemplate.SelectionStart, memoSms_SaleReturnTemplate.Text.Length - memoSms_SaleReturnTemplate.SelectionStart);
            }

        }
        #endregion

        #region Sale Order
        private void txtSMS_SaleOrderSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinSaleOrder.IsOn && txtSMS_SaleOrderSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_SaleOrderSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_SaleOrderSenderID, "");
            }
        }

        private void lboSMS_SaleOrderSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_SaleOrderTemplate.SelectionStart == memoSms_SaleOrderTemplate.Text.Length)
            {
                memoSms_SaleOrderTemplate.Text += lboSMS_SaleOrderSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_SaleOrderTemplate.Text = memoSms_SaleOrderTemplate.Text.Substring(0, memoSms_SaleOrderTemplate.SelectionStart) + lboSMS_SaleOrderSMSParas.SelectedItem.ToString() +
                    memoSms_SaleOrderTemplate.Text.Substring(memoSms_SaleOrderTemplate.SelectionStart, memoSms_SaleOrderTemplate.Text.Length - memoSms_SaleOrderTemplate.SelectionStart);
            }

        }
        #endregion

        #region Purchase Bill 
        private void txtSMS_PurchaseBillSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinPurchaseBill.IsOn && txtSMS_PurchaseBillSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_PurchaseBillSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_PurchaseBillSenderID, "");
            }
        }

        private void lboSMS_PurchaseBillSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_PurchaseBillTemplate.SelectionStart == memoSms_PurchaseBillTemplate.Text.Length)
            {
                memoSms_PurchaseBillTemplate.Text += lboSMS_PurchaseBillSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_PurchaseBillTemplate.Text = memoSms_PurchaseBillTemplate.Text.Substring(0, memoSms_PurchaseBillTemplate.SelectionStart) + lboSMS_PurchaseBillSMSParas.SelectedItem.ToString() +
                    memoSms_PurchaseBillTemplate.Text.Substring(memoSms_PurchaseBillTemplate.SelectionStart, memoSms_PurchaseBillTemplate.Text.Length - memoSms_PurchaseBillTemplate.SelectionStart);
            }

        }
        #endregion

        #region Purchase Return
        private void txtSMS_PurchaseReturnSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinPurchaseReturn.IsOn && txtSMS_PurchaseReturnSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_PurchaseReturnSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_PurchaseReturnSenderID, "");
            }
        }

        private void lboSMS_PurchaseReturnSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_PurchaseReturnTemplate.SelectionStart == memoSms_PurchaseReturnTemplate.Text.Length)
            {
                memoSms_PurchaseReturnTemplate.Text += lboSMS_PurchaseReturnSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_PurchaseReturnTemplate.Text = memoSms_PurchaseReturnTemplate.Text.Substring(0, memoSms_PurchaseReturnTemplate.SelectionStart) + lboSMS_PurchaseReturnSMSParas.SelectedItem.ToString() +
                    memoSms_PurchaseReturnTemplate.Text.Substring(memoSms_PurchaseReturnTemplate.SelectionStart, memoSms_PurchaseReturnTemplate.Text.Length - memoSms_PurchaseReturnTemplate.SelectionStart);
            }

        }
        #endregion

        #region Receipt
        private void txtSMS_RecSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSInReciept.IsOn && txtSMS_ReceiptSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_ReceiptSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_ReceiptSenderID, "");
            }
        }

        private void listbSMS_RecieptSMSPara_DoubleClick(object sender, EventArgs e)
        {
            if (memoSMS_RecieptTemplate.SelectionStart == memoSMS_RecieptTemplate.Text.Length)
            {
                memoSMS_RecieptTemplate.Text += lboSMS_ReceiptSMSPara.SelectedItem.ToString();
            }
            else
            {
                memoSMS_RecieptTemplate.Text = memoSMS_RecieptTemplate.Text.Substring(0, memoSMS_RecieptTemplate.SelectionStart) + lboSMS_ReceiptSMSPara.SelectedItem.ToString() +
                    memoSMS_RecieptTemplate.Text.Substring(memoSMS_RecieptTemplate.SelectionStart, memoSMS_RecieptTemplate.Text.Length - memoSMS_RecieptTemplate.SelectionStart);
            }
        }
        #endregion -- end Receipt

        #region Payment
        private void txtSMS_PaymentSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSInPayment.IsOn && txtSMS_PaymentSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_PaymentSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_PaymentSenderID, "");
            }
        }

        private void lboSMS_PaymentSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_PaymentTemplate.SelectionStart == memoSms_PaymentTemplate.Text.Length)
            {
                memoSms_PaymentTemplate.Text += lboSMS_PaymentSMSParas.SelectedItem.ToString();
            }
            else
            {
                memoSms_PaymentTemplate.Text = memoSms_PaymentTemplate.Text.Substring(0, memoSms_PaymentTemplate.SelectionStart) + lboSMS_PaymentSMSParas.SelectedItem.ToString() +
                    memoSms_PaymentTemplate.Text.Substring(memoSms_PaymentTemplate.SelectionStart, memoSms_PaymentTemplate.Text.Length - memoSms_PaymentTemplate.SelectionStart);
            }

        }
        #endregion

        #region Customer Balance Report
        private void txtSMS_CBRSenderID_Validating(object sender, CancelEventArgs e)
        {
            if (tswitchSMS_Activate.IsOn && tswitchSMS_SendSMSinCBR.IsOn && txtSMS_CBRSenderID.Text.Length != 6)
            {
                ErrorProvider.SetError(txtSMS_CBRSenderID, "Sender ID must be 6 chars long.");
            }
            else
            {
                ErrorProvider.SetError(txtSMS_CBRSenderID, "");
            }
        }

        private void lboSMS_CBRSMSParas_DoubleClick(object sender, EventArgs e)
        {
            if (memoSms_CBRTemp.SelectionStart == memoSms_CBRTemp.Text.Length)
            {
                memoSms_CBRTemp.Text += lboSMS_CBRSMSParas.SelectedItem.ToString();
                memoSms_CBRTemp.SelectionStart = memoSms_CBRTemp.Text.Length;
            }
            else
            {
                int SelStart = memoSms_CBRTemp.SelectionStart;
                memoSms_CBRTemp.Text = memoSms_CBRTemp.Text.Substring(0, memoSms_CBRTemp.SelectionStart) + lboSMS_CBRSMSParas.SelectedItem.ToString() +
                    memoSms_CBRTemp.Text.Substring(memoSms_CBRTemp.SelectionStart, memoSms_CBRTemp.Text.Length - memoSms_CBRTemp.SelectionStart);
                memoSms_CBRTemp.SelectionStart = SelStart + lboSMS_CBRSMSParas.SelectedItem.ToString().Length;
            }
        }

        #endregion


        #endregion

    }
}
