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
    
    public partial class tblUserGroupPerimission
    {
        public long UserGroupPermissionID { get; set; }
        public long UserGroupID { get; set; }
        public long MenuOptionID { get; set; }
        public bool CanRead { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public Nullable<System.DateTime> rcdt { get; set; }
        public Nullable<System.DateTime> redt { get; set; }
        public Nullable<long> rcuid { get; set; }
        public Nullable<long> reuid { get; set; }
    
        public virtual tblUserGroup tblUserGroup { get; set; }
    }
}
