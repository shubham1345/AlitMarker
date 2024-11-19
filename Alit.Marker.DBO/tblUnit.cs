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
    
    public partial class tblUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUnit()
        {
            this.tblProducts = new HashSet<tblProduct>();
            this.tblPurchaseBillProductDetails = new HashSet<tblPurchaseBillProductDetail>();
            this.tblPurchaseReturnProductDetails = new HashSet<tblPurchaseReturnProductDetail>();
            this.tblSaleInvoiceProductDetails = new HashSet<tblSaleInvoiceProductDetail>();
            this.tblSaleOrderProductDetails = new HashSet<tblSaleOrderProductDetail>();
            this.tblSaleReturnProductDetails = new HashSet<tblSaleReturnProductDetail>();
        }
    
        public long UnitID { get; set; }
        public string UnitName { get; set; }
        public System.DateTime rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
        public byte rstate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseBillProductDetail> tblPurchaseBillProductDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseReturnProductDetail> tblPurchaseReturnProductDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleInvoiceProductDetail> tblSaleInvoiceProductDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleOrderProductDetail> tblSaleOrderProductDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleReturnProductDetail> tblSaleReturnProductDetails { get; set; }
    }
}
