using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Filters;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        // kaynak : https://github.com/cuongle/WebApi.Jwt


        [AllowAnonymous]
        [HttpPost]
        public string tokenZorunluDegil()
        {
            return "tokenZorunluDegil";
        }

        [JwtAuthentication]
        [HttpPost]
        public string tokenZorunlu()
        {
            return "tokenZorunlu";
        }

      
    }
}
