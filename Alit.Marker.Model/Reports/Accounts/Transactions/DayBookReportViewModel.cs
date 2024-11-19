using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.Accounts.Transactions
{
    public class DayBookReportViewModel : IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AccountVoucherID; } set { AccountVoucherID = value; } }

        [Browsable(false)]
        public long AccountVoucherID { get; set; }

        [Browsable(false)]
        public long AccountID { get; set; }

        [DisplayName("Date")]
        public DateTime VoucherDate { get; set; }

        [DisplayName("Voucher Type")]
        public string VoucherType { get; set; }

        [DisplayName("Voucher No.")]
        public string VoucherNo { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        [DisplayName("Account Group")]
        public string AccountGroup { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }
    }
}
