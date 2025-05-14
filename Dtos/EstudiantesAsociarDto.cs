namespace Dtos
{
    public class EstudiantesAsociarDto
    {
        public int id { get; set; }
        public string nombre { get; set; }

        // Relacion estudiante materia Id
        public List<int> idMateria { get; set; } = new List<int>();
    }
}

