namespace Dtos
{
    public class MateriaDto
    {        
        public int id { get; set; }
        public string nombreMateria { get; set; }

        // Lista de los estudiantes asociados ID
        public List<int> idEstudiante { get; set; }


    }
}
