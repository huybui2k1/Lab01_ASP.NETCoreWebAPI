﻿// <auto-generated />
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Condiments"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Confections"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Dairy Products"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Meat/Poudly"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Produce"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "SeaFood"
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "Beverages",
                            UnitPrice = 5000m,
                            UnitsInStock = 80
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductName = "Honda",
                            UnitPrice = 1000m,
                            UnitsInStock = 10
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ProductName = "Yamaha",
                            UnitPrice = 50000m,
                            UnitsInStock = 50
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 7,
                            ProductName = "Suzuki",
                            UnitPrice = 4000m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 7,
                            ProductName = "Mecedez",
                            UnitPrice = 2000m,
                            UnitsInStock = 70
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 5,
                            ProductName = "Vinfast",
                            UnitPrice = 3300m,
                            UnitsInStock = 10
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 2,
                            ProductName = "Ford",
                            UnitPrice = 7000m,
                            UnitsInStock = 60
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 4,
                            ProductName = "Toyota",
                            UnitPrice = 8000m,
                            UnitsInStock = 55
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.HasOne("BusinessObjects.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
