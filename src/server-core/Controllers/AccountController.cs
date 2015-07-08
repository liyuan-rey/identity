using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityNS.Server.Core.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public /*async Task<*/IHttpActionResult Register(/*UserModel userModel*/)
        {
            throw new NotImplementedException();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //IdentityResult result = await _repo.RegisterUser(userModel);

            //IHttpActionResult errorResult = GetErrorResult(result);

            //if (errorResult != null)
            //{
            //    return errorResult;
            //}
            //return Ok();
        }

        // GET api/Account/Login
        [AllowAnonymous]
        [Route("Login")]
        [HttpGet]
        public async Task<IHttpActionResult> Login( /*UserModel userModel*/)
        {
            return Ok();
        }
    }
}