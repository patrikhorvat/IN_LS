using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Services.Messaging.Genres;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InfoNovitas.LoginSample.Web.Api.Controllers

{
    [Authorize]
    [RoutePrefix("api/genres")]
    public class GenresController : ApiController
    {
        private IGenreService _service;

        public GenresController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetGenresRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var response = _service.GetGenres(request);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(
                new
                {
                    books = response.Genres.MapToViewModels()
                }
            );
        }
    }
}
