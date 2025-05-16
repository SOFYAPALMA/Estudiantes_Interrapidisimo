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
        private readonly IMateriaRepository _materiaR;
        private readonly IEstudiantesRepository _estudiantesR;

        public EstudianteMateriaService(IEstudianteMateriaRepository estudianteMatR, IEstudiantesRepository estudiantesRep, IMateriaRepository materiaR)
        {
            _estudianteMatR = estudianteMatR;
            _estudiantesR = estudiantesRep;
            _materiaR = materiaR;

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

        public async Task<Result> AsociarMateriaEstudiante(int idEstudiante, int idMateria)
        {
            try
            {
                // validar estudiante
                var estudiante = await _estudiantesR.ConsultarEstudianteId(idEstudiante);
                if (estudiante == null)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "Estudiante no encontrado."
                    };
                }

                //Valida materia
                var materia = await _materiaR.ConsultarMateriaId(idMateria);
                if (materia == null)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "Materia no encontrada."
                    };
                }  
                
                // no asociar una materia existente
                var materias = await _estudianteMatR.ConsultarEstMat(idEstudiante, idMateria);
                if (materias?.Count != 0)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "El estudiante ya tiene esa materia asociada."
                    };
                }

                // 3 materias maximo
                var materiasActuales = await _estudianteMatR.ConsultarEstMat(idEstudiante);
                if (materiasActuales?.Count >= 3)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "El estudiante excede el máximo de 3 materias."
                    };
                }

                var asociadas = new List<EstudianteMateriaModel>();

                var nuevaAsociacion = await _estudianteMatR.AsociarMateriaEstudiante(idEstudiante, idMateria);
                asociadas.Add(nuevaAsociacion);

                return new Result
                {
                    Success = true,
                    Message = "Materias asociadas correctamente.",
                    Data = Mapper.GetMapper(asociadas)
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Success = false,
                    Message = $"Error al asociar materias: {ex.Message}"
                };
            }
        }

    }

}
