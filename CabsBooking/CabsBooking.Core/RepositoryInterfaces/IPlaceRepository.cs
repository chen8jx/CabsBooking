using CabsBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.RepositoryInterfaces
{
    public interface IPlaceRepository : IAsyncRepository<Places>
    {
        Task<Places> GetPlaceByName(string name);
    }
}
