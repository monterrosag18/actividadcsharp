using Microsoft.EntityFrameworkCore;
using AnimeEventsWeb.Models;

namespace AnimeEventsWeb.Data
{
    // Contexto de base de datos para manejar la entidad Event a través de Entity Framework Core.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Mapeo a la tabla Events en MySQL
        public DbSet<Event> Events { get; set; }
    }
}
