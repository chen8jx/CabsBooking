using CabsBooking.Core.Entities;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Infrastructure.Repostories
{
    public class PlaceRepository : EfRepository<Places>, IPlaceRepository
    {
        public PlaceRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Places> GetPlaceByName(string name)
        {
            return await _dbContext.Places.FirstOrDefaultAsync(p => p.PlaceName == name);
        }
    }
}
