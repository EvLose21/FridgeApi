﻿// <auto-generated />
using System;
using FridgeProduct.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FridgeProduct.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FridgeProduct.Entities.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FridgeId");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FridgeModelId")
                        .HasMaxLength(60)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("Fridges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            FridgeModelId = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                            Name = "One",
                            OwnerName = "First"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            FridgeModelId = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                            Name = "Two",
                            OwnerName = "Second"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7092"),
                            FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"),
                            Name = "Three",
                            OwnerName = "Third"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7093"),
                            FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"),
                            Name = "Four",
                            OwnerName = "Fourth"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7094"),
                            FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"),
                            Name = "Five",
                            OwnerName = "Fivth"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7095"),
                            FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb"),
                            Name = "Six",
                            OwnerName = "Sixth"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7096"),
                            FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb"),
                            Name = "Seven",
                            OwnerName = "Seventh"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7097"),
                            FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb"),
                            Name = "Eight",
                            OwnerName = "8th"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7098"),
                            FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                            Name = "Nine",
                            OwnerName = "Ninth"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7099"),
                            FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                            Name = "Ten",
                            OwnerName = "Tenth"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7100"),
                            FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                            Name = "Eleven",
                            OwnerName = "Eleventh"
                        },
                        new
                        {
                            Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7102"),
                            FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                            Name = "Twelve",
                            OwnerName = "Twelfth"
                        });
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                            Name = "Model1",
                            Year = 2014
                        },
                        new
                        {
                            Id = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"),
                            Name = "Model2",
                            Year = 2015
                        },
                        new
                        {
                            Id = new Guid("8523783c-d082-4805-90ce-b2d32147aedb"),
                            Name = "Model3",
                            Year = 2016
                        },
                        new
                        {
                            Id = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                            Name = "Model1v2",
                            Year = 2018
                        });
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.FridgeToProduct", b =>
                {
                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.HasKey("FridgeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeToProduct");

                    b.HasData(
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                            Quantity = 10
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                            Quantity = 10
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"),
                            Quantity = 2
                        },
                        new
                        {
                            FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                            ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProductName");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                            DefaultQuantity = 1,
                            Name = "Eggs"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"),
                            DefaultQuantity = 1,
                            Name = "Butter"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"),
                            DefaultQuantity = 1,
                            Name = "Meat"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"),
                            DefaultQuantity = 1,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"),
                            DefaultQuantity = 1,
                            Name = "Kefir"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                            DefaultQuantity = 1,
                            Name = "Sausage"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                            DefaultQuantity = 1,
                            Name = "Ice-cream"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                            DefaultQuantity = 1,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"),
                            DefaultQuantity = 1,
                            Name = "Cabbage"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"),
                            DefaultQuantity = 1,
                            Name = "Cake"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"),
                            DefaultQuantity = 1,
                            Name = "Onion"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf62"),
                            DefaultQuantity = 1,
                            Name = "Chicken"
                        },
                        new
                        {
                            Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf63"),
                            DefaultQuantity = 1,
                            Name = "Tomato"
                        });
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "772bba8a-79f6-4f79-91af-7fa9d69274bb",
                            ConcurrencyStamp = "95f4282a-e36d-44be-98fd-e9c030a9882a",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "0fbeaff7-df36-4957-8f01-2fb3edc86e88",
                            ConcurrencyStamp = "02724c26-9d17-4812-b5da-0cf4e2511fbb",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.Fridge", b =>
                {
                    b.HasOne("FridgeProduct.Entities.Models.FridgeModel", "FridgeModel")
                        .WithMany("Fridges")
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.FridgeToProduct", b =>
                {
                    b.HasOne("FridgeProduct.Entities.Models.Fridge", "Fridge")
                        .WithMany("FridgeToProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeProduct.Entities.Models.Product", "Product")
                        .WithMany("FridgeToProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FridgeProduct.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FridgeProduct.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeProduct.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FridgeProduct.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.Fridge", b =>
                {
                    b.Navigation("FridgeToProducts");
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.FridgeModel", b =>
                {
                    b.Navigation("Fridges");
                });

            modelBuilder.Entity("FridgeProduct.Entities.Models.Product", b =>
                {
                    b.Navigation("FridgeToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
