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
                var estudianteExistente = await _context.Estudiantes.FindAsync(model.id);

                if (estudianteExistente == null)
                {
                    return new EstudiantesModel();
                }
                estudianteExistente.id = model.id;
                estudianteExistente.nombre = model.nombre;
                estudianteExistente.correo = model.correo;
                estudianteExistente.password = model.password;

                await _context.SaveChangesAsync();

                return estudianteExistente;
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

    }

}

