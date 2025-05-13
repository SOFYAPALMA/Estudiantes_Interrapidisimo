using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _profesorR;
        public ProfesorService(IProfesorRepository profesorR)
        {
            _profesorR = profesorR;
        }

        public async Task<Result> ConsultarProfesorId(int id)
        {
            ProfesorModel? prof_id = await _profesorR.ConsultarProfesorId(id);


            if (prof_id != null)
            {
                ProfesorDto dto = Mapper.GetMapper(prof_id);

                Result result = new Result
                {
                    Success = true,
                    Message = "Profesor encontrado",
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "Profesor no encontrado"
                };
                return result;
            }
        }

        public async Task<Result> ConsultarProfesores()
        {
            List<ProfesorModel>? profesores = await _profesorR.ConsultarProfesores();
            List<ProfesorDto> dto = Mapper.GetMapper(profesores);
            Result result = new Result();
            result.Success = true;
            result.Data = dto;
            return result;
        }

    }
}
