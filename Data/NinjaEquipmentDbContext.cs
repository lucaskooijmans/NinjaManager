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

        // Dataseeding (test data)
        modelBuilder.Entity<Ninja>().HasData(
            new Ninja { Id = 1, Name = "Kees", Gold = 999999999 },
            new Ninja { Id = 2, Name = "Willem", Gold = 500000 },
            new Ninja { Id = 3, Name = "Jan", Gold = 10000 }
        );

        modelBuilder.Entity<Equipment>().HasData(
            new Equipment { Id = 1, Name = "Golden Sword", ValueInGold = 10, Category = "Hand", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 2, Name = "Diamond Sword", ValueInGold = 20, Category = "Hand", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 3, Name = "Silver Sword", ValueInGold = 5, Category = "Hand", Strength = 100, Intelligence = 10, Agility = 50 },
            new Equipment { Id = 4, Name = "Golden Hat", ValueInGold = 10, Category = "Head", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 5, Name = "Diamond Hat", ValueInGold = 20, Category = "Head", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 6, Name = "Silver Hat", ValueInGold = 5, Category = "Head", Strength = 100, Intelligence = 10, Agility = 50 },
            new Equipment { Id = 7, Name = "Golden Chest", ValueInGold = 10, Category = "Chest", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 8, Name = "Diamond Chest", ValueInGold = 20, Category = "Chest", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 9, Name = "Silver Chest", ValueInGold = 5, Category = "Chest", Strength = 100, Intelligence = 10, Agility = 50 },
            new Equipment { Id = 10, Name = "Golden Shoes", ValueInGold = 10, Category = "Feet", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 11, Name = "Diamond Shoes", ValueInGold = 20, Category = "Feet", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 12, Name = "Silver Shoes", ValueInGold = 5, Category = "Feet", Strength = 100, Intelligence = 10, Agility = 50 },
            new Equipment { Id = 13, Name = "Golden Ring", ValueInGold = 10, Category = "Ring", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 14, Name = "Diamond Ring", ValueInGold = 20, Category = "Ring", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 15, Name = "Silver Ring", ValueInGold = 5, Category = "Ring", Strength = 100, Intelligence = 10, Agility = 50 },
            new Equipment { Id = 16, Name = "Golden Necklace", ValueInGold = 10, Category = "Necklace", Strength = 200, Intelligence = 100, Agility = 50 },
            new Equipment { Id = 17, Name = "Diamond Necklace", ValueInGold = 20, Category = "Necklace", Strength = 400, Intelligence = 200, Agility = 50 },
            new Equipment { Id = 18, Name = "Silver Necklace", ValueInGold = 5, Category = "Necklace", Strength = 100, Intelligence = 10, Agility = 50 }
            );
    }
}