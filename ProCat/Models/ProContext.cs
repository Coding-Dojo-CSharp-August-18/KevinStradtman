using Microsoft.EntityFrameworkCore;

namespace ProCat.Models
{
    public class ProContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ProContext(DbContextOptions<ProContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CatPro> categories_products { get; set; }
    }
}