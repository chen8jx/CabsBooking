using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Reponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.RepositoryInterfaces
{
    public interface ICabRepository :IAsyncRepository<CabTypes>
    {
        Task<CabTypes> GetCabByName(string name);
        Task<IEnumerable<BookingDetailsReponse>> GetBookingDetails(int cabId);
    }
}
