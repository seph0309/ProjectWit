﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectWit.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WITEntities : DbContext
    {
        public WITEntities()
            : base("name=WITEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Wit_Category> Wit_Category { get; set; }
        public virtual DbSet<Wit_Company> Wit_Company { get; set; }
        public virtual DbSet<Wit_Item> Wit_Item { get; set; }
        public virtual DbSet<Wit_Order> Wit_Order { get; set; }
        public virtual DbSet<Wit_Role> Wit_Role { get; set; }
        public virtual DbSet<Wit_Status> Wit_Status { get; set; }
        public virtual DbSet<Wit_Table> Wit_Table { get; set; }
        public virtual DbSet<Wit_Transaction> Wit_Transaction { get; set; }
        public virtual DbSet<Wit_User> Wit_User { get; set; }
        public virtual DbSet<Wit_UserRole> Wit_UserRole { get; set; }
    }
}
