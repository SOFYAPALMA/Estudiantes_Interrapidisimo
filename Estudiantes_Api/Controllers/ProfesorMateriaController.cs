using Business.IService;
using Commun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorMateriaController : ControllerBase
    {
        private readonly IProfesorMateriaService _profesorMateriaServ;

        [HttpGet]
        [Route("ConsultarMatProf")]
        public async Task<Result> GetMaterias()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _profesorMateriaServ.ConsultarMatProf();

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
        [Route("ConsultarMatProfId")]
        public async Task<Result> GetMateriasId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _profesorMateriaServ.ConsultarMatProfId(id);

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
