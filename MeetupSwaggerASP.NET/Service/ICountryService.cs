using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupSwaggerASP.NET.Service
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<int> AddOrUpdateCountry(Country country);

        Task<Country> GetCountryById(int id);
    }
}