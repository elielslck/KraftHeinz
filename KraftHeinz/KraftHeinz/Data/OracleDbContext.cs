using KraftHeinz.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace KraftHeinz.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }
        public DbSet<Reservoir> Reservoirs { get; set; }
        public DbSet<PowerPlant> PowerPlants { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>(entity =>
            {
                entity.ToTable("Factories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
                entity.Property(e => e.Region).HasColumnName("Region").HasMaxLength(50);
                // outras configurações
            });

            modelBuilder.Entity<Reservoir>(entity =>
            {
                entity.ToTable("Reservoirs");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
                entity.Property(e => e.Region).HasColumnName("Region").HasMaxLength(50);
                // outras configurações
            });

            modelBuilder.Entity<PowerPlant>(entity =>
            {
               entity.ToTable("PowerPlants");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
                entity.Property(e => e.Region).HasColumnName("Region").HasMaxLength(50);
                // outras configurações
            });
        }
    }
}