using Bazzar.Domain.Advertisements.Entities;
using Bazzar.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bazzar.Infrastructures.Data.SQLServer
{
    public class AdvertisementDBContext : DbContext
    {
        public AdvertisementDBContext([NotNull] DbContextOptions options):base(options)
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
