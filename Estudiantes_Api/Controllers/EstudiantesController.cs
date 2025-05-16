using Business.IService;
using Commun;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesService _estudiantesServ;

        public EstudiantesController(IEstudiantesService estudiantesS)
        {
            this._estudiantesServ = estudiantesS;
        }

        [HttpPost]
        [Route("CrearEstudiante")]

        public async Task<Result> CrearEstudiante([FromBody] EstudiantesCrearDto estudiante)
        {
            try
            {
                return await _estudiantesServ.CrearEstudiante(estudiante);
            }
            catch (Exception ex)
            {
                Result oRespuesta = new();
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

                return oRespuesta;
            }
        }

        [HttpGet]
        [Route("ConsultarEstudiantes")]
        public async Task<Result> ConsultarEstudiantes()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _estudiantesServ.ConsultarEstudiantes();

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
        [Route("ConsultarEstudianteId")]
        public async Task<Result> ConsultarEstudianteId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _estudiantesServ.ConsultarEstudianteId(id);

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


        [HttpPut]
        [Route("ActualizarEstudiante")]
        public async Task<IActionResult> ActualizarEstudiante([FromBody] EstudiantesActualizarDto objModel)
        {
            Result oRespuesta = new();

            try
            {
                var vRespuesta = await _estudiantesServ.ActualizarEstudiante(objModel);

                oRespuesta.Success = vRespuesta.Success;
                oRespuesta.Message = vRespuesta.Message;
                oRespuesta.Data = vRespuesta.Data;
            }
            catch (Exception ex)
            {

                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete]
        [Route("EliminarEstudiante")]
        public async Task<Result> EliminarEstudiante(int id)
        {
            Result oRespuesta = new();
            try
            {
                var vRespuesta = await _estudiantesServ.EliminarEstudiante(id);

                oRespuesta.Success = vRespuesta.Success;
                oRespuesta.Message = vRespuesta.Message;
                oRespuesta.Data = vRespuesta.Data;
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
