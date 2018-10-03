using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupSwaggerASP.NET.Service
{
    public class CountryService : ICountryService
    {
        public Task<int> AddOrUpdateCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("Country cannot be null");
            }
            if (ViewModelStore.Countries.Exists(c => c.Id == country.Id))
            {
                throw new InvalidOperationException("Country already exists");
            }

            // insert
            if (country.Id == null)
            {
                var newId = ViewModelStore.Countries.Max(c => c.Id).GetValueOrDefault() + 1;
                country.Id = newId;
            }

            ViewModelStore.Countries.Add(country);

            return Task.FromResult(country.Id.Value);
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await Task.FromResult(ViewModelStore.Countries);
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await Task.FromResult(ViewModelStore.Countries.Where(c => c.Id == id).FirstOrDefault());
        }
    }
}