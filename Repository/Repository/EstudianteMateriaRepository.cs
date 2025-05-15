using Commun;
using Domain.Model;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Repository.Data;
using Repository.IRepository;
using System.Xml.Schema;


namespace Repository.Repository
{
    public class EstudianteMateriaRepository : IEstudianteMateriaRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudianteMateriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstudianteMateriaModel>?> ConsultarEstMat()
        {
            try
            {
                var lstResult = await _context.EstudianteMateria.AsQueryable().ToListAsync();
                return lstResult;
            }

            catch (Exception)
            {
                return new List<EstudianteMateriaModel>();
                throw;
            }
        }

        public async Task<EstudianteMateriaModel?> ConsultarEstMatId(int idMateria)
        {
            try
            {
                var estudiante = await _context.EstudianteMateria.Where(p => p.idMateria == idMateria).FirstOrDefaultAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return null;
               
            }
        }

        public async Task<EstudianteMateriaModel> AsociarMateriaEstudiante(int idEstudiante, int idMateria)
        {

            try
            {
                // Obtener las materias que ya tiene asignadas el estudiante
                var materiasAsociadas = await _context.EstudianteMateria
                    .Where(x => x.idEstudiante == idEstudiante)
                    .ToListAsync();

                if (materiasAsociadas.Count >= 3)

                {
                    throw new InvalidOperationException("El estudiante ya tiene asociadas 3 materias.");
                }
                // Asociar nuevo estudiante

                var nuevaAsociacion = new EstudianteMateriaModel
                {
                    idEstudiante = idEstudiante,
                    idMateria = idMateria
                };


                // Añadir y guardar el nuevo objeto en la base de datos
                await _context.EstudianteMateria.AddAsync(nuevaAsociacion);
                await _context.SaveChangesAsync();
                return nuevaAsociacion;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al asociar materia al estudiante.", ex);
            }
        }
    }
}
