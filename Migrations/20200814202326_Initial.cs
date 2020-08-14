using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetWebApiWithRedis.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 1, new DateTime(1975, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Bradley Cooper" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 2, new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Brie Larson" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 3, new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Chris Hemsworth" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 4, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Chris Evans" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 5, new DateTime(1979, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Chris Pratt" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 6, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Leonardo DiCaprio" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 7, new DateTime(1975, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Kate Winslet" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "Gender", "Name" },
                values: new object[] { 8, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Zoë Saldaña" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");
        }
    }
}
