﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arctodus.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbArctodus_v2Entities : DbContext
    {
        public dbArctodus_v2Entities()
            : base("name=dbArctodus_v2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<modulo> modulo { get; set; }
        public virtual DbSet<operaciones> operaciones { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<rol_operacion> rol_operacion { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
