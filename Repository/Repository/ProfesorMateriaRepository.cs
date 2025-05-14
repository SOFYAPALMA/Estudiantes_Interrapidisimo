using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var lstResult = await _context.ProfesorMateria.AsQueryable().ToListAsync();
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
    }
}
