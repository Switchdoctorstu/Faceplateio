﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace faceplateio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cloudDBEntities : DbContext
    {
        public cloudDBEntities()
            : base("name=cloudDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Script> Scripts { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Button> Buttons { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
    }
}
