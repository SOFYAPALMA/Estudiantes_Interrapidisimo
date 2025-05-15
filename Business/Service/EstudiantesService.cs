using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class EstudiantesService : IEstudiantesService
    {
        private readonly IEstudiantesRepository _estudiantesR;
        private readonly IMateriaRepository _materiaR;
        private readonly IProfesorRepository _profesorR;

        public EstudiantesService(IEstudiantesRepository estudiantesR, IMateriaRepository materiaR, IProfesorRepository profesorR)
        {
            _estudiantesR = estudiantesR;
            _materiaR = materiaR;
            _profesorR = profesorR;
        }
        public async Task<Result> CrearEstudiante(EstudiantesCrearDto crear)

        {
            EstudiantesModel model = Mapper.GetMapper(crear);

            var rs = await _estudiantesR.CrearEstudiante(model);

            Result result = new Result
            {
                Success = true,
                Message = "Estudiante creado con exito"
            };
            result.Success = rs;
            result.Data = rs;
            return result;
        }
        public async Task<Result> ConsultarEstudianteId(int id)
        {
            EstudiantesModel? est_id = await _estudiantesR.ConsultarEstudianteId(id);


            if (est_id != null)
            {
                EstudiantesDto dto = Mapper.GetMapper(est_id);

                Result result = new Result
                {
                    Success = true,
                    Message = "Estudiante encontrado",
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "Estudiante no encontrado"
                };
                return result;
            }
        }

        public async Task<Result> ConsultarEstudiantes()
        {
            List<EstudiantesModel>? comentarios = await _estudiantesR.ConsultarEstudiante();
            List<EstudiantesDto> dto = Mapper.GetMapper(comentarios);
            Result result = new Result();
            result.Success = true;
            result.Data = dto;
            return result;
        }
        public async Task<Result> ActualizarEstudiante(EstudiantesCrearDto estudiantes)
        {
            EstudiantesModel model = Mapper.GetMapper(estudiantes);
            Result oRespuesta = new();

            var rs = await _estudiantesR.ActualizarEstudiante(model);

            Result result = new Result
            {
                Success = false,
                Message = "Estudiante actualizado con exito"
            };
            result.Success = true;
            result.Data = rs;

            return result;
        }

        
        public async Task<Result> EliminarEstudiante(int id)
        {
            var rs = await _estudiantesR.EliminarEstudiante(id);
            Result result = new Result
            {
                Success = false,
                Message = "Estudiante eliminado con exito"
            };
            result.Success = true;
            result.Data = rs;

            return result;
        }


    }
}
