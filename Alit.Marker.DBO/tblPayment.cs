//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alit.Marker.DBO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPayment
    {
        public long PaymentID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public long PaymentNo { get; set; }
        public int PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public long CompanyID { get; set; }
        public long FinPeriodID { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string ChequeNo { get; set; }
        public long CashBankAccountID { get; set; }
        public long AccountID { get; set; }
        public long AccountVoucherID { get; set; }
        public long VoucherTypeID { get; set; }
        public byte rstate { get; set; }
        public Nullable<long> rcuid { get; set; }
        public System.DateTime rcdt { get; set; }
        public Nullable<long> reuid { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblAccount tblAccount1 { get; set; }
        public virtual tblAccountVoucher tblAccountVoucher { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
        public virtual tblVoucherType tblVoucherType { get; set; }
    }
}
