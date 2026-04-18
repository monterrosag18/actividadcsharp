using Microsoft.EntityFrameworkCore;
using AnimeEventsWeb.Models;

namespace AnimeEventsWeb.Data
{
  
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Event> AnimeEvents { get; set; }
    }
}
