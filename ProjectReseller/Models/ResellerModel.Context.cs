﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectReseller.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ResellerEntities1 : DbContext
    {
        public ResellerEntities1()
            : base("name=ResellerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<delivery> delivery { get; set; }
        public virtual DbSet<delivery_status> delivery_status { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<message_recipient> message_recipient { get; set; }
        public virtual DbSet<report> report { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<HomePageItemsView> HomePageItemsView { get; set; }
    }
}