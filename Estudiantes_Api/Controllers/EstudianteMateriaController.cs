using Business.IService;
using Commun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteMateriaController : ControllerBase
    {
        private readonly IEstudianteMateriaService _estudianteMateriaServ;

        [HttpGet]
        [Route("ConsultarEstMat")]
        public async Task<Result> GetMaterias()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _estudianteMateriaServ.ConsultarEstMat();

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
        [Route("ConsultarEstMatId")]
        public async Task<Result> GetMateriasId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _estudianteMateriaServ.ConsultarEstMatId(id);

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
