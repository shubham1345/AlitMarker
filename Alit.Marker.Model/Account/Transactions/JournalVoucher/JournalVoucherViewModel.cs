using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.JournalVoucher
{
    public class JournalVoucherDashboardViewModel : Template.DashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return JournalVoucherID; } set { JournalVoucherID = value; } }

        [Browsable(false)]
        public long JournalVoucherID { get; set; }

        [DisplayName("JV No.")]
        public int JournalVoucherNo { get; set; }

        [DisplayName("JV Date")]
        public DateTime JournalVoucherDate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }
    }

    public class JournalVoucherViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return JournalVoucherID; } set { JournalVoucherID = value; } }

        [Browsable(false)]
        public long JournalVoucherID { get; set; }

        [DisplayName("Journal Voucher No.")]
        public int JournalVoucherNo { get; set; }

        [DisplayName("Date")]
        public DateTime JournalVoucherDate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [Bindable(false)]
        public long VoucherTypeID { get; set; }

        [Bindable(false)]
        public long AccountVoucherID { get; set; }

        [Browsable(false)]
        public List<JournalVoucherDetailViewModel> JVDetails { get; set; }

    }

    public class JournalVoucherDetailViewModel
    {
        [Browsable(false)]
       public long JournalVoucherDetailID { get; set; }

        [Browsable(false)]
       public long JournalVoucherID { get; set; }

        [DisplayName("Account")]
        public long AccountID { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [DisplayName("Debit Amount")]
        public decimal DebitAmount { get; set; }

        [DisplayName("Credit Amount")]
        public decimal CreditAmount { get; set; }

        public string RowError { get; set; }
    }
}
