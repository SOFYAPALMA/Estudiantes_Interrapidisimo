using Business.IService;
using Commun;
using Microsoft.AspNetCore.Mvc;

namespace CCL_Api.Controllers
{
    public class AuthController : Controller
    {
        private IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Route("Validate")]
        public async Task<Result> Validar(string Email, string Clave)
        {
            return await _auth.Validar(Email, Clave);
        }
    }
}
