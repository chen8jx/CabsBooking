using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Reponse;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Infrastructure.Repostories
{
    public class CabRepository : EfRepository<CabTypes>, ICabRepository
    {
        public CabRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CabTypes> GetCabByName(string name)
        {
            return await _dbContext.CabTypes.FirstOrDefaultAsync(c => c.CabTypeName == name);
        }

        public async Task<IEnumerable<BookingDetailsReponse>> GetBookingDetails(int cabId)
        {
            var bookingDetails = await _dbContext.BookingsHistory.Where(c => c.CabTypeId == cabId)
                                          .Select(b => new BookingDetailsReponse
                                          {
                                              Email = b.Email,
                                              BookingDate = b.BookingDate,
                                              BookingTime = b.BookingTime,
                                              PickupAddress = b.PickupAddress,
                                              PickupDate = b.PickupDate,
                                              PickupTime = b.PickupTime,
                                              ContactNo = b.ContactNo,
                                              Status = b.Status,
                                              Comp_Time = b.Comp_Time,
                                              Charge = b.Charge,
                                              Feedback = b.Feedback,
                                              Landmark = b.Landmark,
                                              Places = new List<BookingDetailsReponse.PlacesResponseModel>()
                                              {
                                                  new BookingDetailsReponse.PlacesResponseModel
                                                  {
                                                    FromPlace = b.FromHistory.PlaceName,
                                                    ToPlace = b.ToHistory.PlaceName
                                                  }
                                              }
                                          }).ToListAsync();
            return bookingDetails;
        }
    }
}
