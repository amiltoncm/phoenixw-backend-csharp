using Microsoft.EntityFrameworkCore;
using Phoenix.Domains;
using Phoenix.Models;

namespace Phoenix.Data
{
    public class PhoenixContext : DbContext
    {
        public PhoenixContext (DbContextOptions<PhoenixContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profile { get; set; } = default!;

        public DbSet<Phoenix.Domains.Status> Status { get; set; }

        public DbSet<Phoenix.Models.User> User { get; set; }

        public DbSet<Phoenix.Models.Country> Country { get; set; }

        public DbSet<Phoenix.Models.State> State { get; set; }

        public DbSet<Phoenix.Domains.PersonType> PersonType { get; set; }

        public DbSet<Phoenix.Models.City> City { get; set; }

        public DbSet<Phoenix.Domains.PublicPlace> PublicPlace { get; set; }

        public DbSet<Phoenix.Models.Person> Person { get; set; }

        public DbSet<Phoenix.Models.Bank> Bank { get; set; }

        public DbSet<Phoenix.Models.Account> Account { get; set; }

        public DbSet<Phoenix.Domains.PaymentType> PaymentType { get; set; }

        public DbSet<Phoenix.Models.PaymentMethod> PaymentMethod { get; set; }

        public DbSet<Phoenix.Domains.MovimentType> MovimentType { get; set; }

        public DbSet<Phoenix.Models.ChartAccounts> ChartAccounts { get; set; }

        public DbSet<Phoenix.Domains.PaymentIndication> PaymentIndication { get; set; }

        public DbSet<Phoenix.Models.PaymentTerm> PaymentTerm { get; set; }

        public DbSet<Phoenix.Models.PaymentTerm> PaymentTermMethod { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentTermMethod>()
                .HasKey(p => new { p.PaymentTermId, p.PaymentMethodId });
        }
        
        // Composite Keys
        public DbSet<Phoenix.Models.PaymentTermMethod> PaymentTermMethod_1 { get; set; }
        
        // Composite Keys
        public DbSet<Phoenix.Domains.AddressType> AddressType { get; set; }
        
        // Composite Keys
        public DbSet<Phoenix.Models.PersonAddress> PersonAddress { get; set; }

    }
}
