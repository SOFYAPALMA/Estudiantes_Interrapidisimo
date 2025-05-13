using Commun;

namespace Business.IService
{
    public interface IMateriaService
    {
        Task<Result> ConsultarMaterias();
        Task<Result> ConsultarMateriaId(int id);
    }
}
