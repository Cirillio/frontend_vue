using Microsoft.EntityFrameworkCore;

namespace REST_API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<CartItem> cart { get; set; }
    }
}
