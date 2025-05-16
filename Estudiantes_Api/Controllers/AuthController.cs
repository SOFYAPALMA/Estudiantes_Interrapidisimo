using Business.IService;
using Commun;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
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
        public async Task<Result> Validar(string correo, string password)
        {
            return await _auth.Validar(correo, password);
        }
    }
}
