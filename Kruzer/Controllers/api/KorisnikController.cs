using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kruzer.Controllers.api
{
    public class KorisnikController : ApiController
    {
        public IKorisnikService _korisnikService;
        public KorisnikController(IKorisnikService korisnikService)
        {
            this._korisnikService = korisnikService;
        }

        [HttpPost]
        [Route("api/user/login")]

        public IHttpActionResult Login([FromBody]KorisnikModel korisnikData)
        {
            KorisnikModel result = this._korisnikService.Login(korisnikData);
            return Ok(result);
        }
        /*
        [HttpPut]
        [Route("api/user/register")]
        public IHttpActionResult Register([FromBody] KorisnikModel korisnikData)
        {
            bool result = this._korisnikService.Register(korisnikData);
            return Ok(result);
        }*/
    }
}
