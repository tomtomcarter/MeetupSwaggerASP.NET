using MeetupSwaggerASP.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupSwaggerASP.NET.Service
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAll();

        Task<int> AddOrUpdate(Location location);

        Task<Location> GetById(int id);
    }
}