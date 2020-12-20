using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Bookings>> GetAllBookings();
        Task<Bookings> AddBooking(BookingCreateRequest bookingCreateRequest);
        Task<Bookings> UpdateBooking(BookingCreateRequest bookingCreateRequest);
        Task DeleteBooking(int id);
    }
}
