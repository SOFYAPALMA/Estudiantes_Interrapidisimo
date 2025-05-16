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
        private readonly IMateriaRepository _materiaR;
        private readonly IProfesorRepository _profesorR;


        public ProfesorMateriaService(IProfesorMateriaRepository profesorMatR, IMateriaRepository materiaR, IProfesorRepository profesorR)
        {
            _profesorMatR = profesorMatR;
            _materiaR = materiaR;
            _profesorR = profesorR;
        }

        public async Task<Result> AsociarMateriaProfesor(int idProfesor, int idMateria)
        {
            try
            {
                // obtener materias
                var profesor = await _profesorR.ConsultarProfesorId(idProfesor);
                if (profesor == null)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "profesor no encontrado."
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

                var materias = await _profesorMatR.ConsultarMatProf(idProfesor, idMateria);

                // Regla 1: El profesor puede dictar un máximo de 2 materias
                if(materias?.Count != 0)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "El profesor ya tiene asignada esa materia."
                    };
                }

                var materiasAsignadas = await _profesorMatR.ConsultarMatProf(idProfesor);

                // Regla 1: El profesor puede dictar un máximo de 2 materias
                if(materiasAsignadas?.Count >= 2)
                {
                    return new Result
                    {
                        Success = false,
                        Message = "El profesor ya tiene asignadas 2 materias como máximo."
                    };
                }

                // 3. Asociar al profesor con la nueva materia
                bool asociado = await _profesorMatR.AsociarMateriaProfesor(idProfesor, idMateria);

                if (asociado)
                {
                    return new Result
                    {
                        Success = true,
                        Message = "Materia asociada correctamente al profesor."
                    };
                }
                else
                {
                    return new Result
                    {
                        Success = false,
                        Message = "No se pudo asociar la materia al profesor."
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
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

