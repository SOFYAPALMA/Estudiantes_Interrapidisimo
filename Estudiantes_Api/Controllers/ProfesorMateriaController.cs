using Business.IService;
using Commun;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorMateriaController : ControllerBase
    {
        private readonly IProfesorMateriaService _profesorMateriaServ;

        public ProfesorMateriaController(IProfesorMateriaService profesorMateriaServ)
        {
            this._profesorMateriaServ = profesorMateriaServ;
        }

        [HttpGet]
        [Route("ConsultarMatProf")]
        public async Task<Result> ConsultarMatProf()
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
        public async Task<Result> ConsultarMatProfId(int id)
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

        [HttpPost]
        [Route("AsociarMateria")]
        public async Task<Result> AsociarMateriaProfesor([FromBody] ProfesorMateriaDto request)
        {
            Result oRespuesta = new();

            try
            {

                var vResult = await _profesorMateriaServ.AsociarMateriaProfesor(request.idProfesor, request.idMateria);

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
