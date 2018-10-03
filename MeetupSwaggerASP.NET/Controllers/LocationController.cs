using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MeetupSwaggerASP.NET.Controllers
{
    /// <summary>
    /// Regroups all oprations directly related to a location
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class LocationController : ApiController
    {
        private readonly ILocationService _locationService;

        /// <summary>
        /// Main endpoint to interract with locations.
        /// </summary>
        /// <param name="locationService"></param>
        /// <remarks>Not the most sexy API endpoint, but hey, good enough for a demo !</remarks>
        public LocationController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        /// <summary>
        /// Gets the list of all available locations.
        /// </summary>
        /// <returns>List of all locations.</returns>
        /// <remarks>Be aware the locations are not GPS located.</remarks>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Location>))]
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Location> result = null;

            try
            {
                result = await _locationService.GetAll();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(Location))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.Conflict, "Most likely the provided location already exists")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Please provide a country id parameter as an integer")]
        public async Task<IHttpActionResult> Post(Location value)
        {
            try
            {
                var id = await _locationService.AddOrUpdate(value);
                value.Id = id;
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidOperationException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.Conflict, e.Message);
                throw new HttpResponseException(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok(value);
        }
    }
}