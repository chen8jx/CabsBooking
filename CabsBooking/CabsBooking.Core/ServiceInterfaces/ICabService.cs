using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Reponse;
using CabsBooking.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.ServiceInterfaces
{
    public interface ICabService
    {
        Task<IEnumerable<CabTypes>> GetAllCabs();
        Task<CabBookingsDetailsResponse> GetCabDetails(int cabId);
        Task<CabTypes> AddCab(CabCreateRequest cabCreateRequest);
        Task<CabTypes> UpdateCab(CabCreateRequest cabCreateRequest);
        Task DeleteCab(int cabId);
    }
}
