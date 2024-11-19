using Alit.Marker.Model.CashBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alit.Marker.Model.Account.Transactions.Payment
{
    public class PaymentDashboardViewModel : Template.DashboardViewModel, Template.ICRUDViewModel
    {
        [Browsable(false)]
        public override long PrimeKeyID { get { return PaymentID; } set { PaymentID = value; } }
        
        [Browsable(false)]
        public long PaymentID { get; set; }

        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

        [DisplayName("Payment No.")]
        public long PaymentNo { get; set; }

        [DisplayName("Type")]
        public eModeOfPayment PaymentMode { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        ////[DisplayName("Customer Name")]
        ////public string CustomerName { get; set; }

        [DisplayName("Customer Name")]
        public string AccountName { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }
    }

    public class PaymentViewModel : Template.ICRUDViewModel
    {
        [Browsable(false)]
        public long PrimeKeyID { get { return PaymentID; } set { PaymentID = value; } }


        [Browsable(false)]
        public long PaymentID { get; set; }

        public DateTime PaymentDate { get; set; }

        public long PaymentNo { get; set; }

        public eModeOfPayment PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public string BankName { get; set; }

        public string BankBranchName { get; set; }

        public string ChequeNo { get; set; }

        public string Remarks { get; set; }

        [Browsable(false)]
        public long CashBankAccountID { get; set; }

        [Browsable(false)]
        public long CustomerAccountID { get; set; }

        [Bindable(false)]
        public long VoucherTypeID { get; set; }

        [Bindable(false)]
        public long AccountVoucherID { get; set; }
    }
    
    public class PaymentLookupModel
    {
        [Browsable(false)]
        public long PaymentID { get; set; }

        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

        [DisplayName("Payment No.")]
        public long PaymentNo { get; set; }

        [DisplayName("Type")]
        public eModeOfPayment PaymentMode { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        //[DisplayName("Customer Name")]
        //public string CustomerName { get; set; }

        [DisplayName("Customer Name")]
        public string AccountName { get; set; }
    }
}
