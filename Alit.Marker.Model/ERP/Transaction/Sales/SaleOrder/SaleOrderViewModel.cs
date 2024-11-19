using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleOrder
{
    public static class SaleOrderCommon
    {
        public const string SaleOrderNoFormat = "00000";
    }

    public class SaleOrderDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel, ISaleTransactionDashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleOrderID; } set { SaleOrderID = value; } }

        [Browsable(false)]
        public long SaleOrderID { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Browsable(false)]
        public DateTime TransactionDate { get { return OrderDate; } set { OrderDate = value; } }


        [DisplayName("Order No. Prefix")]
        public string SaleOrderNoPrefixName { get; set; }

        [DisplayName("Order No")]
        public long SaleOrderNo { get; set; }

        [DisplayName("Order No.")]
        public string SaleOrderNoWithPrefix { get { return (SaleOrderNoPrefixName ?? "") + SaleOrderNo.ToString(SaleOrderCommon.SaleOrderNoFormat); } }

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
        public string OrderMemo { get; set; }

        [DisplayName("Completed")]
        public bool IsCompleted { get; set; }
    }

    public class SaleOrderViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return SaleOrderID; } set { SaleOrderID = value; } }

        [Browsable(false)]
        public long SaleOrderID { get; set; }

        [DisplayName("Prefix")]
        public long? SaleOrderNoPrefixID { get; set; }

        [DisplayName("Order #")]
        public long SaleOrderNo { get; set; }

        [DisplayName("Order Date")]
        public DateTime SaleOrderDate { get; set; }

        [Browsable(false)]
        public long CustomerID { get; set; }

        public long PriceListID { get; set; }


        [DisplayName("Gross Amt")]
        public decimal GrossAmt { get; set; }

        [DisplayName("Net Amt")]
        public decimal NetAmt { get; set; }


        [DisplayName("Completed")]
        public bool IsCompleted { get; set; }

        public string OrderMemo { get; set; }

        public decimal RoundOffAmt { get; set; }

        public long? RoundOffAddLessID { get; set; }

        public long? SaleInvoiceID { get; set; }

        public List<SaleOrderProductDetailViewModel> ProductDetails { get; set; }

        public List<SaleOrderAdditionalsViewModel> AdditionalItems { get; set; }
    }


    public class SaleOrderProductDetailViewModel : TransactionsCommon.ProductDetailBaseViewModel
    {
        public SaleOrderProductDetailViewModel() : base() { }
        public SaleOrderProductDetailViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser) { }

        [Browsable(false)]
        public long SaleOrderProductDetailID { get; set; }
    }

    public class SaleOrderAdditionalsViewModel : TransactionsCommon.AdditionalItemDetailBaseViewModel
    {

        public SaleOrderAdditionalsViewModel() : base(0, null)
        { }
        public SaleOrderAdditionalsViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser)
        { }
        public SaleOrderAdditionalsViewModel(
            [Optional] long AdditionalsID,
            [Optional] long? AdditionalItemID,
            bool suspendCalculationAndEventRaiser = false,
            string AdditionalItemName = "",
            eCalculateOn CalculateOn = eCalculateOn.None,
            string ItemDescr = "",
            eAdditionalItemNature ItemNature = eAdditionalItemNature.Add,
            decimal Perc = 0,
            decimal Amt = 0,
            decimal CalculatedOnAmt = 0,
            decimal UpdatedAmt = 0,
            bool IsInclusive = false,
            eAdditionalRecordType RecordType = eAdditionalRecordType.UserAdded,
            bool CalculatePercRev = true) : base(

                                        AdditionalsID,
                                        AdditionalItemID,
                                        suspendCalculationAndEventRaiser,
                                        AdditionalItemName,
                                        CalculateOn,
                                        ItemDescr,
                                        ItemNature,
                                        Perc,
                                        Amt,
                                        CalculatedOnAmt,
                                        UpdatedAmt,
                                        IsInclusive,
                                        RecordType,
                                        CalculatePercRev)
        {

        }
    }

    public class SaleOrderLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return (long)SaleOrderID; } set { SaleOrderID = value; } }

        [Browsable(false)]
        public long? SaleOrderID { get; set; }

        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "d")]
        public DateTime? OrderDate { get; set; }

        [Browsable(false)]
        [DisplayName("Order No. Prefix")]
        public string SaleOrderNoPrefixName { get; set; }

        [Browsable(false)]
        [DisplayName("Order No")]
        public long? SaleOrderNo { get; set; }

        [DisplayName("Order No.")]
        public string SaleOrderNoWithPrefix
        {
            get
            {
                return (SaleOrderNo.HasValue ? (SaleOrderNoPrefixName ?? "") + SaleOrderNo.Value.ToString(SaleOrderCommon.SaleOrderNoFormat) : null);
            }
        }


        #region Customer Information
        [Browsable(false)]
        public long CustomerID { get; set; }

        [Browsable(false)]
        public string CustomerNameTitle { get; set; }

        [Browsable(false)]
        public string CustomerName { get; set; }

        [Browsable(false)]
        public string CustomerAddress { get; set; }

        [Browsable(false)]
        public string CustomerCityName { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerNameAddressCity
        {
            get
            {
                string v = (CustomerName ?? "").Trim();
                v += (v != "" && !String.IsNullOrWhiteSpace(CustomerAddress) ? ", " : "") + CustomerAddress ?? "";
                v += (v != "" && !String.IsNullOrWhiteSpace(CustomerCityName) ? ", " : "") + CustomerCityName ?? "";
                return v;
            }
        }
        #endregion

        [Browsable(false)]
        [DisplayName("Net Amt")]
        public decimal? NetAmt { get; set; }
    }
}