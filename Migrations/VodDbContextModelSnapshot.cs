﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lp_task.Data;

#nullable disable

namespace lp_task.Migrations
{
    [DbContext(typeof(VodDbContext))]
    partial class VodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("lp_task.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "USA"
                        },
                        new
                        {
                            Id = "2",
                            Name = "UK"
                        },
                        new
                        {
                            Id = "3",
                            Name = "France"
                        });
                });

            modelBuilder.Entity("lp_task.Models.Director", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            FirstName = "Steven",
                            LastName = "Spielberg"
                        },
                        new
                        {
                            Id = "2",
                            FirstName = "Christopher",
                            LastName = "Nolan"
                        },
                        new
                        {
                            Id = "3",
                            FirstName = "Quentin",
                            LastName = "Tarantino"
                        });
                });

            modelBuilder.Entity("lp_task.Models.FavoriteMovie", b =>
                {
                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdMovie")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUser", "IdMovie");

                    b.HasIndex("IdMovie");

                    b.ToTable("FavoriteMovies");

                    b.HasData(
                        new
                        {
                            IdUser = "1",
                            IdMovie = "1"
                        },
                        new
                        {
                            IdUser = "1",
                            IdMovie = "2"
                        },
                        new
                        {
                            IdUser = "2",
                            IdMovie = "3"
                        });
                });

            modelBuilder.Entity("lp_task.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Action"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("lp_task.Models.Movie", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("FavoriteMovieIdMovie")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FavoriteMovieIdUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDirector")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ReleasePricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReleasePricePerView")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPricePerView")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdDirector");

                    b.HasIndex("IdGenre");

                    b.HasIndex("FavoriteMovieIdUser", "FavoriteMovieIdMovie");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CoverImage = "https://www.example.com/jurassic-park.jpg",
                            Description = "A theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                            Duration = 127,
                            IdCountry = "1",
                            IdDirector = "1",
                            IdGenre = "1",
                            MinAge = 13,
                            ReleaseDate = new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReleasePricePerDay = 4.99m,
                            ReleasePricePerView = 2.99m,
                            RentalPricePerDay = 1.99m,
                            RentalPricePerView = 0.99m,
                            Title = "Jurassic Park"
                        },
                        new
                        {
                            Id = "2",
                            CoverImage = "https://www.example.com/the-dark-knight.jpg",
                            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                            Duration = 152,
                            IdCountry = "1",
                            IdDirector = "2",
                            IdGenre = "1",
                            MinAge = 16,
                            ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReleasePricePerDay = 5.99m,
                            ReleasePricePerView = 3.99m,
                            RentalPricePerDay = 2.99m,
                            RentalPricePerView = 1.99m,
                            Title = "The Dark Knight"
                        },
                        new
                        {
                            Id = "3",
                            CoverImage = "https://www.example.com/pulp-fiction.jpg",
                            Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Duration = 154,
                            IdCountry = "1",
                            IdDirector = "3",
                            IdGenre = "3",
                            MinAge = 18,
                            ReleaseDate = new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReleasePricePerDay = 4.99m,
                            ReleasePricePerView = 2.99m,
                            RentalPricePerDay = 4.99m,
                            RentalPricePerView = 2.99m,
                            Title = "Pulp Fiction"
                        });
                });

            modelBuilder.Entity("lp_task.Models.Rental", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdMovie")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentalType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Returned")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdMovie");

                    b.HasIndex("IdUser");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            IdMovie = "1",
                            IdUser = "1",
                            Price = 0m,
                            RentalDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalType = 0,
                            ReturnDate = new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned = false
                        },
                        new
                        {
                            Id = "2",
                            IdMovie = "2",
                            IdUser = "1",
                            Price = 0m,
                            RentalDate = new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalType = 0,
                            ReturnDate = new DateTime(2021, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned = false
                        },
                        new
                        {
                            Id = "3",
                            IdMovie = "3",
                            IdUser = "2",
                            Price = 0m,
                            RentalDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalType = 0,
                            ReturnDate = new DateTime(2021, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned = false
                        });
                });

            modelBuilder.Entity("lp_task.Models.VodUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f29b816d-cb41-4b4f-be39-4d60bc37fd4f",
                            CreditCard = "1234-5678-9012-3456",
                            Email = "johndoe@example.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d273a9c5-a445-4c69-aafb-87acb5b9b1f5",
                            TwoFactorEnabled = false,
                            UserName = "johndoe@example.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8a78e8db-9e67-4caa-82d3-213fc3bc4046",
                            CreditCard = "5678-9012-3456-1234",
                            Email = "janedoe@example.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "59f2cc9e-5211-4372-b78a-19b6b423d219",
                            TwoFactorEnabled = false,
                            UserName = "janedoe@example.com"
                        });
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
                    b.HasOne("lp_task.Models.VodUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("lp_task.Models.VodUser", null)
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

                    b.HasOne("lp_task.Models.VodUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("lp_task.Models.VodUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lp_task.Models.FavoriteMovie", b =>
                {
                    b.HasOne("lp_task.Models.Movie", "Movie")
                        .WithMany("FavoriteMovies")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lp_task.Models.VodUser", "User")
                        .WithMany("FavoriteMovies")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lp_task.Models.Movie", b =>
                {
                    b.HasOne("lp_task.Models.Country", "Country")
                        .WithMany("Movies")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lp_task.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("IdDirector")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lp_task.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lp_task.Models.FavoriteMovie", null)
                        .WithMany("Movies")
                        .HasForeignKey("FavoriteMovieIdUser", "FavoriteMovieIdMovie");

                    b.Navigation("Country");

                    b.Navigation("Director");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("lp_task.Models.Rental", b =>
                {
                    b.HasOne("lp_task.Models.Movie", "Movie")
                        .WithMany("Rentals")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lp_task.Models.VodUser", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lp_task.Models.Country", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("lp_task.Models.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("lp_task.Models.FavoriteMovie", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("lp_task.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("lp_task.Models.Movie", b =>
                {
                    b.Navigation("FavoriteMovies");

                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("lp_task.Models.VodUser", b =>
                {
                    b.Navigation("FavoriteMovies");

                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}