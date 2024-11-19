using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.Accounts.Transactions
{
    public class BalanceReportViewModel : IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AccountID; } set { AccountID = value; } }

        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        [DisplayName("Account Group Name")]
        public string AccountGroupName { get; set; }

        [DisplayName("Opening Balance")]
        public decimal OpeningBalance { get; set; }
        [DisplayName("Sales")]
        public decimal Sales { get; set; }

        [DisplayName("S/R")]
        public decimal SalesReturns { get; set; }

        [DisplayName("Purchase")]
        public decimal Purchase { get; set; }

        [DisplayName("P/R")]
        public decimal PurchaseReturn { get; set; }

        [DisplayName("Received")]
        public decimal Received { get; set; }

        [DisplayName("Paid")]
        public decimal Paid { get; set; }

        [DisplayName("Other")]
        public decimal Other { get; set; }

        [DisplayName("Closing Balance")]
        public decimal ClosingBalance { get; set; }


        [Browsable(false)]
        public long AccountGroupID { get; set; }
    }
}
