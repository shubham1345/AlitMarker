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
    
    public partial class tblGridLayout
    {
        public long GridLayoutID { get; set; }
        public Nullable<int> GridID { get; set; }
        public string Descr { get; set; }
        public string Layout { get; set; }
        public string PrintOptions { get; set; }
        public string PageSettings { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public Nullable<long> FinPerID { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<long> reuid { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
    
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblFinPeriod tblFinPeriod { get; set; }
    }
}
