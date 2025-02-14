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
    
    public partial class tblStock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStock()
        {
            this.tblPurchaseBills = new HashSet<tblPurchaseBill>();
            this.tblPurchaseReturns = new HashSet<tblPurchaseReturn>();
            this.tblSaleInvoices = new HashSet<tblSaleInvoice>();
            this.tblSaleReturns = new HashSet<tblSaleReturn>();
            this.tblStockPDetails = new HashSet<tblStockPDetail>();
        }
    
        public long VoucherID { get; set; }
        public int StockVoucherTypeID { get; set; }
        public System.DateTime VDate { get; set; }
        public long VNo { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<long> PriceListID { get; set; }
        public string Narration { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public long FinPeriodID { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
        public byte rstate { get; set; }
    
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
        public virtual tblPriceList tblPriceList { get; set; }
        public virtual tblProduct tblProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseBill> tblPurchaseBills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseReturn> tblPurchaseReturns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleInvoice> tblSaleInvoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleReturn> tblSaleReturns { get; set; }
        public virtual tblStockVoucherType tblStockVoucherType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStockPDetail> tblStockPDetails { get; set; }
    }
}
