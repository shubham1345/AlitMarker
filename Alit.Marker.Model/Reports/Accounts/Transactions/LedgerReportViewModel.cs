using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Template.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Reports.Accounts.Transactions
{
    public enum eLedgerReportRecordType
    {
        OpeningBalance = 1,
        TransactionType = 2,
        EndOfFY = 3
    }

    public class LedgerReportViewModel : IReportViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return AccountVoucherDetailID; } set { AccountVoucherDetailID = value; } }

        [Browsable(false)]
        public long AccountVoucherDetailID { get; set; }

        //[Browsable(false)]
        //public long AccountID { get; set; }

        [DisplayName("Voucher Date")]
        public DateTime? VoucherDate { get; set; }

        [DisplayName("Voucher No.")]
        public string VoucherNo { get; set; }

        [DisplayName("Voucher Type")]
        public string VoucherTypeName { get; set; }

        [Browsable(false)]
        public ePrimaryVoucherType VoucherType { get; set; }

        [DisplayName("Record Type")]
        public eLedgerReportRecordType RecordType { get; set; }

        [DisplayName("Narration")]
        public string Narration { get; set; }

        [DisplayName("Debit")]
        public decimal DebitAmount { get; set; }

        [DisplayName("Credit")]
        public decimal CreditAmount { get; set; }

        [DisplayName("Balance")]
        public decimal Balance { get; set; }

        [Browsable(false)]
        public DateTime FYDateFrom { get; set; }

        [Browsable(false)]
        public DateTime? FYDateTo { get; set; }

        [DisplayName("Financial Period")]
        public string FinancialYear { get; set; }

    }
}
