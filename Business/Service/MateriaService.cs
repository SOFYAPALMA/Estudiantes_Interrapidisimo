using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaR;

        public MateriaService(IMateriaRepository materiaR)
        {
            _materiaR = materiaR;
        }
        public async Task<Result> ConsultarMateriaId(int id)
        {
            MateriaModel? est_id = await _materiaR.ConsultarMateriaId(id);


            if (est_id != null)
            {
                MateriaDto dto = Mapper.GetMapper(est_id);

                Result result = new Result
                {
                    Success = true,
                    Message = "Materia encontrada",
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "Materia no encontrada"
                };
                return result;
            }
        }

        public async Task<Result> ConsultarMaterias()
        {
            List<MateriaModel>? materias = await _materiaR.ConsultarMaterias();
            List<MateriaDto> dto = Mapper.GetMapper(materias);
            Result result = new Result();
            result.Success = true;
            result.Data = dto;
            return result;
        }

    }
}
