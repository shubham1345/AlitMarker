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
    
    public partial class tblPurchaseReturnAdditional
    {
        public long PurchaseReturnAdditionalsID { get; set; }
        public long PurchaseReturnID { get; set; }
        public Nullable<long> AdditionalItemID { get; set; }
        public string Descr { get; set; }
        public int ItemNature { get; set; }
        public Nullable<decimal> Perc { get; set; }
        public decimal Amt { get; set; }
        public decimal AmtCalculatedOn { get; set; }
        public decimal UpdatedAmt { get; set; }
        public Nullable<bool> IsInclusive { get; set; }
        public Nullable<int> RecordType { get; set; }
        public Nullable<int> CalculateOnID { get; set; }
        public System.DateTime rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public long CompanyID { get; set; }
        public long FinPeriodID { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
    
        public virtual tblAdditionalItemMaster tblAdditionalItemMaster { get; set; }
        public virtual tblPurchaseReturn tblPurchaseReturn { get; set; }
    }
}
