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
    
    public partial class tblPurchaseReturn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPurchaseReturn()
        {
            this.tblPurchaseReturnAdditionals = new HashSet<tblPurchaseReturnAdditional>();
            this.tblPurchaseReturnProductDetails = new HashSet<tblPurchaseReturnProductDetail>();
        }
    
        public long PurchaseReturnID { get; set; }
        public System.DateTime PurchaseReturnDate { get; set; }
        public Nullable<long> PurchaseReturnNoPrefixID { get; set; }
        public long PurchaseReturnNo { get; set; }
        public long CustomerAccountID { get; set; }
        public long PurchaseAccountID { get; set; }
        public long VoucherTypeID { get; set; }
        public long AccountVoucherID { get; set; }
        public decimal GrossAmt { get; set; }
        public decimal NetAmt { get; set; }
        public string PurchaseReturnMemo { get; set; }
        public System.DateTime rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public long CompanyID { get; set; }
        public long FinPeriodID { get; set; }
        public int MemoType { get; set; }
        public Nullable<long> StockVoucherID { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
        public Nullable<decimal> RoundOffAmt { get; set; }
        public Nullable<long> RoundOffAddLessID { get; set; }
        public byte rstate { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblAccount tblAccount1 { get; set; }
        public virtual tblAccountVoucher tblAccountVoucher { get; set; }
        public virtual tblAdditionalItemMaster tblAdditionalItemMaster { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
        public virtual tblStock tblStock { get; set; }
        public virtual tblVoucherType tblVoucherType { get; set; }
        public virtual tblPurchaseReturnNoPrefix tblPurchaseReturnNoPrefix { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseReturnAdditional> tblPurchaseReturnAdditionals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseReturnProductDetail> tblPurchaseReturnProductDetails { get; set; }
    }
}
