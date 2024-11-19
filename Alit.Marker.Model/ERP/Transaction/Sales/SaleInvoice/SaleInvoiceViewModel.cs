using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice
{
    public static class SaleInvoiceCommon
    {
        public const string SaleInvoiceNoFormat = "00000";
    }

    public class SaleInvoiceDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel, ISaleTransactionDashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleInvoiceID; } set { SaleInvoiceID = value; } }

        [Browsable(false)]
        public long SaleInvoiceID { get; set; }

        [DisplayName("Memo Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("Inv. Date")]
        public DateTime SaleInvoiceDate { get; set; }

        [Browsable(false)]
        public DateTime TransactionDate { get { return SaleInvoiceDate; } set { SaleInvoiceDate = value; } }

        [DisplayName("Inv.No. Prefix")]
        public string SaleInvoiceNoPrefixName { get; set; }

        [DisplayName("Inv No")]
        public long SaleInvoiceNo { get; set; }

        [DisplayName("Inv. No.")]
        public string SaleInvoiceNoWithPrefix { get { return (SaleInvoiceNoPrefixName ?? "") + SaleInvoiceNo.ToString(SaleInvoiceCommon.SaleInvoiceNoFormat); } }

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

        [DisplayName("Challan No.")]
        public string ChallanNo { get; set; }

        [DisplayName("Challan Date")]
        public DateTime? ChallanDate { get; set; }

        [DisplayName("Order No.")]
        public string OrderNo { get; set; }

        [DisplayName("Order Date")]

        public DateTime? OrderDate { get; set; }

        [DisplayName("Sup. Ref. No.")]

        public string SupplierReferenceNo { get; set; }

        [DisplayName("Other Ref. No.")]
        public string OtherReferenceNo { get; set; }

        [DisplayName("Transport")]
        public string TransportName { get; set; }

        [DisplayName("Packets")]
        public string NofPackets { get; set; }

        [DisplayName("Destination")]
        public string Destination { get; set; }

        [DisplayName("Disp.Doc.No.")]
        public string DispatchDocumentNo { get; set; }

        [DisplayName("Delivery Date")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayName("Price List")]
        public string PriceListName { get; set; }

        [DisplayName("Net Amount")]
        public decimal NetAmt { get; set; }

        [DisplayName("Memo")]
        public string InvoiceMemo { get; set; }

        [DisplayName("Advance")]
        public decimal? AdvanceAmt { get; set; }

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
                if (SaleOrderNo.HasValue)
                {
                    return (SaleOrderNoPrefixName ?? "") + SaleOrderNo.Value.ToString(Model.ERP.Transaction.Sales.SaleOrder.SaleOrderCommon.SaleOrderNoFormat);
                }
                else
                {
                    return null;
                }
            }
        }

    }

    public class SaleInvoiceViewModel : Template.ICRUDViewModel
    {
        public long PrimeKeyID { get { return SaleInvoiceID; } set { SaleInvoiceID = value; } }

        public long SaleInvoiceID { get; set; }

        public long? StockVoucherID { get; set; }

        public long? SaleOrderID { get; set; }

        public eMemoType MemoType { get; set; }

        public DateTime SaleInvoiceDate { get; set; }

        public long SaleInvoiceNo { get; set; }

        public long? SaleInvoiceNoPrefixID { get; set; }

        public long CustomerAccountID { get; set; }

        public string ChallanNo { get; set; }

        public DateTime? ChallanDate { get; set; }

        public string OrderNo { get; set; }

        public DateTime? OrderDate { get; set; }

        public string SupplierReferenceNo { get; set; }

        public string OtherReferenceNo { get; set; }

        public long? TransportID { get; set; }

        public string NofPackets { get; set; }

        public string Destination { get; set; }

        public string DispatchDocumentNo { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public long PriceListID { get; set; }

        public decimal GrossAmt { get; set; }

        public decimal RoundOffAmt { get; set; }

        public long? RoundOffAddLessID { get; set; }

        public decimal NetAmt { get; set; }

        public string InvoiceMemo { get; set; }



        public decimal AdvanceAmt { get; set; }

        public decimal AdvanceOldAmt { get; set; }

        public long? AdvanceOldRecieptID { get; set; }

        public long SaleAccountID { get; set; }

        public long VoucherTypeID { get; set; }

        public long AccountVoucherID { get; set; }

        public List<SaleInvoiceProductDetailViewModel> ProductDetail { get; set; }

        public List<SaleInvoiceAdditionalsViewModel> AdditionalItems { get; set; }
    }

    public class SaleInvoiceProductDetailViewModel : TransactionsCommon.ProductDetailBaseViewModel
    {
        public SaleInvoiceProductDetailViewModel() : base() { }

        public SaleInvoiceProductDetailViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser) { }

        [Browsable(false)]
        public long SaleInvoiceProductDetailID { get; set; }
    }

    public class SaleInvoiceAdditionalsViewModel : TransactionsCommon.AdditionalItemDetailBaseViewModel
    {

        public SaleInvoiceAdditionalsViewModel() : base(0, null)
        { }
        public SaleInvoiceAdditionalsViewModel(bool suspendCalculationAndEventRaiser) : base(suspendCalculationAndEventRaiser)
        { }
        public SaleInvoiceAdditionalsViewModel(
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

        //[Browsable(false)]
        //public long AdditionalsID { get; set; }

        //[Browsable(false)]
        //public long? AdditionalItemID { get; set; }

        //[DisplayName("Name")]
        //public string AdditionalItemName { get; set; }

        //[DisplayName("Calculate On Percentage")]
        //public eCalculateOn CalculateOn { get; set; }

        //[DisplayName("Descriptions")]
        //public string ItemDescr { get; set; }

        //string ItemNature_ = "";
        //[DisplayName("+/-")]
        //public string ItemNature
        //{
        //    get { return ItemNature_; }
        //    set
        //    {
        //        if (ItemNature_ != value)
        //        {
        //            string oldvalue = ItemNature_;
        //            ItemNature_ = value;
        //            CalculateAmt();
        //            OnItemNatureChanged(ItemNature_, oldvalue);
        //        }
        //    }
        //}

        //bool SuppressPercCalculation;
        //bool SuppressAmtCalculation;
        //decimal Perc_;
        //[DisplayName("%")]
        //public decimal Perc
        //{
        //    get { return Perc_; }
        //    set
        //    {
        //        if (Perc_ != value)
        //        {
        //            Perc_ = value;
        //            SuppressPercCalculation = true;
        //            if (!SuppressAmtCalculation) CalculateAmt(true);
        //            SuppressPercCalculation = false;
        //        }
        //    }
        //}

        //public void CalculateAmt(bool Forced = false)
        //{
        //    try
        //    {
        //        if (Perc != 0 || Forced)
        //        {
        //            Amt = Math.Round(CalculatedOnAmt * Perc_ / (100 + (IsInclusive ? Perc_ : 0)), CommonProperties.UIDataFormats.AmountDecimalLen);
        //        }
        //    }
        //    catch (DivideByZeroException)
        //    {
        //        Amt = 0;
        //    }
        //}

        //decimal Amt_;
        //[DisplayName("Amt")]
        //public decimal Amt
        //{
        //    get
        //    {
        //        return Amt_;
        //    }
        //    set
        //    {
        //        decimal OldValue = Amt_;
        //        Amt_ = value;
        //        SuppressAmtCalculation = true;
        //        if (!SuppressPercCalculation && CalculatePercRev) CalculatePerc();
        //        SuppressAmtCalculation = false;

        //        OnAmtChanged(Amt_, OldValue);
        //    }
        //}

        //public event ValueChangedEventHandler AmtChanged;
        //public virtual void OnAmtChanged(object NewValue, object OldValue)
        //{
        //    if (AmtChanged != null) AmtChanged(this, new ValueChangedEventArgs(NewValue, OldValue));
        //}

        //public event ValueChangedEventHandler ItemNatureChanged;
        //public virtual void OnItemNatureChanged(object NewValue, object OldValue)
        //{
        //    if (ItemNatureChanged != null) ItemNatureChanged(this, new ValueChangedEventArgs(NewValue, OldValue));
        //}

        //public void CalculatePerc()
        //{
        //    if (CalculatedOnAmt == 0)
        //    {
        //        Perc = 0;
        //    }
        //    else
        //    {
        //        Perc = Math.Round((Amt / (CalculatedOnAmt - (IsInclusive ? Amt : 0))) * (100), CommonProperties.UIDataFormats.RateDecimalLen);
        //    }
        //}

        //decimal CalculatedOnAmt_;
        //public decimal CalculatedOnAmt
        //{
        //    get { return CalculatedOnAmt_; }
        //    set
        //    {

        //        if (CalculatedOnAmt_ != value)
        //        {
        //            CalculatedOnAmt_ = value;
        //            SuppressPercCalculation = true;
        //            CalculateAmt();
        //            SuppressPercCalculation = false;
        //        }
        //    }
        //}

        //[Browsable(false)]
        //public decimal UpdatedAmt { get; set; }

        //[Browsable(false)]
        //public bool IsInclusive { get; set; }

        //[Browsable(false)]
        //public eAdditionalRecordType RecordType { get; set; }

        //public enum eAdditionalRecordType
        //{
        //    UserAdded = 0,
        //    Tax = 1,
        //    RoundedOff = 2
        //}

        //[Description("Calculate percentage reverse back while user enters amount manually.")]
        //public bool CalculatePercRev { get; set; }
    }

    public class SaleInvoiceLookupListModel : Template.LookupListViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return SaleInvoiceID; } set { SaleInvoiceID = value; } }

        [Browsable(false)]
        public long SaleInvoiceID { get; set; }

        [DisplayName("Memo Type")]
        public eMemoType MemoType { get; set; }

        [DisplayName("Inv. Date")]
        public DateTime SaleInvoiceDate { get; set; }

        //[DisplayName("Inv.No. Prefix")]
        [Browsable(false)]
        public string SaleInvoiceNoPrefixName { get; set; }

        //[DisplayName("Inv No")]
        [Browsable(false)]
        public long SaleInvoiceNo { get; set; }

        [DisplayName("Inv. No.")]
        public string SaleInvoiceNoWithPrefix { get { return (SaleInvoiceNoPrefixName ?? "") + SaleInvoiceNo.ToString(SaleInvoiceCommon.SaleInvoiceNoFormat); } }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Net Amount")]
        public decimal NetAmt { get; set; }

        [Browsable(false)]
        public string SaleInvoiceDisplay
        {
            get
            {
                return MemoType +
                       (!String.IsNullOrWhiteSpace(SaleInvoiceNoWithPrefix) ? (" " +"Inv. No. " + SaleInvoiceNoWithPrefix) : null) +
                       (", " + "Dt " + SaleInvoiceDate.ToShortDateString()) +
                       (!String.IsNullOrWhiteSpace(CustomerName) ?  (", " + CustomerName) : null) +
                       (", " + "Amount " + NetAmt);
            }
        }
    }
}

