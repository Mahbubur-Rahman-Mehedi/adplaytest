using ChinookTest.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChinookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {

        // GET api/tracks
        public HttpResponseMessage Get()
        {
            var value = TrackAPIDb.Tracks(0);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Get(int id)
        {
            var value = TrackAPIDb.Tracks(id);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        // DELETE api/tracks/5
        public HttpResponseMessage Delete(int id)
        {
            TrackAPIDb.DeleteTrack(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
