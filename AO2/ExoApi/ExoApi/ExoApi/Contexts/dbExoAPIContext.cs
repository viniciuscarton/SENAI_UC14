using Microsoft.EntityFrameworkCore;
using ExoApi.Models;
namespace ExoApi.Contexts
{
    public class dbExoAPIContext:DbContext
    {
        public dbExoAPIContext()
        { 
        }
        public dbExoAPIContext(DbContextOptions<dbExoAPIContext>options):base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = CARRIE\\SQLEXPRESS; Initial Catalog = dbExoApi; User Id = sa; Password = 1234; Integrated Security = true; TrustServerCertificate=true");
            }
        }
        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
