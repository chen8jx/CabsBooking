using CabsBooking.Core.Entities;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabsBooking.Infrastructure.Repostories
{
    public class BookingRepository : EfRepository<Bookings>, IBookingRepository
    {
        public BookingRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
