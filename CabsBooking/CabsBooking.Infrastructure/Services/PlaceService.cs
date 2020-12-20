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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task<Places> AddPlace(PlaceCreateRequest placeCreateRequest)
        {
            var dbPlace = await _placeRepository.GetPlaceByName(placeCreateRequest.PlaceName);
            if (dbPlace != null)
            {
                throw new Exception("Place Already Exist");
            }
            var place = new Places
            {
                PlaceName = placeCreateRequest.PlaceName
            };
            var create = await _placeRepository.AddAsync(place);
            return create;
        }

        public async Task DeletePlace(int id)
        {
            var place = await _placeRepository.ListAsync(p => p.PlaceId == id);
            await _placeRepository.DeleteAsync(place.First());
        }

        public async Task<IEnumerable<Places>> GetAllPlaces()
        {
            return await _placeRepository.ListAllAsync();
        }

        public async Task<Places> UpdatePlace(PlaceCreateRequest placeCreateRequest)
        {
            var place = new Places
            {
                PlaceId = placeCreateRequest.PlaceId,
                PlaceName = placeCreateRequest.PlaceName
            };
            var update = await _placeRepository.UpdateAsync(place);
            return update;
        }
    }
}
