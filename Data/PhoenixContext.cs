using Microsoft.EntityFrameworkCore;
using Phoenix.Models;
using Phoenix.Domains;

namespace Phoenix.Data
{
    public class PhoenixContext : DbContext
    {
        public PhoenixContext (DbContextOptions<PhoenixContext> options)
            : base(options)
        {
        }

        public DbSet<Phoenix.Models.Profile> Profile { get; set; } = default!;

        public DbSet<Phoenix.Domains.Status> Status { get; set; }

        public DbSet<Phoenix.Models.User> User { get; set; }

        public DbSet<Phoenix.Models.Country> Country { get; set; }

        public DbSet<Phoenix.Models.State> State { get; set; }

        public DbSet<Phoenix.Domains.PersonType> PersonType { get; set; }

    }
}
