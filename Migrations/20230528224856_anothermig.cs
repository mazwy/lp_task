using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lp_task.Migrations
{
    /// <inheritdoc />
    public partial class anothermig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleasePrice",
                table: "Movies",
                newName: "ReleasePricePerView");

            migrationBuilder.AddColumn<decimal>(
                name: "ReleasePricePerDay",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreditCard", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "f29b816d-cb41-4b4f-be39-4d60bc37fd4f", "1234-5678-9012-3456", "johndoe@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "d273a9c5-a445-4c69-aafb-87acb5b9b1f5", false, "johndoe@example.com" },
                    { "2", 0, "8a78e8db-9e67-4caa-82d3-213fc3bc4046", "5678-9012-3456-1234", "janedoe@example.com", false, "Jane", "Doe", false, null, null, null, null, null, false, "59f2cc9e-5211-4372-b78a-19b6b423d219", false, "janedoe@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "USA" },
                    { "2", "UK" },
                    { "3", "France" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "1", "Steven", "Spielberg" },
                    { "2", "Christopher", "Nolan" },
                    { "3", "Quentin", "Tarantino" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Action" },
                    { "2", "Comedy" },
                    { "3", "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CoverImage", "Description", "Duration", "FavoriteMovieIdMovie", "FavoriteMovieIdUser", "IdCountry", "IdDirector", "IdGenre", "MinAge", "ReleaseDate", "ReleasePricePerDay", "ReleasePricePerView", "RentalPricePerDay", "RentalPricePerView", "Title" },
                values: new object[,]
                {
                    { "1", "https://www.example.com/jurassic-park.jpg", "A theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", 127, null, null, "1", "1", "1", 13, new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m, 2.99m, 1.99m, 0.99m, "Jurassic Park" },
                    { "2", "https://www.example.com/the-dark-knight.jpg", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 152, null, null, "1", "2", "1", 16, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m, 3.99m, 2.99m, 1.99m, "The Dark Knight" },
                    { "3", "https://www.example.com/pulp-fiction.jpg", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 154, null, null, "1", "3", "3", 18, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m, 2.99m, 4.99m, 2.99m, "Pulp Fiction" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteMovies",
                columns: new[] { "IdMovie", "IdUser" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "1" },
                    { "3", "2" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "IdMovie", "IdUser", "Price", "RentalDate", "RentalType", "ReturnDate", "Returned" },
                values: new object[,]
                {
                    { "1", "1", "1", 0m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { "2", "2", "1", 0m, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2021, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { "3", "3", "2", 0m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2021, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumns: new[] { "IdMovie", "IdUser" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumns: new[] { "IdMovie", "IdUser" },
                keyValues: new object[] { "2", "1" });

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumns: new[] { "IdMovie", "IdUser" },
                keyValues: new object[] { "3", "2" });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "ReleasePricePerDay",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ReleasePricePerView",
                table: "Movies",
                newName: "ReleasePrice");
        }
    }
}
