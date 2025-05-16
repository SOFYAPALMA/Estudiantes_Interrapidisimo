using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class ProfesorMateriaRepository : IProfesorMateriaRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfesorMateriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfesorMateriaModel>?> ConsultarMatProf()
        {
            try
            {
                var lstResult = await _context.ProfesorMateria.AsQueryable().Include(x=> x.Materia).Include(x => x.Profesor).ToListAsync();
                return lstResult;
            }
            catch (Exception)
            {
                return new List<ProfesorMateriaModel>();
                throw;
            }
        }

        public async Task<ProfesorMateriaModel?> ConsultarMatProfId(int idProfesor)
        {
            try
            {
                var estudiante = await _context.ProfesorMateria.Where(p => p.idProfesor == idProfesor).FirstOrDefaultAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return new ProfesorMateriaModel();
                throw;
            }
        }


        public async Task<bool> AsociarMateriaProfesor(int idProfesor, int idMateria)
        {
            try
            {
                // Obtener las materias que ya tiene el profesor
                var materiasAsociadas = await _context.ProfesorMateria
                    .Where(x => x.idProfesor == idProfesor)
                    .ToListAsync();

                if (materiasAsociadas.Count >= 2)

                {
                    throw new InvalidOperationException("El profesor ya tiene asociadas 2 materias.");
                }

                if (materiasAsociadas.Any(x => x.idMateria == idMateria))
                    return false;

                // Asociar nuevo 

                var nuevaAsociacion = new ProfesorMateriaModel
                {
                    idProfesor = idProfesor,
                    idMateria = idMateria
                };


                // Añadir y guardar el nuevo objeto en la base de datos
                await _context.ProfesorMateria.AddAsync(nuevaAsociacion);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ProfesorMateriaModel>?> ConsultarMatProf(int idprofesor)
        {
            try
            {
                var estudiante = await _context.ProfesorMateria.Where(p => p.idProfesor == idprofesor).ToListAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<List<ProfesorMateriaModel>?> ConsultarMatProf(int idprofesor, int idmateria)
        {
            try
            {
                var estudiante = await _context.ProfesorMateria.Where(p => p.idProfesor == idprofesor && p.idMateria == idmateria).ToListAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}
