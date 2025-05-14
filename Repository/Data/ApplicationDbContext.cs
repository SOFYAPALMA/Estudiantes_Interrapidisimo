using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(equals => equals.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
                       

            base.OnModelCreating(modelBuilder);

            // Configuración de la relación muchos a muchos entre Estudiantes y Materias
            modelBuilder.Entity<EstudiantesModel>()
                .HasMany(e => e.Materias) // Un estudiante tiene muchas materias
                .WithMany(m => m.Estudiantes) // Una materia tiene muchos estudiantes
                .UsingEntity<Dictionary<string, object>>(
                    "EstudianteMateria", // Nombre de la tabla intermedia
                    j => j.HasOne<MateriaModel>().WithMany().HasForeignKey("idMateria"), // Clave foránea para Materia
                    j => j.HasOne<EstudiantesModel>().WithMany().HasForeignKey("idEstudiante") // Clave foránea para Estudiante
                );
        }
        public DbSet<EstudiantesModel> Estudiantes { get; set; } 
        public DbSet<EstudianteMateriaModel> EstudianteMateria { get; set; }
        public DbSet<MateriaModel> Materia { get; set; }
        public DbSet<ProfesorMateriaModel> ProfesorMateria { get; set; }
        public DbSet<ProfesorModel> Profesor { get; set; }

    }
}
