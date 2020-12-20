using CabsBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabsBooking.Core.RepositoryInterfaces
{
    public interface IBookingRepository:IAsyncRepository<Bookings>
    {
        
    }
}
