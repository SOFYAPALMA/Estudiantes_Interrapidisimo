using Domain.Model;
using Dtos;

namespace Business.Mapp
{
    public static class Mapper
    {
        public static List<EstudiantesDto> GetMapper(List<EstudiantesModel> listaEstudiantes)
        {
            var result = new List<EstudiantesDto>();

            foreach (var model in listaEstudiantes)
            {
                result.Add(GetMapper(model));
            }
            return result;
        }
        public static EstudiantesModel GetMapper(EstudiantesDto estudiante)
        {
            var result = new EstudiantesModel()
            {
                id = estudiante.id,
                nombre = estudiante.nombre,
            };
            return result;
        }
        internal static EstudiantesModel GetMapper(EstudiantesCrearDto estudianteCrear)
        {
            var result = new EstudiantesModel()
            {
                id = estudianteCrear.id,
                nombre = estudianteCrear.nombre,
                correo = estudianteCrear.correo,
                password = estudianteCrear.password,
               
            };
        
            return result;
        }        
        internal static EstudiantesDto GetMapper(EstudiantesModel estudianteModel)
        {
            var result = new EstudiantesDto()
            {
                id = estudianteModel.id,
                nombre = estudianteModel.nombre,
            };
            return result;
        }


        internal static List<MateriaDto> GetMapper(List<MateriaModel> listaMateria)
        {
            var result = new List<MateriaDto>();

            foreach (var materia in listaMateria)
            {
                result.Add(GetMapper(materia));
            }
            return result;
        }
        internal static MateriaModel GetMapper(MateriaDto materia)
        {
            var result = new MateriaModel()
            {
                id = materia.id,
                nombreMateria = materia.nombreMateria
            };
            return result;
        }
        internal static MateriaDto GetMapper(MateriaModel materia)
        {
            var result = new MateriaDto()
            {
                id = materia.id,
                nombreMateria = materia.nombreMateria
            };                
            return result;
        }


        internal static List<ProfesorDto> GetMapper(List<ProfesorModel> listaProfesor)
        {
            var result = new List<ProfesorDto>();

            foreach (var profesor in listaProfesor)
            {
                result.Add(GetMapper(profesor));
            }
            return result;
        }
        internal static ProfesorModel GetMapper(ProfesorDto profesor)
        {
            var result = new ProfesorModel()
            {
                id = profesor.id,
                nombre = profesor.nombre,                
            };
            return result;
        }
        internal static ProfesorDto GetMapper(ProfesorModel profesor)
        {
            var result = new ProfesorDto()
            {
                id = profesor.id,
                nombre = profesor.nombre,               
            };
            return result;
        }


        internal static List<EstudianteMateriaDto> GetMapper(List<EstudianteMateriaModel> listaEstMat)
        {
            var result = new List<EstudianteMateriaDto>();

            foreach (var materiaEs in listaEstMat)
            {
                result.Add(GetMapper(materiaEs));
            }
            return result;
        }
        internal static EstudianteMateriaModel GetMapperList(EstudianteMateriaDto materia)
        {
            var result = new EstudianteMateriaModel()
            {
                idEstudiante = materia.idEstudiante,
                idMateria = materia.idMateria
            };
            return result;
        }
        internal static EstudianteMateriaDto GetMapper(EstudianteMateriaModel materia)
        {
            var result = new EstudianteMateriaDto()
            {
                idEstudiante = materia.idEstudiante,
                idMateria = materia.idMateria
            };
            return result;
        }


        internal static List<ProfesorMateriaDto> GetMapper(List<ProfesorMateriaModel> listaEstMat)
        {
            var result = new List<ProfesorMateriaDto>();

            foreach (var materiaEs in listaEstMat)
            {
                result.Add(GetMapper(materiaEs));
            }
            return result;
        }
        internal static ProfesorMateriaModel GetMapper(ProfesorMateriaDto materia)
        {
            var result = new ProfesorMateriaModel()
            {
                idMateria = materia.idMateria,
                idProfesor = materia.idProfesor
            };
            return result;
        }
        internal static ProfesorMateriaDto GetMapper(ProfesorMateriaModel materia)
        {
            var result = new ProfesorMateriaDto()
            {
                idMateria = materia.idMateria,
                idProfesor = materia.idProfesor
            };
            return result;
        }

    }
}
