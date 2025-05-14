namespace Domain.Model
{
    public class MateriaModel
    {
        public int id { get; set; }
        public string nombreMateria { get; set; }

        //Referencia Materias
       public virtual ICollection<EstudiantesModel>? Estudiantes { get; set; } = new List<EstudiantesModel>();

    }
}
