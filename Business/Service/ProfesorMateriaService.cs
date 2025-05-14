using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class ProfesorMateriaService : IProfesorMateriaService
    {
        private readonly IProfesorMateriaRepository _profesorMatR;

        public ProfesorMateriaService(IProfesorMateriaRepository profesorMatR)
        {
            _profesorMatR = profesorMatR;
        }

        public async Task<Result> ConsultarMatProf()
        {
            List<ProfesorMateriaModel>? comentarios = await _profesorMatR.ConsultarMatProf();
            List<ProfesorMateriaDto> dto = Mapper.GetMapper(comentarios);
            Result result = new Result();
            result.Success = true;
            result.Data = dto;
            return result;
        }
        public async Task<Result> ConsultarMatProfId(int idProfesor)
        {
            ProfesorMateriaModel? est_id = await _profesorMatR.ConsultarMatProfId(idProfesor);


            if (est_id != null)
            {
                ProfesorMateriaDto dto = Mapper.GetMapper(est_id);

                Result result = new Result
                {
                    Success = true,
                    Message = "ProfesorMateria encontrado",
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "ProfesorMateria no encontrado"
                };
                return result;
            }
        }

    }
}

