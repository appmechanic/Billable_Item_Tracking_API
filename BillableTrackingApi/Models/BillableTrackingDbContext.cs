using Microsoft.EntityFrameworkCore;
using BillableTrackingApi.Models;

namespace BillableTrackingApi.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SiteConfiguration> SiteConfigurations { get; set; }
        public DbSet<InsuranceCompanyRecord> InsuranceCompanies { get; set; }
        public DbSet<ReferralSourceRecord> ReferralSources { get; set; }
        public DbSet<PatientRecord> Patients { get; set; }
        public DbSet<BillableItemRecord> BillableItems { get; set; }
        public DbSet<BillableItemEventRecord> BillableItemEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure foreign key relationships
            modelBuilder.Entity<BillableItemEventRecord>()
                .HasOne(e => e.Patient)
                .WithMany()
                .HasForeignKey(e => e.PatientID)
                .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior if necessary

            modelBuilder.Entity<BillableItemEventRecord>()
                .HasOne(e => e.SelectedItem)
                .WithMany()
                .HasForeignKey(e => e.SelectedItemID)
                .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior if necessary
        }

public DbSet<BillableTrackingApi.Models.UserRecord> UserRecord { get; set; } = default!;

public DbSet<BillableTrackingApi.Models.HospitalRecord> HospitalRecord { get; set; } = default!;
    }

}
