using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;


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
                return new EstudianteMateriaModel();
                throw;
            }
        }
    }
}
