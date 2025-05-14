using Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IProfesorMateriaService
    {
        Task<Result> ConsultarMatProf();
        Task<Result> ConsultarMatProfId(int idProfesor);
    }
}
