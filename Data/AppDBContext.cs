using Microsoft.EntityFrameworkCore;

namespace BlazorServerDatabaseTutorial.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
