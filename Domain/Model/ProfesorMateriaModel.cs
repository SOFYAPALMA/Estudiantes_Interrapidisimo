using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class ProfesorMateriaModel
    {
        [ForeignKey("Materia")]
        public int idMateria { get; set; }

        [ForeignKey("Profesor")]
        public int idProfesor { get; set; }

        public ProfesorModel Profesor { get; set; }

        public MateriaModel Materia { get; set; }
    }
}
    