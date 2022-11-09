using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
