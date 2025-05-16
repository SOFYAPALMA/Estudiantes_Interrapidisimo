using Domain.Model;

namespace Repository.IRepository
{
    public interface IEstudianteMateriaRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<EstudianteMateriaModel>?> ConsultarEstMat();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<EstudianteMateriaModel>?> ConsultarEstMat(int idEstudiante);      
        
        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<EstudianteMateriaModel>?> ConsultarEstMat(int idEstudiante, int idMateria);

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<EstudianteMateriaModel?> ConsultarEstMatId(int idMateria);

        Task<EstudianteMateriaModel> AsociarMateriaEstudiante(int idMateria, int idEstudiante);
    }

}
