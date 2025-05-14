namespace Domain.Model
{
    public class EstudianteMateriaModel
    {
        public int idEstudiante { get; set; }

        public int idMateria { get; set; }

        // Relacion estudiante materia (muchos a muchos)
        public virtual ICollection<EstudiantesModel> Estudiantes { get; set; } = new List<EstudiantesModel>();

        public virtual ICollection<MateriaModel> Materias { get; set; } = new List<MateriaModel>();
    }
}
