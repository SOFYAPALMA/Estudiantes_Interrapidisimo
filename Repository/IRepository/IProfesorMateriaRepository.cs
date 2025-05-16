using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IProfesorMateriaRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<ProfesorMateriaModel>?> ConsultarMatProf();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<ProfesorMateriaModel>?> ConsultarMatProf(int idprofesor);      
        
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<ProfesorMateriaModel>?> ConsultarMatProf(int idprofesor, int idmateria);

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<ProfesorMateriaModel?> ConsultarMatProfId(int idProfesor);

        Task<bool> AsociarMateriaProfesor(int idProfesor, int idMateria);
    }
}
