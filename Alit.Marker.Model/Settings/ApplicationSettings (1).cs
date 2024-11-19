using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Settings
{
    public class ApplicationSettingsViewModel
    {
        #region Level 0
        [DisplayName("Auto User Login")]
        public bool AutoUserLogin { get; set; }

        [DisplayName("GUI Version Major")]
        public long GUIVersionMajor { get; set; }

        [DisplayName("GUI Version Minor")]
        public long GUIVersionMinor { get; set; }

        [DisplayName("GUI theme name")]
        public string GUIThemeSkinName { get; set; }

        #endregion -- Level 0 

        #region Level 1

        #region Sale Invoice
        [DisplayName("Applicable Sale Invoice Memo Types")]
        public eSaleInvoiceMemoTypeApplies SaleInvoiceMemoTypeApplies { get; set; }

        [DisplayName("Ask customer in each sale invoice")]
        public bool SaleInvoiceAskCustomer { get; set; }

        [DisplayName("Sale Invoice Default Cash Customer ID")]
        public long? SaleInvoiceDefaultCustomerID { get; set; }

        [DisplayName("Default Sale Invoice Memo Type")]
        public Alit.Marker.Model.Sales.SaleInvoiceEditListModel.eMemoType SaleInvoiceDefaultMemoType { get; set; }

        #region Sale Invoice No.
        [DisplayName("Apply Sale Invoice No.")]
        public bool SaleInvoiceNo { get; set; }

        [DisplayName("Allow to Auto Generate Sale Invoice Number.")]
        public bool SaleInvoiceNoAutoGenerate { get; set; }

        [DisplayName("Apply Prefix Before Invoice Number.")]
        public bool SaleInvoiceNoPrefix { get; set; }

        [DisplayName("Default Sale Invoice Prefix ID")]
        public long? DefaultSaleInvoiceNoPrefixID { get; set; }

        [DisplayName("Series to auto generate sale invoice number")]
        public string SaleInvoiceNoSeries { get; set; }

        [DisplayName("Allow manual editing in sale invoice number.")]
        public bool SaleInvoiceNoAllowEdit { get; set; }
        #endregion -- End Sale Invoice 


        [DisplayName("Challan information to be applied in sale invoice")]
        public string SaleInvoiceChallanInfo { get; set; }

        [DisplayName("Dispatch information to be applied in sale invoice")]
        public bool SaleInvoiceDispatchInfo { get; set; }
        
        #region Product Details

        public bool SaleInvoiceProductSelectionByProductCode { get; set; }
        public bool SaleInvoiceProductSelectionByBarcode { get; set; }
        public bool SaleInvoiceProductSelectionByProductName { get; set; }
        public bool SaleInvoiceAllowEditProductDescr { get; set; }
        public bool SaleInvoiceCursorStopOnQuan { get; set; }
        public decimal SaleInvoiceDefaultQuan { get; set; }
        public bool SaleInvoiceCursorStopOnRate { get; set; }
        public bool SaleInvoiceAllowEditRate { get; set; }
        public bool SaleInvoiceAddDiscountColumn { get; set; }
        public bool SaleInvoiceCursorStopOnDisc { get; set; }
        public bool SaleInvoiceAddTaxColumn { get; set; }
        public bool SaleInvoiceCursorStopOnTax { get; set; }
        public bool SaleInvoiceAddUnitColumn { get; set; }
        public bool SaleInvoiceCursorStopOnUnit { get; set; }

        #endregion -- End Product Details

        [DisplayName("Apply round off calculation on transactions")]
        public bool ApplyRoundOff { get; set; }

        [DisplayName("Additional Item ID to save round off value.")]
        public long? RoundOffAddLessID { get; set; }

        #endregion -- End Sale Invoice 

        #region Sale Order

        [DisplayName("Activate Sale Order")]
        public bool ActivateSaleOrder { get; set; }

        #region Sale Order No
        [DisplayName("Apply Sale Order#")]
        public bool SaleOrderNo { get; set; }

        [DisplayName("Allow to Auto Generate Sale Order#")]
        public bool SaleOrderNoAutoGenerate { get; set; }

        [DisplayName("Apply Prefix Before Invoice#")]
        public bool SaleOrderNoPrefix { get; set; }

        [Browsable(false)]
        public long? DefaultSaleOrderNoPrefixID { get; set; }

        [DisplayName("Series to auto generate sale order#")]
        public string SaleOrderNoSeries { get; set; }

        [DisplayName("Allow manual editing in sale Order#")]
        public bool SaleOrderNoAllowEdit { get; set; }
        #endregion -- Sale Order No
        
        #endregion -- Sale Order

        #region Sale Return

        #region Sale Order No.
        [DisplayName("Apply Sale Return No.")]
        public bool SaleReturnNo { get; set; }

        [DisplayName("Allow to Auto Generate Sale Return Number.")]
        public bool SaleReturnNoAutoGenerate { get; set; }

        [DisplayName("Apply Prefix Before Sale Return Number.")]
        public bool SaleReturnNoPrefix { get; set; }

        [DisplayName("Default Sale Return Prefix ID")]
        public long? DefaultSaleReturnNoPrefixID { get; set; }

        [DisplayName("Series to auto generate sale return number")]
        public string SaleReturnNoSeries { get; set; }

        [DisplayName("Allow manual editing in sale return number.")]
        public bool SaleReturnNoAllowEdit { get; set; }
        #endregion -- End Sale ORder No

        #endregion -- End Sale Order

        #region Purchase

        #region Purchase Receipt No.
        [DisplayName("Apply Purchase Receipt No.")]
        public bool PurchaseReceiptNo { get; set; }

        [DisplayName("Allow to Auto Generate Purchase Receipt Number.")]
        public bool PurchaseReceiptNoAutoGenerate { get; set; }

        [DisplayName("Apply Prefix Before Purchase Receipt Number.")]
        public bool PurchaseReceiptNoPrefix { get; set; }

        [DisplayName("Default Purchase Receipt Prefix ID")]
        public long? DefaultPurchaseReceiptNoPrefixID { get; set; }

        [DisplayName("Series to auto generate Purchase Receipt number")]
        public string PurchaseReceiptNoSeries { get; set; }

        [DisplayName("Allow manual editing in Purchase Receipt number.")]
        public bool PurchaseReceiptNoAllowEdit { get; set; }
        #endregion -- End Purchase Receipt No

        [DisplayName("Ask Purchase Bill No")]
        public bool PurchaseBillReceiptDate { get; set; }

        [DisplayName("Stop Cursor On Purchase Receipt Date")]
        public bool PurchaseBillStopCursorOnReceiptDate { get; set; }

        #endregion -- End Purchase Receipt

        #region Purchase Return

        #region Purchase Return No.
        [DisplayName("Apply Purchase Return No.")]
        public bool PurchaseReturnNo { get; set; }

        [DisplayName("Allow to Auto Generate Purchase Return Number.")]
        public bool PurchaseReturnNoAutoGenerate { get; set; }

        [DisplayName("Apply Prefix Before Purchase Return Number.")]
        public bool PurchaseReturnNoPrefix { get; set; }

        [DisplayName("Default Purchase Return Prefix ID")]
        public long? DefaultPurchaseReturnNoPrefixID { get; set; }

        [DisplayName("Series to auto generate Purchase Return number")]
        public string PurchaseReturnNoSeries { get; set; }

        [DisplayName("Allow manual editing in Purchase Return number.")]
        public bool PurchaseReturnNoAllowEdit { get; set; }
        #endregion -- End Purchase Return No

        #endregion -- Purchase Return

        #region Product Master
        public bool MaintainProducts { get; set; }
        public bool ProductCode { get; set; }
        public bool ProductBarcode { get; set; }

        public bool HSNCode { get; set; }

        #endregion -- End Product Master

        #endregion -- End Level 1 

        #region Reports
        
        #region Sale Invoice Print
        public long SaleInvoicePrintDefaultFormatNo { get; set; }

        public string SaleInvoicePrintCustomFormatFileName { get; set; }

        public bool SaleInvoicePrintIsDirectPrint { get; set; }
        public int SaleInvoicePrintNoCopies { get; set; }
        #endregion -- Sale Invoice Print

        #region Receipt Print
        public bool ReceiptPrintIsDirectPrint { get; set; }
        public int ReceiptPrintNoCopies { get; set; }
        #endregion -- Receipt Print

        #endregion -- End Report

        #region SMS
        // Sms Activation
        public bool SMSActivated { get; set; }
        public string SMSAuthKey { get; set; }

        // SMS in Sale Invoice
        public bool SMSSendInSaleInvoice { get; set; }
        public string SMSSaleInvoiceSenderID { get; set; }
        public string SMSSaleInvoiceTemplate { get; set; }


        // SMS in Sale Order
        public bool SMSSendInSaleOrder { get; set; }
        public string SMSSaleOrderSenderID { get; set; }
        public string SMSSaleOrderTemplate { get; set; }

        // SMS in Sale Return
        public bool SMSSendInSaleReturn { get; set; }
        public string SMSSaleReturnSenderID { get; set; }
        public string SMSSaleReturnTemplate { get; set; }

        // SMS in Purchase Bill
        public bool SMSSendInPurchaseBill { get; set; }
        public string SMSPurchaseBillSenderID { get; set; }
        public string SMSPurchaseBillTemplate { get; set; }

        // SMS in Purchase Return
        public bool SMSSendInPurchaseReturn { get; set; }
        public string SMSPurchaseReturnSenderID { get; set; }
        public string SMSPurchaseReturnTemplate { get; set; }


        // SMS in Receipt
        public bool SMSSendInReceipt { get; set; }
        public string SMSReceiptSenderID { get; set; }
        public string SMSReceiptTemplate { get; set; }

        // SMS in Payment
        public bool SMSSendInPayment { get; set; }
        public string SMSPaymentSenderID { get; set; }
        public string SMSPaymentTemplate { get; set; }


        // SMS in Balance Report
        public bool SMSSendInCustomerBalanceReport { get; set; }
        public string SMSCustomerBalanceReportSenderID { get; set; }
        public string SMSCustomerBalanceReportTemplate { get; set; }
        
        #endregion -- END SMS

    }

    public class SettingSaveModel
    {
        public string SettingName { get; set; }

        public object SettingValue { get; set; }
    }

    public enum eSaleInvoiceMemoTypeApplies
    {
        Cash = 0,
        Credit = 1,
        CashCreditBoth = 2
    }

    public enum eSaleInvoiceNoSeries
    {
        Prefix = 1,
        Year = 2,
        MonthYear = 3,
        Date = 4
    }

    public enum eSaleInvoiceChallanElements
    {
        ChallanNo = 1,
        ChallanDate = 2, 
        OrderNo = 3,
        OrderDate = 4,
        SupplierRefNo = 5,
        OtherRefNo = 6
    }

    public enum eSettingValueType
    {
        Varchar50 = 1,
        Int = 2,
        Long = 3, 
        DateTime = 4,
        Boolean = 5,
        Decimal = 6
    }
}
