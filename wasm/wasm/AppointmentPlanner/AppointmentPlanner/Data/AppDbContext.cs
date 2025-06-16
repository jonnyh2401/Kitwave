using AppointmentPlanner.Client;
using AppointmentPlanner.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AppointmentPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Observation> Observations { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<CompanySite> CompanySites { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UpdateNote> UpdateNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanySite>()
                .HasKey(cs => new { cs.CompanyId, cs.SiteId });

            modelBuilder.Entity<CompanySite>()
                .HasOne(cs => cs.Company)
                .WithMany(c => c.CompanySites)
                .HasForeignKey(cs => cs.CompanyId);

            modelBuilder.Entity<CompanySite>()
                .HasOne(cs => cs.Site)
                .WithMany(s => s.CompanySites)
                .HasForeignKey(cs => cs.SiteId);

            modelBuilder.Entity<UpdateNote>()
    .HasKey(u => u.UpdateNoteId);

            modelBuilder.Entity<UpdateNote>()
                .HasOne<Observation>()
                .WithMany(o => o.Updates)
                .HasForeignKey(u => u.ObservationId);
        }

    }
}