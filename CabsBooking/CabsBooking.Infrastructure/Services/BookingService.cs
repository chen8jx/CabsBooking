using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Request;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<Bookings> AddBooking(BookingCreateRequest bookingCreateRequest)
        {
            var booking = new Bookings
            {
                Email = bookingCreateRequest.Email,
                BookingDate = bookingCreateRequest.BookingDate,
                BookingTime = bookingCreateRequest.BookingTime,
                PickupAddress = bookingCreateRequest.PickupAddress,
                PickupDate = bookingCreateRequest.PickupDate,
                PickupTime = bookingCreateRequest.PickupTime,
                ContactNo = bookingCreateRequest.ContactNo,
                Landmark = bookingCreateRequest.Landmark,
                Status = bookingCreateRequest.Status,
                CabTypeId = bookingCreateRequest.CabTypeId,
                FromPlace = bookingCreateRequest.FromPlace,
                ToPlace = bookingCreateRequest.ToPlace
            };
            var create = await _bookingRepository.AddAsync(booking);
            return create;
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await _bookingRepository.ListAsync(i => i.Id == id);
            await _bookingRepository.DeleteAsync(booking.First());
        }

        public async Task<IEnumerable<Bookings>> GetAllBookings()
        {
            return await _bookingRepository.ListAllAsync();
        }

        public async Task<Bookings> UpdateBooking(BookingCreateRequest bookingCreateRequest)
        {
            var booking = new Bookings
            {
                Id = bookingCreateRequest.Id,
                Email = bookingCreateRequest.Email,
                BookingDate = bookingCreateRequest.BookingDate,
                BookingTime = bookingCreateRequest.BookingTime,
                PickupAddress = bookingCreateRequest.PickupAddress,
                PickupDate = bookingCreateRequest.PickupDate,
                PickupTime = bookingCreateRequest.PickupTime,
                ContactNo = bookingCreateRequest.ContactNo,
                Landmark = bookingCreateRequest.Landmark,
                Status = bookingCreateRequest.Status,
                CabTypeId = bookingCreateRequest.CabTypeId,
                FromPlace = bookingCreateRequest.FromPlace,
                ToPlace = bookingCreateRequest.ToPlace
            };
            var update = await _bookingRepository.UpdateAsync(booking);
            return update;
        }
    }
}
