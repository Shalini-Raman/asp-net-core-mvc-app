using Microsoft.EntityFrameworkCore;

namespace eMovieTickets.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
        }
        {

        }
    }
}
