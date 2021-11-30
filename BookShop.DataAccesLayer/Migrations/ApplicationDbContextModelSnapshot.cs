﻿// <auto-generated />
using System;
using BookShop.DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookShop.DataAccesLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookPurchaseHistory", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("PurchasesHistorieId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "PurchasesHistorieId");

                    b.HasIndex("PurchasesHistorieId");

                    b.ToTable("BookPurchaseHistory");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CoverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumperOfPages")
                        .HasColumnType("int");

                    b.Property<bool>("OnTop")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("PublishingHauseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("TypeOfBookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoverId");

                    b.HasIndex("PublishingHauseId");

                    b.HasIndex("TypeOfBookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Stars")
                        .HasMaxLength(10)
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Cover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Covers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Twarda"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Miękka"
                        });
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.PublishingHause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("PublishingHauses");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.PurchaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("ToPay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("PurchaseHistory");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.TypeOfBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfBook");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantazy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dramat"
                        });
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookPurchaseHistory", b =>
                {
                    b.HasOne("BookShop.DataAccesLayer.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccesLayer.Entities.PurchaseHistory", null)
                        .WithMany()
                        .HasForeignKey("PurchasesHistorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Book", b =>
                {
                    b.HasOne("BookShop.DataAccesLayer.Entities.Cover", "Cover")
                        .WithMany("Books")
                        .HasForeignKey("CoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccesLayer.Entities.PublishingHause", "PublishingHause")
                        .WithMany("Books")
                        .HasForeignKey("PublishingHauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccesLayer.Entities.TypeOfBook", "TypeOfBook")
                        .WithMany("Books")
                        .HasForeignKey("TypeOfBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cover");

                    b.Navigation("PublishingHause");

                    b.Navigation("TypeOfBook");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Comment", b =>
                {
                    b.HasOne("BookShop.DataAccesLayer.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.DataAccesLayer.Entities.Book", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.PurchaseHistory", b =>
                {
                    b.HasOne("BookShop.DataAccesLayer.Entities.User", "Buyer")
                        .WithMany("PurchasesHistorie")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.User", b =>
                {
                    b.HasOne("BookShop.DataAccesLayer.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Book", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Cover", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.PublishingHause", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.TypeOfBook", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookShop.DataAccesLayer.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PurchasesHistorie");
                });
#pragma warning restore 612, 618
        }
    }
}
