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
    
    public partial class tblAccountGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccountGroup()
        {
            this.tblAccounts = new HashSet<tblAccount>();
            this.tblAccountGroup1 = new HashSet<tblAccountGroup>();
        }
    
        public long AccountGroupID { get; set; }
        public string AccountGroupName { get; set; }
        public Nullable<long> ParentGroupID { get; set; }
        public Nullable<byte> GroupNatureID { get; set; }
        public byte GroupTypeID { get; set; }
        public Nullable<bool> EffectsGrossProfit { get; set; }
        public bool DefaultGroup { get; set; }
        public long CompanyID { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<long> reuid { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public byte rstate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccount> tblAccounts { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountGroup> tblAccountGroup1 { get; set; }
        public virtual tblAccountGroup tblAccountGroup2 { get; set; }
    }
}
