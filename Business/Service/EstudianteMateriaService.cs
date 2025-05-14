using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class EstudianteMateriaService : IEstudianteMateriaService
    {
        private readonly IEstudianteMateriaRepository _estudianteMatR;

        public EstudianteMateriaService(IEstudianteMateriaRepository estudianteMatR)
        {
            _estudianteMatR = estudianteMatR;
        }
        
        public async Task<Result> ConsultarEstMat()
        {
            List<EstudianteMateriaModel>? comentarios = await _estudianteMatR.ConsultarEstMat();
            List<EstudianteMateriaDto> dto = Mapper.GetMapper(comentarios);
            Result result = new Result();
            result.Success = true;
            result.Data = dto;
            return result;
        }
        public async Task<Result> ConsultarEstMatId(int idMateria)
        {
            EstudianteMateriaModel? est_id = await _estudianteMatR.ConsultarEstMatId(idMateria);


            if (est_id != null)
            {
                EstudianteMateriaDto dto = Mapper.GetMapper(est_id);

                Result result = new Result
                {
                    Success = true,
                    Message = "EstudianteMateria encontrado",
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "EstudianteMateria no encontrado"
                };
                return result;
            }
        }

    }

}
