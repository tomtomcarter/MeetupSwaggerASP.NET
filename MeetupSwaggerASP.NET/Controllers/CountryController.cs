using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MeetupSwaggerASP.NET.Controllers
{
    /// <summary>
    /// Regroups all oprations directly related to a country
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class CountryController : ApiController
    {
        private readonly ICountryService _countryService;

        /// <summary>
        /// Main endpoint to interract with countries.
        /// </summary>
        /// <param name="countryService"></param>
        /// <remarks>Not the most sexy API endpoint, but hey, good enough for a demo !</remarks>
        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        /// <summary>
        /// Gets the list of all available countries.
        /// </summary>
        /// <returns>List of all countries.</returns>
        /// <remarks>Be aware the countries on Mars are not listed yet. Please update this backend API once Space X has achieved the massive leap in BFR production rate !</remarks>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Country>))]
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

            return Ok(result);
        }

        /// <summary>
        /// Gets the country corresponding to the provided identifier.
        /// </summary>
        /// <param name="id">The country identifier.</param>
        /// <returns>A country with the provided identifier.</returns>
        /// <remarks>Don't think I have coded more than 3 Ids.</remarks>
        /// <example>1 will give you France. Try 2 and 3 for fun.</example>
        [HttpGet]
        [ResponseType(typeof(Country))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Please provide a country id parameter as an integer")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Requested country not found.")]
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

        [HttpPost]
        public async Task<IHttpActionResult> Post(Country value)
        {
            try
            {
                await _countryService.AddOrUpdateCountry(value);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        //// PUT: api/Country/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
    }
}