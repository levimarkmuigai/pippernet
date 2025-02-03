using PipperNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PipperNet.Data
{
  public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    // Tables
    public DbSet<Admin> Admin { get; set;}
    public DbSet<Subscription> Subscription { get; set;}
    public DbSet<Wallet> Wallet { get; set;}
    public DbSet<Payment> Payment { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // ApplicationUser <-> Subscription
      modelBuilder.Entity<ApplicationUser>()
        .HasOne(u => u.Subscription)
        .WithOne(s => s.ApplicationUser)
        .HasForeignKey<Subscription>(s => s.ApplicationUserId)
        .OnDelete(DeleteBehavior.Cascade);

      // ApplicationUser <-> Wallet 
      modelBuilder.Entity<ApplicationUser>()
        .HasOne(u => u.Wallet)
        .WithOne(w => w.ApplicationUser)
        .HasForeignKey<Wallet>(w => w.ApplicationUserId)
        .OnDelete(DeleteBehavior.Cascade);

      // ApplicationUser <-> Payments
      modelBuilder.Entity<ApplicationUser>()
        .HasMany(u => u.Payments)
        .WithOne(p => p.ApplicationUser)
        .HasForeignKey(p => p.ApplicationUserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}

