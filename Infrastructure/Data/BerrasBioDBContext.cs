using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BerrasBio.Core;

namespace BerrasBio.Infrastructure
{
    public partial class BerrasBioDBContext : DbContext
    {
        public BerrasBioDBContext()
        {
        }

        public BerrasBioDBContext(DbContextOptions<BerrasBioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Session> Session { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=BerrasBioDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.MovieNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Movie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_ToTable");
            });
        }
    }
}
