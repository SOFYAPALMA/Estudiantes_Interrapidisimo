using Commun;

namespace Business.IService
{
    public interface IEstudianteMateriaService
    {
        Task<Result> ConsultarEstMat();
        Task<Result> ConsultarEstMatId(int idMateria);
        Task<Result> AsociarMateriaEstudiante(int idEstudiante, int idMateria);
    }
}
