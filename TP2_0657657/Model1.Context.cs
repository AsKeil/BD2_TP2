﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2_0657657
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PROJETSESSIONBD20657657Entities : DbContext
    {
        public PROJETSESSIONBD20657657Entities()
            : base("name=PROJETSESSIONBD20657657Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Buse> Buses { get; set; }
        public virtual DbSet<ConfigLogique> ConfigLogiques { get; set; }
        public virtual DbSet<ConfigPhysique> ConfigPhysiques { get; set; }
        public virtual DbSet<Creation> Creations { get; set; }
        public virtual DbSet<Essaie> Essaies { get; set; }
        public virtual DbSet<EssaieFilament> EssaieFilaments { get; set; }
        public virtual DbSet<Fabricant> Fabricants { get; set; }
        public virtual DbSet<Filament> Filaments { get; set; }
        public virtual DbSet<Impression> Impressions { get; set; }
        public virtual DbSet<Imprimante> Imprimantes { get; set; }
        public virtual DbSet<LogTable> LogTables { get; set; }
        public virtual DbSet<ModeleImprimante> ModeleImprimantes { get; set; }
        public virtual DbSet<TypeFilament> TypeFilaments { get; set; }
        public virtual DbSet<Usager> Usagers { get; set; }
        public virtual DbSet<FilamentUtilise> FilamentUtilises { get; set; }
    }
}
