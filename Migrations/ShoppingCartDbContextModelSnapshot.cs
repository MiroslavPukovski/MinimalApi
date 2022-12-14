// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartList.Api;

#nullable disable

namespace ShoppingCartList.Api.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    partial class ShoppingCartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ShoppingCartList.Api.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<bool>("isPickedUp")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemName = "Soap",
                            Quantity = 3.0,
                            isPickedUp = false
                        },
                        new
                        {
                            Id = 2,
                            ItemName = "Bread",
                            Quantity = 2.0,
                            isPickedUp = true
                        },
                        new
                        {
                            Id = 3,
                            ItemName = "Shampoo",
                            Quantity = 1.0,
                            isPickedUp = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
