using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        public readonly  ApplicationDbContext _context;

        public MateriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MateriaModel>? ConsultarMateriaId(int id)
        {
            try
            {
                var materia = await _context.Materia.Where(p => p.id == id).FirstOrDefaultAsync();

                return materia;
            }
            catch (Exception ex)
            {
                return new MateriaModel();
                throw;
            }
        }

        public async Task<List<MateriaModel>?> ConsultarMaterias()
        {
            try
            {
                var lstResult = await _context.Materia.AsQueryable().ToListAsync();
                return lstResult;
            }

            catch (Exception)
            {
                return new List<MateriaModel>();
                throw;
            }
        }

        public Task<EstudianteMateriaModel>? EstudianteMateriaId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
