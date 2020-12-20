using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Reponse;
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
    public class CabService : ICabService
    {
        private readonly ICabRepository _cabRepository;
        private readonly IBHistoryRepository _bHistoryRepository;
        private readonly IPlaceRepository _placesRepository;
        public CabService(ICabRepository cabRepository,
            IBHistoryRepository bHistoryRepository,
            IPlaceRepository placesRepository)
        {
            _cabRepository = cabRepository;
            _bHistoryRepository = bHistoryRepository;
            _placesRepository = placesRepository;
        }
        public async Task<IEnumerable<CabTypes>> GetAllCabs()
        {
            return await _cabRepository.ListAllAsync();
        }
        public async Task<CabBookingsDetailsResponse> GetCabDetails(int cabId)
        {
            //get cabs
            var dbCab = await _cabRepository.GetByIdAsync(cabId);

            var cabDetails = new CabBookingsDetailsResponse
            {
                CabTypeId = dbCab.CabTypeId,
                CabTypeName = dbCab.CabTypeName
            };
            var bookingDetail =await _cabRepository.GetBookingDetails(cabId);
            var bookings = new List<BookingDetailsReponse>();
            foreach (var booking in bookingDetail)
            {
                bookings.Add(new BookingDetailsReponse
                {
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    PickupAddress = booking.PickupAddress,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status,
                    Comp_Time = booking.Comp_Time,
                    Charge = booking.Charge,
                    Feedback = booking.Feedback,
                    Landmark = booking.Landmark,
                    Places = booking.Places
                });
            }
            cabDetails.Bookings = bookings;
            return cabDetails;
        }
        public async Task<CabTypes> AddCab(CabCreateRequest cabCreateRequest)
        {
            var dbCabName = await _cabRepository.GetCabByName(cabCreateRequest.CabTypeName);
            if (dbCabName != null)
            {
                throw new Exception("Cab Already Exist");
            }
            var cabType = new CabTypes
            {
                CabTypeName = cabCreateRequest.CabTypeName
            };
            var createCab = await _cabRepository.AddAsync(cabType);
            return createCab;
        }
        public async Task<CabTypes> UpdateCab(CabCreateRequest cabCreateRequest)
        {
            var cabType = new CabTypes
            {
                CabTypeId = cabCreateRequest.CabTypeId,
                CabTypeName = cabCreateRequest.CabTypeName
            };
            var updatCab = await _cabRepository.UpdateAsync(cabType);
            return updatCab;
        }
        public async Task DeleteCab(int cabId)
        {
            var cab = await _cabRepository.ListAsync(c => c.CabTypeId == cabId);
            await _cabRepository.DeleteAsync(cab.First());
        }
    }
}
