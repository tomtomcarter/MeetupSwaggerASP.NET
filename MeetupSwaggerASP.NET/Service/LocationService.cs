using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MeetupSwaggerASP.NET.App_Start;
using MeetupSwaggerASP.NET.Models;

namespace MeetupSwaggerASP.NET.Service
{
    public class LocationService : ILocationService
    {
        public Task<int> AddOrUpdate(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("Location cannot be null");
            }
            if (ViewModelStore.Locations.Exists(c => c.Id == location.Id))
            {
                throw new InvalidOperationException("Location already exists");
            }

            // insert
            if (location.Id == null)
            {
                var newId = ViewModelStore.Locations.Max(c => c.Id).GetValueOrDefault() + 1;
                location.Id = newId;
            }

            ViewModelStore.Locations.Add(location);

            return Task.FromResult(location.Id.Value);
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await Task.FromResult(ViewModelStore.Locations);
        }

        public async Task<Location> GetById(int id)
        {
            return await Task.FromResult(ViewModelStore.Locations.Where(c => c.Id == id).FirstOrDefault());
        }


    }
}