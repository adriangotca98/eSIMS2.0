using Microsoft.EntityFrameworkCore;

namespace Proiect.Models
{
    public class MaterieContext : DbContext
    {
        public DbSet<Materie> Profesori { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                  //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Todos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materie>(
                 p =>
                 {
                     p.Property(p => p.Nume);
                     p.Property(p => p.Id);
                     p.Property(p => p.An);
                     p.Property(p => p.Semestru);

                 });
        }
    }
}
