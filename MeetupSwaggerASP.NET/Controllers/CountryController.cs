using MeetupSwaggerASP.NET.Models;
using MeetupSwaggerASP.NET.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MeetupSwaggerASP.NET.Controllers
{
    /// <summary>
    /// Regroups all oprations directly related to a country
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Country> result = null;

            try
            {
                result = await _countryService.GetAllCountries();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            Country result = null;

            try
            {
                result = await _countryService.GetCountryById(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //// POST: api/Country
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Country/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
    }
}