using CabsBooking.Core.Entities;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabsBooking.Infrastructure.Repostories
{
    public class BHistoryRepository : EfRepository<BookingsHistory>, IBHistoryRepository
    {
        public BHistoryRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
