﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EpamStudy.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class autotransportesEPAMEntities : DbContext
    {
        public autotransportesEPAMEntities()
            : base("name=autotransportesEPAMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bases> Bases { get; set; }
        public virtual DbSet<Camiones> Camiones { get; set; }
        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<Gasolineras> Gasolineras { get; set; }
        public virtual DbSet<Gastos_Viaje> Gastos_Viaje { get; set; }
        public virtual DbSet<Rutas> Rutas { get; set; }
        public virtual DbSet<Viajes> Viajes { get; set; }
    }
}
