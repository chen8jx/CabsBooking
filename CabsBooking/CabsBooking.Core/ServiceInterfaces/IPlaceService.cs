using CabsBooking.Core.Entities;
using CabsBooking.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<Places>> GetAllPlaces();
        Task<Places> AddPlace(PlaceCreateRequest placeCreateRequest);
        Task<Places> UpdatePlace(PlaceCreateRequest placeCreateRequest);
        Task DeletePlace(int id);
    }
}
