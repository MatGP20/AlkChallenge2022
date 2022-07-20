using AlkemyChallenge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlkChallenge_Disney.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Personaje> Personajes { get; set; }

        public DbSet<PeliculaSerie> PeliculaSeries { get; set; }

        public DbSet<PersonajeXPOS> PersonajeXPOss { get; set; }

        public DbSet<GeneroXPOS> GeneroXPOss { get; set; }

    }
}