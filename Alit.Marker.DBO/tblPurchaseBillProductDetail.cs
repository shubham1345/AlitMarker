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
    
    public partial class tblPurchaseBillProductDetail
    {
        public long PurchaseBillProductDetailID { get; set; }
        public long PurchaseBillID { get; set; }
        public Nullable<long> ProductID { get; set; }
        public string Descr { get; set; }
        public decimal Quan { get; set; }
        public decimal Rate { get; set; }
        public long UnitID { get; set; }
        public decimal DiscPerc { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal GAmt { get; set; }
        public decimal NAmt { get; set; }
        public System.DateTime rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public long CompanyID { get; set; }
        public long FinPeriodID { get; set; }
        public int SNo { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
        public decimal Tax1Perc { get; set; }
        public Nullable<decimal> Tax1Amt { get; set; }
        public Nullable<long> Tax1ID { get; set; }
        public decimal Tax2Perc { get; set; }
        public Nullable<decimal> Tax2Amt { get; set; }
        public Nullable<long> Tax2ID { get; set; }
        public decimal Tax3Perc { get; set; }
        public Nullable<decimal> Tax3Amt { get; set; }
        public Nullable<long> Tax3ID { get; set; }
    
        public virtual tblAdditionalItemMaster tblAdditionalItemMaster { get; set; }
        public virtual tblAdditionalItemMaster tblAdditionalItemMaster1 { get; set; }
        public virtual tblAdditionalItemMaster tblAdditionalItemMaster2 { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
        public virtual tblProduct tblProduct { get; set; }
        public virtual tblPurchaseBill tblPurchaseBill { get; set; }
        public virtual tblUnit tblUnit { get; set; }
    }
}
