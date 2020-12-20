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
    public class BHistoryService : IBHistoryService
    {
        private readonly IBHistoryRepository _bHistoryRepository;
        public BHistoryService(IBHistoryRepository bHistoryRepository)
        {
            _bHistoryRepository = bHistoryRepository;
        }
        public async Task<BookingsHistory> AddBHistory(BHistoryCreateRequest bHistoryCreateRequest)
        {
            var bHistory = new BookingsHistory
            {
                Email = bHistoryCreateRequest.Email,
                BookingDate = bHistoryCreateRequest.BookingDate,
                BookingTime = bHistoryCreateRequest.BookingTime,
                PickupAddress = bHistoryCreateRequest.PickupAddress,
                PickupDate = bHistoryCreateRequest.PickupDate,
                PickupTime = bHistoryCreateRequest.PickupTime,
                ContactNo = bHistoryCreateRequest.ContactNo,
                Landmark = bHistoryCreateRequest.Landmark,
                Status = bHistoryCreateRequest.Status,
                Comp_Time = bHistoryCreateRequest.Comp_Time,
                Charge = bHistoryCreateRequest.Charge,
                Feedback = bHistoryCreateRequest.Feedback,
                CabTypeId = bHistoryCreateRequest.CabTypeId,
                FromPlace = bHistoryCreateRequest.FromPlace,
                ToPlace = bHistoryCreateRequest.ToPlace
            };
            var create = await _bHistoryRepository.AddAsync(bHistory);
            return create;
        }

        public async Task DeleteBHistory(int id)
        {
            var bHistory = await _bHistoryRepository.ListAsync(b => b.Id == id);
            await _bHistoryRepository.DeleteAsync(bHistory.First());
        }

        public async Task<IEnumerable<BookingsHistory>> GetAllBHistory()
        {
            return await _bHistoryRepository.ListAllAsync();
        }

        public async Task<BookingsHistory> UpdateBHistory(BHistoryCreateRequest bHistoryCreateRequest)
        {
            var bHistory = new BookingsHistory
            {
                Id = bHistoryCreateRequest.Id,
                Email = bHistoryCreateRequest.Email,
                BookingDate = bHistoryCreateRequest.BookingDate,
                BookingTime = bHistoryCreateRequest.BookingTime,
                PickupAddress = bHistoryCreateRequest.PickupAddress,
                PickupDate = bHistoryCreateRequest.PickupDate,
                PickupTime = bHistoryCreateRequest.PickupTime,
                ContactNo = bHistoryCreateRequest.ContactNo,
                Landmark = bHistoryCreateRequest.Landmark,
                Status = bHistoryCreateRequest.Status,
                Comp_Time = bHistoryCreateRequest.Comp_Time,
                Charge = bHistoryCreateRequest.Charge,
                Feedback = bHistoryCreateRequest.Feedback,
                CabTypeId = bHistoryCreateRequest.CabTypeId,
                FromPlace = bHistoryCreateRequest.FromPlace,
                ToPlace = bHistoryCreateRequest.ToPlace
            };
            var update = await _bHistoryRepository.UpdateAsync(bHistory);
            return update;
        }
    }
}
