using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IProfesorRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Profesor
        /// </summary>
        /// <returns></returns>
        Task<List<ProfesorModel>?> ConsultarProfesores();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Profesor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProfesorModel>? ConsultarProfesorId(int id);
    }
}
