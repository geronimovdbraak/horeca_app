﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpf_ui_database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbPizzaCornerEntities : DbContext
    {
        public dbPizzaCornerEntities()
            : base("name=dbPizzaCornerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<ingredient> ingredients { get; set; }
        public virtual DbSet<menuItem> menuItems { get; set; }
    }
}
