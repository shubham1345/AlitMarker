using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleReturn
{
    public class SaleReturnDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel, ISaleTransactionDashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleReturnID; } set { SaleReturnID = value; } }


        [Browsable(false)]
        public long SaleReturnID { get; set; }

        [DisplayName("Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("S/R Date")]
        public DateTime SaleReturnDate { get; set; }

        [Browsable(false)]
        public DateTime TransactionDate { get { return SaleReturnDate; } set { SaleReturnDate = value; } }

        [DisplayName("S/R.No. Prefix")]
        public string SaleReturnNoPrefixName { get; set; }

        [DisplayName("S/R No")]
        public long SaleReturnNo { get; set; }

        [DisplayName("S/R No.")]
        public string SaleReturnNoWithPrefix { get { return (SaleReturnNoPrefixName ?? "") + SaleReturnNo.ToString(ERP.Transaction.Sales.SaleInvoice.SaleInvoiceCommon.SaleInvoiceNoFormat); } }


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


        [DisplayName("Price List")]
        public string PriceListName { get; set; }

        [DisplayName("Memo")]
        public string SaleReturnMemo { get; set; }

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

    }

    public class SaleReturnViewModel : Template.ICRUDViewModel
    {
        public const int NetAmtRoundOffDecimals = 2;

        [Browsable(false)]
        public long PrimeKeyID { get { return SaleReturnID; } set { SaleReturnID = value; } }


        [Browsable(false)]
        public long SaleReturnID { get; set; }

        [Browsable(false)]
        public long? StockVoucherID { get; set; }

        [DisplayName("Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("Prefix")]
        public long? SaleReturnNoPrefixID { get; set; }

        [DisplayName("S/R No.")]
        public long SaleReturnNo { get; set; }

        [DisplayName("S/R Date")]
        public DateTime SaleReturnDate { get; set; }

        public long CustomerAccountID { get; set; }

        public long PriceListID { get; set; }

        public decimal GrossAmt { get; set; }

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }

        public decimal RoundOffAmt { get; set; }

        public long? RoundOffAddLessID { get; set; }

        public string SaleReturnMemo { get; set; }

        public long SaleAccountID { get; set; }

        public long VoucherTypeID { get; set; }

        public long AccountVoucherID { get; set; }

        public List<SaleReturnProductDetailViewModel> ProductDetails { get; set; }

        public List<SaleReturnAdditionalsViewModel> AdditionalItems { get; set; }

    }

    public class SaleReturnProductDetailViewModel : TransactionsCommon.ProductDetailBaseViewModel
    {
        public SaleReturnProductDetailViewModel() : base() { }

        public SaleReturnProductDetailViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser) { }

        [Browsable(false)]
        public long SaleReturnProductDetailID { get; set; }
    }

    public class SaleReturnAdditionalsViewModel : TransactionsCommon.AdditionalItemDetailBaseViewModel
    {
        public SaleReturnAdditionalsViewModel() : base()
        {

        }
        public SaleReturnAdditionalsViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser)
        {

        }
    }
}