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
        }
        public DbSet<EstudiantesModel> Estudiantes { get; set; }
        public DbSet<MateriaModel> Materia { get; set; }
        public DbSet<ProfesorModel> Profesor { get; set; }

    }
}
