//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alit.Marker.Service.Update.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbldbUpdateScript
    {
        public int UpdateScriptID { get; set; }
        public int SoftwareVersionID { get; set; }
        public string dbScriptTitle { get; set; }
        public string dbScript { get; set; }
        public decimal ExecutionIndex { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
    }
}
