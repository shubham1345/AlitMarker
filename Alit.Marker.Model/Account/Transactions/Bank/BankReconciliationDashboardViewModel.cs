using Alit.Marker.Model.Account.VoucherType;
using Alit.Marker.Model.Reports.Accounts.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.Bank
{
    public class BankReconciliationOpeningBalanceViewModel
    {
        public decimal OpeningBookBalance { get; set; }

        public decimal OpeningBankBalance { get; set; }
    }

    public class BankReconciliationDashboardViewModel : Template.DashboardViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return AccountVoucherDetailID; } set { AccountVoucherDetailID = value; } }

        [Browsable(false)]
        public long AccountVoucherDetailID { get; set; }

        private bool _Reconciled;
        [DisplayName("Reconciled")]
        public bool Reconciled
        {
            get
            {
                return _Reconciled;
            }

            set
            {
                if (_Reconciled != value)
                {
                    _Reconciled = value;
                    if (_Reconciled && !ValueDate.HasValue)
                    {
                        ValueDate = VoucherDate;
                    }
                    else if (!_Reconciled && ValueDate.HasValue)
                    {
                        ValueDate = null;
                    }
                }
            }
        }

        DateTime? _ValueDate;
        [DisplayName("Value Date")]
        public DateTime? ValueDate
        {
            get
            {
                return _ValueDate;
            }
            set
            {
                if (_ValueDate != value)
                {
                    _ValueDate = value;
                    _Reconciled = ValueDate.HasValue;
                }
            }
        }

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
        public bool Edited { get; set; }

    }
}
