using Microsoft.EntityFrameworkCore;

namespace test4.Entities
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

    }
}
