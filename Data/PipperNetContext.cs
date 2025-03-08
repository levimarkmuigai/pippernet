using PipperNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PipperNet.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Wallet> Wallets { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ensure Subscription and Status are required (Optional)
            builder.Entity<ApplicationUser>()
                .Property(u => u.Subscription)
                .HasDefaultValue(string.Empty);

            builder.Entity<ApplicationUser>()
                .Property(u => u.Status)
                .HasDefaultValue(string.Empty);

            // Configure Wallet relationships
            builder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithOne()
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
