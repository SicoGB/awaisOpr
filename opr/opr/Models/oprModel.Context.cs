﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace opr.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class oprEntities : DbContext
    {
        public oprEntities()
            : base("name=oprEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<DefTable> DefTables { get; set; }
        public virtual DbSet<DefControl> DefControls { get; set; }
        public virtual DbSet<CustomeFeild> CustomeFeilds { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<school_campus> school_campus { get; set; }
        public virtual DbSet<school> schools { get; set; }
        public virtual DbSet<school_class> school_class { get; set; }
        public virtual DbSet<school_class_group> school_class_group { get; set; }
        public virtual DbSet<school_class_group_section> school_class_group_section { get; set; }
        public virtual DbSet<school_class_group_subjects> school_class_group_subjects { get; set; }
        public virtual DbSet<school_class_section> school_class_section { get; set; }
        public virtual DbSet<school_class_subjects> school_class_subjects { get; set; }
        public virtual DbSet<schoolleaveschedule> schoolleaveschedules { get; set; }
        public virtual DbSet<schooluser> schoolusers { get; set; }
    }
}
