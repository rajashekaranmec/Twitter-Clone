﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTwitterClone.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TwitterApplicationEntities : DbContext
    {
        public TwitterApplicationEntities()
            : base("name=TwitterApplicationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<TWEET> TWEETs { get; set; }
        public virtual DbSet<FOLLOWING> FOLLOWINGs { get; set; }
    }
}
