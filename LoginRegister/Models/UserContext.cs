
using Microsoft.EntityFrameworkCore;
 
namespace LoginRegister.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
    }
}