namespace Domain.Model
{
    public class MateriaModel
    {
        public int id { get; set; }
        public string nombreMateria { get; set; }

        //Referencia Materias
       public virtual ICollection<EstudianteMateriaModel>? Estudiantes { get; set; } = new List<EstudianteMateriaModel>();
        public virtual ICollection<ProfesorMateriaModel>? Profesor { get; set; } = new List<ProfesorMateriaModel>();

    }
}
