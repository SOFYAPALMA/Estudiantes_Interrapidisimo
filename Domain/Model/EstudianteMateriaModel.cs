namespace Domain.Model
{
    public class EstudianteMateriaModel
    {
        public int idEstudiante { get; set; }

        public int idMateria { get; set; }

        // Relacion estudiante materia (muchos a muchos)
        public EstudiantesModel Estudiante { get; set; }

        public MateriaModel Materia { get; set; }
    }
}
