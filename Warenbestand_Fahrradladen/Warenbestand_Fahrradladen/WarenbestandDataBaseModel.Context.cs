﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warenbestand_Fahrradladen
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Warenbestand_FahrradladenEntities : DbContext
    {
        public Warenbestand_FahrradladenEntities()
            : base("name=Warenbestand_FahrradladenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public virtual DbSet<log> log { get; set; }
        public virtual DbSet<Ware> Ware { get; set; }
    }
}