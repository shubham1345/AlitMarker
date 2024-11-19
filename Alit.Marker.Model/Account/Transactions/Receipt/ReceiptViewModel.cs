using Alit.Marker.Model.CashBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.Receipt
{
    public class ReceiptDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ReceiptID; } set { ReceiptID = value; } }

        [Browsable(false)]
        public long ReceiptID { get; set; }

        [DisplayName("Receipt Date")]
        public DateTime ReceiptDate { get; set; }

        [DisplayName("Prefix")]
        public string ReceiptNoPrefixName { get; set; }

        [DisplayName("Receipt No")]
        public long ReceiptNo { get; set; }

        [DisplayName("Receipt No.")]
        public string SaleInvoiceNoWithPrefix { get { return (ReceiptNoPrefixName ?? "") + ReceiptNo.ToString(ERP.Transaction.Sales.SaleInvoice.SaleInvoiceCommon.SaleInvoiceNoFormat); } }

        #region Customer Information
        //[Browsable(false)]
        //public long CustomerID { get; set; }

        //[Browsable(false)]
        //public string CustomerNameTitle { get; set; }

        //[DisplayName("Name")]
        //public string CustomerName { get; set; }

        //[DisplayName("Address")]
        //public string CustomerAddress { get; set; }

        //[DisplayName("City")]
        //public string CustomerCityName { get; set; }

        //[DisplayName("Customer Name")]
        //public string CustomerNameAddressCity
        //{
        //    get
        //    {
        //        string v = CustomerName;
        //        v += (v != "" && CustomerAddress != "" ? ", " : "") + CustomerAddress;
        //        v += (v != "" && CustomerCityName != "" ? ", " : "") + CustomerCityName;
        //        return v;
        //    }
        //}

        #endregion

        #region Account Information
        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("Name")]
        public string AccountName { get; set; }

        [DisplayName("Address")]
        public string AccountAddress { get; set; }

        [DisplayName("City")]
        public string AccountCityName { get; set; }

        #endregion

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Payment Mode")]
        public eModeOfPayment ModeOfPayment { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BankBranchName { get; set; }

        [DisplayName("Cheque No.")]
        public string ChequeNo { get; set; }
    }

    public class ReceiptViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return ReceiptID; } set { ReceiptID = value; } }

        [Browsable(false)]
        public long ReceiptID { get; set; }

        [DisplayName("Receipt Date")]
        public DateTime ReceiptDate { get; set; }

        [DisplayName("Prefix")]
        public long? ReceiptNoPrefixID { get; set; }

        [DisplayName("Receipt No.")]
        public long ReceiptNo { get; set; }

        [DisplayName("Type")]
        public eModeOfPayment ModeOfPayment { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        public string BankName { get; set; }

        public string BankBranchName { get; set; }

        public string ChequeNo { get; set; }

        public string Remarks { get; set; }

        [Browsable(false)]
        public long CashBankAccountID { get; set; }

        [Browsable(false)]
        public long CustomerAccountID { get; set; }

        [Bindable(false)]
        public long VoucherTypeID { get; set; }

        [Bindable(false)]
        public long AccountVoucherID { get; set; }
    }
}
