using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.TransationReports
{
    public class TransactionRegisterReportModel : IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID
        {
            get
            {
                return TransactionID;
            }

            set
            {
                TransactionID = value;
            }
        }

        [Browsable(false)]
        public long TransactionID { get; set; }

        [DisplayName("Type")]
        public string TransactionType { get; set; }


        [DisplayName("Date")]
        public DateTime TransactionDate { get; set; }

        [DisplayName("Prefix")]
        public string TransactionNoPrefix { get; set; }

        [DisplayName("Trns.No.")]
        public long TransactionNo { get; set; }

        [DisplayName("Trns.No.")]
        public string TransactionNoWithPrefix { get { return (TransactionNoPrefix + TransactionNo.ToString()).Trim(); } }

        [DisplayName("Description")]
        public string Descr { get; set; }

        [Browsable(false)]
        public long CustomerID { get; set; }

        [DisplayName("CustomerName")]
        public string CustomerName { get; set; }

        [DisplayName("Sale")]
        public decimal? AmountSale { get; set; }

        [DisplayName("Receipt")]
        public decimal? AmountRecd { get; set; }

        [DisplayName("Balance")]
        public decimal Balance { get; set; }

        [Browsable(false)]
        public int TransactionTypePrt { get; set; }

        [Browsable(false)]
        public DateTime? rcdt { get; set; }
    }
}
