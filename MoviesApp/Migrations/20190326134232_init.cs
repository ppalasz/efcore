using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AppearedAsActor = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "Data",
                columns: table => new
                {
                    IdMovie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilmTitle = table.Column<string>(nullable: false),
                    IdGenre = table.Column<int>(nullable: true),
                    IdSecondaryGenre = table.Column<int>(nullable: true),
                    FinancialData_Revenue = table.Column<decimal>(nullable: false),
                    FinancialData_ProductionCost = table.Column<decimal>(nullable: false),
                    Year = table.Column<short>(maxLength: 4, nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.IdMovie);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_IdSecondaryGenre",
                        column: x => x.IdSecondaryGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieXActor",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieXActor", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieXActor_Person_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieXActor_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Data",
                        principalTable: "Movie",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieXActor_MovieId",
                table: "MovieXActor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressID",
                table: "Person",
                column: "AddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdGenre",
                schema: "Data",
                table: "Movie",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdSecondaryGenre",
                schema: "Data",
                table: "Movie",
                column: "IdSecondaryGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieXActor");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
