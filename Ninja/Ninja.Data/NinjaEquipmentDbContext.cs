using Microsoft.EntityFrameworkCore;
using Ninja.Data.Models;

namespace Ninja.Data
{
    public class NinjaEquipmentDbContext : DbContext
    {
        public NinjaEquipmentDbContext(DbContextOptions<NinjaEquipmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasKey(i => new { i.UserId, i.EquipmentId });

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.User)
                .WithMany(u => u.Inventories)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Equipment)
                .WithMany(e => e.Inventories)
                .HasForeignKey(i => i.EquipmentId);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(p => p.User)
                .WithMany(u => u.PurchaseHistories)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(p => p.Equipment)
                .WithMany(e => e.PurchaseHistories)
                .HasForeignKey(p => p.EquipmentId);
        }
    }
}