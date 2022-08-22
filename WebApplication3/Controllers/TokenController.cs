using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication3.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [AllowAnonymous]
        [HttpPost]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }
    }
}
