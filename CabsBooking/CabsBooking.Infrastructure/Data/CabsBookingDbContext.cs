using CabsBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabsBooking.Infrastructure.Data
{
    public class CabsBookingDbContext : DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(ConfigureBookings);
            modelBuilder.Entity<BookingsHistory>(ConfigureBookingsHistory);
        }
        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            builder.HasOne(c => c.CabTypes).WithMany(b => b.Bookings).HasForeignKey(r => r.CabTypeId);
            builder.HasOne(p => p.FromPlaces).WithMany(b => b.FromPlaces).HasForeignKey(r => r.FromPlace);
            builder.HasOne(p => p.ToPlaces).WithMany(b => b.ToPlaces).HasForeignKey(r => r.ToPlace);
            builder.Property(bd => bd.BookingDate).HasDefaultValueSql("cast(getdate() as date)");
            builder.Property(bd => bd.BookingTime).HasDefaultValueSql("convert(varchar(5),getdate(),108)");
            builder.Property(pd => pd.PickupDate).HasDefaultValueSql("cast(getdate() as date)");
            builder.Property(pd => pd.PickupTime).HasDefaultValueSql("convert(varchar(5),getdate(),108)");
        }
        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> builder)
        {
            builder.HasOne(c => c.CabTypes).WithMany(b => b.BookingsHistory).HasForeignKey(r => r.CabTypeId);
            builder.HasOne(p => p.FromHistory).WithMany(b => b.FromHistory).HasForeignKey(r => r.FromPlace);
            builder.HasOne(p => p.ToHistory).WithMany(b => b.ToHistory).HasForeignKey(r => r.ToPlace);
            
            builder.Property(bd => bd.BookingDate).HasDefaultValueSql("cast(getdate() as date)");
            builder.Property(bd => bd.BookingTime).HasDefaultValueSql("convert(varchar(5),getdate(),108)");
            builder.Property(pd => pd.PickupDate).HasDefaultValueSql("cast(getdate() as date)");
            builder.Property(pd => pd.PickupTime).HasDefaultValueSql("convert(varchar(5),getdate(),108)");
            builder.Property(c => c.Comp_Time).HasDefaultValueSql("convert(varchar(5),getdate(),108)");
        }
        public DbSet<CabTypes> CabTypes { get; set; }
        public DbSet<Places> Places { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistory { get; set; }
    }
}
