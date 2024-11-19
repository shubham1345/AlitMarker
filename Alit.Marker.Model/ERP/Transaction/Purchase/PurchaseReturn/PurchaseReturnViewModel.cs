using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Alit.Marker.Model.ERP.Transaction.Purchase.PurchaseReturn
{
    public class PurchaseReturnDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        public const int NetAmtRoundOffDecimals = 2;

        [Browsable(false)]
        public override long PrimeKeyID { get { return PurchaseReturnID; } set { PurchaseReturnID = value; } }

        [Browsable(false)]
        public long PurchaseReturnID { get; set; }

        [DisplayName("Memo Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("P/R No. Prefix")]
        public string PurchaseReturnNoPrefixName { get; set; }

        [DisplayName("P/R No")]
        public long PurchaseReturnNo { get; set; }

        [DisplayName("P/R No.")]
        public string PurchaseReturnNoWithPrefix { get { return (PurchaseReturnNoPrefixName ?? "") + PurchaseReturnNo.ToString(ERP.Transaction.Sales.SaleInvoice.SaleInvoiceCommon.SaleInvoiceNoFormat); } }
        
        [DisplayName("P/R Date")]
        public DateTime PurchaseReturnDate { get; set; }


        #region Customer Information
        [Browsable(false)]
        public long CustomerID { get; set; }

        [Browsable(false)]
        public string CustomerNameTitle { get; set; }

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
        //        v += (v != "" && CustomerAddress != "" ? ", " : "") + CustomerAddress;
        //        v += (v != "" && CustomerCityName != "" ? ", " : "") + CustomerCityName;
        //        return v;
        //    }
        //}
        #endregion


        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

        [DisplayName("Memo")]
        public string Memo { get; set; }

    }

    public class PurchaseReturnViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return PurchaseReturnID; } set { PurchaseReturnID = value; } }

        [Browsable(false)]
        public long PurchaseReturnID { get; set; }

        [Browsable(false)]
        public long? StockVoucherID { get; set; }

        [Browsable(false)]
        public eMemoType MemoType { get; set; }


        [DisplayName("Prefix")]
        public long? PurchaseReturnNoPrefixID { get; set; }

        [DisplayName("P/R No.")]
        public long PurchaseReturnNo { get; set; }

        [DisplayName("P/R Date")]
        public DateTime PurchaseReturnDate { get; set; }

        public long CustomerID { get; set; }

        public decimal GrossAmt { get; set; }

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

        public decimal RoundOffAmt { get; set; }

        public long? RoundOffAddLessID { get; set; }

        public string PurchaseReturnMemo { get; set; }

        public long CustomerAccountID { get; set; }

        [Browsable(false)]
        public long PurchaseAccountID { get; set; }

        [Browsable(false)]
        public long VoucherTypeID { get; set; }

        [Browsable(false)]
        public long AccountVoucherID { get; set; }

        public List<PurchaseReturnProductDetailViewModel> ProductDetail { get; set; }

        public List<PurchaseReturnAdditionalsViewModel> AdditionalItems { get; set; }

    }

    public class PurchaseReturnProductDetailViewModel : TransactionsCommon.ProductDetailBaseViewModel
    {
        public PurchaseReturnProductDetailViewModel() : base() { }

        public PurchaseReturnProductDetailViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser) { }

        [Browsable(false)]
        public long PurchaseReturnProductDetailID { get; set; }
    }

    public class PurchaseReturnAdditionalsViewModel : TransactionsCommon.AdditionalItemDetailBaseViewModel
    {
        public PurchaseReturnAdditionalsViewModel() : base()
        {

        }
        public PurchaseReturnAdditionalsViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser)
        {

        }
    }
}