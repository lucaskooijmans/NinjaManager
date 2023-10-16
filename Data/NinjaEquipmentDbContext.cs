using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class NinjaEquipmentDbContext : DbContext
{
    public NinjaEquipmentDbContext(DbContextOptions<NinjaEquipmentDbContext> options) : base(options)
    {
    }
    // Default constructor for design-time operations
    public NinjaEquipmentDbContext()
    {
    }
    public DbSet<Ninja> Ninjas { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<NinjaEquipment> NinjaEquipment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the primary keys and foreign keys for the NinjaEquipment table.
        modelBuilder.Entity<NinjaEquipment>()
            .HasKey(ne => new { ne.NinjaId, ne.EquipmentId });

        // Define the many-to-many relationship between Ninja and Equipment.
        modelBuilder.Entity<NinjaEquipment>()
            .HasOne(ne => ne.Ninja)
            .WithMany(n => n.NinjaEquipment)
            .HasForeignKey(ne => ne.NinjaId);

        modelBuilder.Entity<NinjaEquipment>()
            .HasOne(ne => ne.Equipment)
            .WithMany()
            .HasForeignKey(ne => ne.EquipmentId);
    }
}