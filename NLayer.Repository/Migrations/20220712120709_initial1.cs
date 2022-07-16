using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaltPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imdb_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    production_companies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    production_countries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    revenue = table.Column<int>(type: "int", nullable: false),
                    runtime = table.Column<double>(type: "float", nullable: false),
                    spoken_languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenresId",
                table: "Movies",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
