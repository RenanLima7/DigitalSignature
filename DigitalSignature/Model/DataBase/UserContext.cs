using DigitalSignature.Model;
using Microsoft.EntityFrameworkCore;

namespace DigitalSignatureAPI.Model.DataBase
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
