﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(NinjaEquipmentDbContext))]
    partial class NinjaEquipmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("ValueInGold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Agility = 50,
                            Category = "Hand",
                            Intelligence = 100,
                            Name = "Golden Sword",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 2,
                            Agility = 50,
                            Category = "Hand",
                            Intelligence = 200,
                            Name = "Diamond Sword",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 3,
                            Agility = 50,
                            Category = "Hand",
                            Intelligence = 10,
                            Name = "Silver Sword",
                            Strength = 100,
                            ValueInGold = 5
                        },
                        new
                        {
                            Id = 4,
                            Agility = 50,
                            Category = "Head",
                            Intelligence = 100,
                            Name = "Golden Hat",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 5,
                            Agility = 50,
                            Category = "Head",
                            Intelligence = 200,
                            Name = "Diamond Hat",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 6,
                            Agility = 50,
                            Category = "Head",
                            Intelligence = 10,
                            Name = "Silver Hat",
                            Strength = 100,
                            ValueInGold = 5
                        },
                        new
                        {
                            Id = 7,
                            Agility = 50,
                            Category = "Chest",
                            Intelligence = 100,
                            Name = "Golden Chest",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 8,
                            Agility = 50,
                            Category = "Chest",
                            Intelligence = 200,
                            Name = "Diamond Chest",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 9,
                            Agility = 50,
                            Category = "Chest",
                            Intelligence = 10,
                            Name = "Silver Chest",
                            Strength = 100,
                            ValueInGold = 5
                        },
                        new
                        {
                            Id = 10,
                            Agility = 50,
                            Category = "Feet",
                            Intelligence = 100,
                            Name = "Golden Shoes",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 11,
                            Agility = 50,
                            Category = "Feet",
                            Intelligence = 200,
                            Name = "Diamond Shoes",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 12,
                            Agility = 50,
                            Category = "Feet",
                            Intelligence = 10,
                            Name = "Silver Shoes",
                            Strength = 100,
                            ValueInGold = 5
                        },
                        new
                        {
                            Id = 13,
                            Agility = 50,
                            Category = "Ring",
                            Intelligence = 100,
                            Name = "Golden Ring",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 14,
                            Agility = 50,
                            Category = "Ring",
                            Intelligence = 200,
                            Name = "Diamond Ring",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 15,
                            Agility = 50,
                            Category = "Ring",
                            Intelligence = 10,
                            Name = "Silver Ring",
                            Strength = 100,
                            ValueInGold = 5
                        },
                        new
                        {
                            Id = 16,
                            Agility = 50,
                            Category = "Necklace",
                            Intelligence = 100,
                            Name = "Golden Necklace",
                            Strength = 200,
                            ValueInGold = 10
                        },
                        new
                        {
                            Id = 17,
                            Agility = 50,
                            Category = "Necklace",
                            Intelligence = 200,
                            Name = "Diamond Necklace",
                            Strength = 400,
                            ValueInGold = 20
                        },
                        new
                        {
                            Id = 18,
                            Agility = 50,
                            Category = "Necklace",
                            Intelligence = 10,
                            Name = "Silver Necklace",
                            Strength = 100,
                            ValueInGold = 5
                        });
                });

            modelBuilder.Entity("Data.Models.Ninja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Ninjas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gold = 999999999,
                            Name = "Kees"
                        },
                        new
                        {
                            Id = 2,
                            Gold = 500000,
                            Name = "Willem"
                        },
                        new
                        {
                            Id = 3,
                            Gold = 10000,
                            Name = "Jan"
                        });
                });

            modelBuilder.Entity("Data.Models.NinjaEquipment", b =>
                {
                    b.Property<int>("NinjaId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ValueAtPurchase")
                        .HasColumnType("int");

                    b.HasKey("NinjaId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("NinjaEquipment");
                });

            modelBuilder.Entity("Data.Models.NinjaEquipment", b =>
                {
                    b.HasOne("Data.Models.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Ninja", "Ninja")
                        .WithMany("NinjaEquipment")
                        .HasForeignKey("NinjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Ninja");
                });

            modelBuilder.Entity("Data.Models.Ninja", b =>
                {
                    b.Navigation("NinjaEquipment");
                });
#pragma warning restore 612, 618
        }
    }
}
