namespace Domain.Model
{
    public class ProfesorModel
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public virtual ICollection<ProfesorMateriaModel> Materia{ get; set; } = new List<ProfesorMateriaModel>();

    }
}
