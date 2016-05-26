using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Core_OdeToCode.Entities
{
    public class OdeToCodeDbContext : IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
