using Commun;

namespace Business.IService
{
    public interface IProfesorService
    {
        Task<Result> ConsultarProfesores();
        Task<Result> ConsultarProfesorId(int id);
    }
}
