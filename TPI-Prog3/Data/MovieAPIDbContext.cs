using Microsoft.EntityFrameworkCore;
using TPI_Prog3.Models.DocumentalModels;
using TPI_Prog3.Models.MovieModels;
using TPI_Prog3.Models.SerieModels;

namespace TPI_Prog3.Data
{
    public class MovieAPIDbContext : DbContext
    {
        public MovieAPIDbContext(DbContextOptions options) : base(options)
        {


        }

        //Tablas que se van a usar en la base de datos
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Documental> Documentals { get; set; }
        public DbSet<Serie> Series { get; set; }

    }
}
