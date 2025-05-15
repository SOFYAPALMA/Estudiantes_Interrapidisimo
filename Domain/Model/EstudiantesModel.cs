namespace Domain.Model
{
    public class EstudiantesModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string password { get; set; }


        // Relacion estudiante materia (muchos a muchos)
        public virtual ICollection<EstudianteMateriaModel> Materia { get; set; } = new List<EstudianteMateriaModel>();
    }
}
