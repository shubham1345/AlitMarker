using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.ContraVoucher
{
    public class ContraVoucherDashboardViewModel : Template.DashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return ContraVoucherID; } set { ContraVoucherID = value; } }

        [Browsable(false)]
        public long ContraVoucherID { get; set; }

        [DisplayName("CV No.")]
        public int ContraVoucherNo { get; set; }

        [DisplayName("CV Date")]
        public DateTime ContraVoucherDate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }
    }

    public class ContraVoucherViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return ContraVoucherID; } set { ContraVoucherID = value; } }

        [Browsable(false)]
        public long ContraVoucherID { get; set; }

        [DisplayName("Contra Voucher No.")]
        public int ContraVoucherNo { get; set; }

        [DisplayName("Date")]
        public DateTime ContraVoucherDate { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [Bindable(false)]
        public long VoucherTypeID { get; set; }

        [Bindable(false)]
        public long AccountVoucherID { get; set; }

        [Browsable(false)]
        public List<ContraVoucherDetailViewModel> CVDetails { get; set; }
    }

    public class ContraVoucherDetailViewModel
    {
        [Browsable(false)]
        public long ContraVoucherDetailID { get; set; }

        [Browsable(false)]
        public long ContraVoucherID { get; set; }

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
