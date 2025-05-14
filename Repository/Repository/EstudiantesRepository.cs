using Commun;
using Domain.Model;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class EstudiantesRepository : IEstudiantesRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CrearEstudiante(EstudiantesModel model)
        {
            try
            {
                await _context.Estudiantes.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<List<EstudiantesModel>?> ConsultarEstudiante()
        {
            try
            {
                var lstResult = await _context.Estudiantes.AsQueryable().ToListAsync();
                return lstResult;
            }

            catch (Exception)
            {
                return new List<EstudiantesModel>();
                throw;
            }
        }

        public async Task<EstudiantesModel?> ConsultarEstudianteId(int id)
        {
            try
            {
                var estudiante = await _context.Estudiantes.Where(p => p.id == id).FirstOrDefaultAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return new EstudiantesModel();
                throw;
            }
        }

        public async Task<EstudiantesModel> ActualizarEstudiante(EstudiantesModel model)
        {
            try
            {
                var estudiante = await _context.Estudiantes.FindAsync(model.id);

                if (estudiante == null)
                {
                    return new EstudiantesModel();
                }

                _context.Update(estudiante);
                await _context.SaveChangesAsync();

                return estudiante;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new EstudiantesModel();
            }
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            try
            {
                var lstResult = await _context.Estudiantes.FirstAsync(x => x.id == id);
                _context.Estudiantes.Remove(lstResult);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<EstudiantesModel> AsociarMateriaEstudiante(EstudiantesModel asociar)
        {
            throw new NotImplementedException();
        }

        //public async Task<EstudiantesModel> AsociarMateriaEstudiante(EstudiantesAsociarDto asociar)
        //{
        //    // Obtener al estudiante con las materias asociadas
        //    var estudiante = await _context.Estudiantes
        //                                   .Include(e => e.Materias)
        //                                   .FirstOrDefaultAsync(e => e.id == asociar.id);

        //    if (estudiante == null)
        //    {
        //        throw new Exception("Estudiante no encontrado.");
        //    }

        //    // Validar límite de materias (3 máximo)
        //    if (estudiante.Materias.Count + asociar.idMateria.Count > 3)
        //        return new EstudiantesModel
        //        {
        //            Success = false,
        //            Message = "El estudiante no puede tener más de 3 materias"
        //        };

        //    // Asociar materias
        //    foreach (var materiaId in asociar.idMateria)
        //    {
        //        var materia = await _context.Materia.FindAsync(materiaId);
        //        if (materia != null && !estudiante.Materias.Any(m => m.id == materiaId))
        //        {
        //            estudiante.Materias.Add(materia);
        //        }
        //        return new EstudiantesModel
        //        {
        //            Success = true,
        //            Message = "Materias asociadas correctamente"
        //        };
        //    }

        //    await _context.SaveChangesAsync();

        //}



        //public async Task<EstudiantesModel> AsociarMateriaEstudiante(int estudianteId, int materiaId)
        //{
        //    Result oRespuesta = new();
        //    List<EstudiantesModel>? lstResult = new List<EstudiantesModel>();

        //    try
        //    {
        //        // Obtener al estudiante con las materias asociadas
        //        var estudiante = await _context.Estudiantes
        //                                         .Include(e => e.Materias)
        //                                         .FirstOrDefaultAsync(e => e.id == estudianteId);

        //        if (estudiante == null)
        //        {
        //            throw new Exception("Estudiante no encontrado.");
        //        }

        //        // Validar límite de materias (3 máximo)
        //        if (estudiante.Materias.Count + EstudiantesAsociarDto.idMateria.Count > 3)
        //            return Result<EstudiantesModel>.Failure("El estudiante no puede tener más de 3 materias");

        //        // Verificar si la materia está asociada
        //        if (estudiante.Materias.Any(m => m.id == materiaId))
        //            return estudiante; // El estudiante ya está inscrito en la materia

        //        // Obtener la materia
        //        var materia = await _context.Materia.FirstOrDefaultAsync(m => m.id == materiaId);

        //        if (materia == null)
        //        {
        //            throw new Exception("Materia no encontrada.");
        //        }

        //        // Asociar la materia al estudiante y guardar
        //        estudiante.Materias.Add(materia);
        //        await _context.SaveChangesAsync();

        //        return estudiante;
        //    }
        //    catch (Exception ex)
        //    {

        ////        throw new Exception("Error al asociar materia al estudiante: " + ex.Message);
        //    }
    }

}

