using Domain.Model;

namespace Repository.IRepository
{
    public interface IEstudiantesRepository
    {
        /// <summary>
        /// Nelly Palma
        /// Metodo para Crear Estudiante
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CrearEstudiante(EstudiantesModel model);

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante
        /// </summary>
        /// <returns></returns>
        Task<List<EstudiantesModel>?> ConsultarEstudiante();

        /// <summary>
        /// Nelly Palma
        /// Metodo para Consultar Estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<EstudiantesModel?> ConsultarEstudianteId(int id);

        /// <summary>
        /// Nelly Palma
        /// Metodo para Actualizar Estudiante
        /// <param name="model"></param>
        /// <returns></returns>
        Task<EstudiantesModel> ActualizarEstudiante(EstudiantesModel model);

        /// <summary>
        /// Nelly Palma
        /// Metodo para Eliminar Estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> EliminarEstudiante(int id);
    }
}
