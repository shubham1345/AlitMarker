using Alit.Marker.Model.ERP.Transaction.Sales.SaleInvoice;
using Alit.Marker.Model.Template;
using Alit.Marker.Model.TransactionsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.ERP.Transaction.Sales
{
    public enum eSaleTransactionDashboardRecordType
    {
        SaleInvoice = 1,
        SaleReturn = 2,
        DeliveryNote = 3,
        SaleOrder = 4,
        Quotation = 5,
    }

    public class SaleTransactionDashboardViewModel : DashboardViewModel, ISaleTransactionDashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return TransactionID; } set { TransactionID = value; } }

        [Browsable(false)]
        public long TransactionID { get; set; }

        [Browsable(false)]
        public eSaleTransactionDashboardRecordType RecordType { get; set; }

        [DisplayName("Type")]
        public string RecordTypeDisplay
        {
            get
            {
                switch(RecordType)
                {
                    case eSaleTransactionDashboardRecordType.SaleInvoice:
                        return "Invoice";
                    case eSaleTransactionDashboardRecordType.SaleReturn:
                        return "S/R";
                    case eSaleTransactionDashboardRecordType.DeliveryNote:
                        return "D.Note";
                    case eSaleTransactionDashboardRecordType.SaleOrder:
                        return "Order";
                    case eSaleTransactionDashboardRecordType.Quotation:
                        return "Quotation";
                    default:
                        return "N/A";
                }
            }
        }

        [DisplayName("Memo Type")]
        public eMemoType? MemoType { get; set; }

        [DisplayName("Date")]
        public DateTime TransactionDate { get; set; }

        [DisplayName("Prefix")]
        public string PrefixName { get; set; }

        [DisplayName("No.")]
        public long TransactionNo { get; set; }

        [DisplayName("No.")]
        public string TransactionNoWithPrefix { get { return (PrefixName ?? "") + TransactionNo.ToString(SaleInvoiceCommon.SaleInvoiceNoFormat); } }

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

        [DisplayName("Net Amount")]
        public decimal NetAmt { get; set; }

        [DisplayName("Memo")]
        public string Memo { get; set; }

        [DisplayName("Advance")]
        public decimal? AdvanceAmt { get; set; }
    }
}
