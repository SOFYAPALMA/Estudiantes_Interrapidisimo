using Commun;

namespace Business.IService
{
    public interface IAuth
    {
        Task<Result> Validar(string correo, string password);
    }
}
