using Business.IService;
using Commun;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        public readonly IProfesorService _profesorServ;

        public ProfesoresController(IProfesorService profesorS)
        {
            this._profesorServ = profesorS;
        }

        [HttpGet]
        [Route("ConsultarProfesores")]
        public async Task<Result> GetProfesor()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _profesorServ.ConsultarProfesores();

                oRespuesta.Success = vResult.Success;
                oRespuesta.Message = vResult.Message;
                oRespuesta.Data = vResult.Data;
            }
            catch (Exception ex)
            {
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

            }
            return (oRespuesta);
        }

        [HttpGet]
        [Route("ConsultarProfesorId")]
        public async Task<Result> GetProfesorId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _profesorServ.ConsultarProfesorId(id);

                oRespuesta.Success = vResult.Success;
                oRespuesta.Message = vResult.Message;
                oRespuesta.Data = vResult.Data;
            }
            catch (Exception ex)
            {
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

            }
            return (oRespuesta);
        }
    }
}
