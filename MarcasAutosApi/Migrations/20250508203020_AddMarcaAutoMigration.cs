using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarcasAutosApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMarcaAutoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaAuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    FoundedYear = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaAuto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MarcaAuto",
                columns: new[] { "Id", "Country", "Created", "FoundedYear", "ImageUrl", "IsActive", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, "United States", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1903, "https://www.ford.es/content/dam/guxeu/global-shared/header/ford_oval_blue_logo.svg", true, "Ford", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Germany", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1916, "https://www.bmw.com/etc.clientlibs/settings/wcm/designs/bmwcom/base/resources/ci2020/img/logo-bmw-com-gray.svg", true, "BMW", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Japan", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1920, "https://dealerinspire-shared-assets.s3.amazonaws.com/public/logos/mazda/mazda-dark-no-space-desktop-logo.png", true, "Mazda", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaAuto");
        }
    }
}
