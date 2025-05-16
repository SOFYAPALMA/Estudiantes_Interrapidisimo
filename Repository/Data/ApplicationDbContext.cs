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

            modelBuilder.Entity<ProfesorMateriaModel>()
                .HasKey(p => new { p.idProfesor, p.idMateria }); // Clave compuesta

            modelBuilder.Entity<ProfesorMateriaModel>()
                .HasOne(p => p.Profesor)
                .WithMany(p => p.Materia)
                .HasForeignKey(p => p.idProfesor);

            modelBuilder.Entity<ProfesorMateriaModel>()
                .HasOne(m => m.Materia)
                .WithMany(m => m.Profesor)
                .HasForeignKey(m => m.idMateria);

            // Configuración de la relación muchos a muchos entre Estudiantes y Materias
            modelBuilder.Entity<EstudianteMateriaModel>()
                .HasKey(e => new { e.idEstudiante, e.idMateria });

            // Relación entre Estudiante y EstudianteMateria
            modelBuilder.Entity<EstudianteMateriaModel>()
                .HasOne(e => e.Estudiante)
                .WithMany(e => e.Materia)
                .HasForeignKey(e => e.idEstudiante);

            // Relación entre Materia y EstudianteMateria
            modelBuilder.Entity<EstudianteMateriaModel>()
                .HasOne(m => m.Materia)
                .WithMany(m => m.Estudiantes)
                .HasForeignKey(m => m.idMateria);

        }
        public DbSet<EstudiantesModel> Estudiantes { get; set; }
        public DbSet<EstudianteMateriaModel> EstudianteMateria { get; set; }
        public DbSet<MateriaModel> Materia { get; set; }
        public DbSet<ProfesorMateriaModel> ProfesorMateria { get; set; }
        public DbSet<ProfesorModel> Profesor { get; set; }

    }
}
