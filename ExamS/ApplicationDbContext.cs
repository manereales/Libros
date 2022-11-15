using ExamS.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamS
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Reservacion>().HasKey(x => new { x.LibrosId, x.UsuariosId });
        }


        public DbSet<Libros> Libros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }

    }
}
