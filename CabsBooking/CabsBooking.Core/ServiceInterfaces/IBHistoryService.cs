using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.ServiceInterfaces
{
    public interface IBHistoryService
    {
        Task<IEnumerable<BookingsHistory>> GetAllBHistory();
        Task<BookingsHistory> AddBHistory(BHistoryCreateRequest bHistoryCreateRequest);
        Task<BookingsHistory> UpdateBHistory(BHistoryCreateRequest bHistoryCreateRequest);
        Task DeleteBHistory(int id);
    }
}
