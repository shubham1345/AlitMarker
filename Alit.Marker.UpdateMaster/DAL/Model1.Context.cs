﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alit.Marker.UpdateMaster.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A05B1F_markerupdateEntities : DbContext
    {
        public DB_A05B1F_markerupdateEntities()
            : base("name=DB_A05B1F_markerupdateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbldbUpdateScript> tbldbUpdateScripts { get; set; }
        public virtual DbSet<tblServiceRequestLog> tblServiceRequestLogs { get; set; }
        public virtual DbSet<tblSoftwareRegistration> tblSoftwareRegistrations { get; set; }
        public virtual DbSet<tblSoftwareVersion> tblSoftwareVersions { get; set; }
    }
}
