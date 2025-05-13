using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        public readonly ApplicationDbContext _context;

        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfesorModel>?> ConsultarProfesores()
        {
            try
            {
                var lstResult = await _context.Profesor.AsQueryable().ToListAsync();
                return lstResult;
            }

            catch (Exception)
            {
                return new List<ProfesorModel>();
                throw;
            }
        }

        public async Task<ProfesorModel>? ConsultarProfesorId(int id)
        {
            try
            {
                var estudiante = await _context.Profesor.Where(p => p.id == id).FirstOrDefaultAsync();

                return estudiante;
            }
            catch (Exception ex)
            {
                return new ProfesorModel();
                throw;
            }
        }
    }
}
