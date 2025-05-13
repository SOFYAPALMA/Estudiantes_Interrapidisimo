using Business.IService;
using Commun;
using Microsoft.AspNetCore.Mvc;

namespace Estudiantes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaService _materiaServ;

        public MateriasController(IMateriaService materiaS)
        {
            this._materiaServ = materiaS;
        }

        [HttpGet]
        [Route("ConsultarMaterias")]
        public async Task<Result> GetMaterias()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _materiaServ.ConsultarMaterias();

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
        [Route("ConsultarMateriaId")]
        public async Task<Result> GetMateriasId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _materiaServ.ConsultarMateriaId(id);

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
