using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseBill
{
    public class PurchaseBillDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseBillID; } set { PurchaseBillID = value; } }

        [Browsable(false)]
        public long PurchaseBillID { get; set; }

        [DisplayName("Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("Bill No.")]
        public string PurchaseBillNo { get; set; }

        [DisplayName("Bill Date")]
        public DateTime PurchaseBillDate { get; set; }

        [DisplayName("Prefix")]
        public string PurchaseReceiptNoPrefixName { get; set; }

        [DisplayName("P.R. No.")]
        public long? PurchaseReceiptNo { get; set; }

        [DisplayName("P.R.No.")]
        public string PurchaseReceiptNoWithPrefix { get { return (PurchaseReceiptNoPrefixName ?? "") + (PurchaseReceiptNo.HasValue ? PurchaseReceiptNo.Value.ToString(ERP.Transaction.Sales.SaleInvoice.SaleInvoiceCommon.SaleInvoiceNoFormat) : ""); } }


        [DisplayName("P.R. Date")]
        public DateTime? PurchaseReceiptDate { get; set; }

        #region Customer Information
        //[Browsable(false)]
        //public long CustomerID { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("City")]
        public string CustomerCityName { get; set; }

        //[DisplayName("Customer Name")]
        //public string CustomerNameAddressCity
        //{
        //    get
        //    {
        //        string v = CustomerName;
        //        //v += (v != "" && CustomerAddress != "" ? ", " : "") + CustomerAddress;
        //        v += (v != "" && CustomerCityName != "" ? ", " : "") + CustomerCityName;
        //        return v;
        //    }
        //}
        #endregion

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

        [DisplayName("Memo")]
        public string PurchaseBillMemo { get; set; }
    }

    public class PurchaseBillViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return PurchaseBillID; } set { PurchaseBillID = value; } }

        [Browsable(false)]
        public long PurchaseBillID { get; set; }

        public long? StockVoucherID { get; set; }

        [Browsable(false)]
        public eMemoType MemoType { get; set; }

        [DisplayName("Bill No.")]
        public string PurchaseBillNo { get; set; }

        [DisplayName("Bill Date")]
        public DateTime PurchaseBillDate { get; set; }

        [DisplayName("Prefix")]
        public long? PurchaseReceiptNoPrefixID { get; set; }

        [DisplayName("Receipt #")]
        public long? PurchaseReceiptNo { get; set; }

        [DisplayName("Receipt Date")]
        public DateTime? PurchaseReceiptDate { get; set; }
        
        [Browsable(false)]
        public long CustomerID { get; set; }

        [Browsable(false)]
        public long CustomerAccountID { get; set; }

        [Browsable(false)]
        public long PurchaseAccountID { get; set; }

        [Browsable(false)]
        public long VoucherTypeID { get; set; }

        [Browsable(false)]
        public long AccountVoucherID { get; set; }

        public decimal GrossAmt { get; set; }

        public decimal RoundOffAmt { get; set; }

        public long? RoundOffAddLessID { get; set; }

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

        public string PurchaseBillMemo { get; set; }
        
        public List<PurchaseBillProductDetailViewModel> ProductDetail { get; set; }

        public List<PurchaseBillAdditionalsViewModel> AdditionalItems { get; set; }

    }

    public class PurchaseBillProductDetailViewModel : TransactionsCommon.ProductDetailBaseViewModel
    {
        public PurchaseBillProductDetailViewModel() : base() { }

        public PurchaseBillProductDetailViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser) { }

        [Browsable(false)]
        public long PurchaseBillProductDetailID { get; set; }
    }

    public class PurchaseBillAdditionalsViewModel : TransactionsCommon.AdditionalItemDetailBaseViewModel
    {
        public PurchaseBillAdditionalsViewModel() : base()
        {

        }
        public PurchaseBillAdditionalsViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser)
        {

        }
    }
}