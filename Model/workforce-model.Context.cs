﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class workforce_Entities : DbContext
    {
        public workforce_Entities()
            : base("name=workforce_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Industry_Details> Industry_Details { get; set; }
        public DbSet<Industry_Types> Industry_Types { get; set; }
        public DbSet<PO_Details> PO_Details { get; set; }
        public DbSet<Purchase_Categories> Purchase_Categories { get; set; }
    }
}