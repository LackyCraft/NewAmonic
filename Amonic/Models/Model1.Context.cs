﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amonic.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Runtime.InteropServices;

    public partial class AmonicEntities : DbContext
    {
        private static AmonicEntities _getContext;

        public static AmonicEntities GetContext()
        {
            if (_getContext == null)
                _getContext = new AmonicEntities();
            return _getContext;
        }

        public AmonicEntities()
            : base("name=AmonicEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aircrafts> Aircrafts { get; set; }
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Amenities> Amenities { get; set; }
        public virtual DbSet<AmenitiesTickets> AmenitiesTickets { get; set; }
        public virtual DbSet<CabinTypes> CabinTypes { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<logService> logService { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TrackUser> TrackUser { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}