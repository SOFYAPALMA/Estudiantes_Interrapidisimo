using Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IEstudianteMateriaService
    {
        Task<Result> ConsultarEstMat();
        Task<Result> ConsultarEstMatId(int idMateria);

    }
}
