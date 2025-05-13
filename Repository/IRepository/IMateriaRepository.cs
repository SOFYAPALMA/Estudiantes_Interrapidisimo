using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IMateriaRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Materia
        /// </summary>
        /// <returns></returns>
        Task<List<MateriaModel>?> ConsultarMaterias();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Materia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MateriaModel>? ConsultarMateriaId(int id);

    }
}
