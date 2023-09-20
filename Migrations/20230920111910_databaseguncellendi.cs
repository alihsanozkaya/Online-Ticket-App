using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Online_Ticket_App.Migrations
{
    /// <inheritdoc />
    public partial class databaseguncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketNo = table.Column<string>(type: "text", nullable: false),
                    ConcertId = table.Column<int>(type: "integer", nullable: true),
                    SportId = table.Column<int>(type: "integer", nullable: true),
                    TheaterId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "concerts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tickets_sports_SportId",
                        column: x => x.SportId,
                        principalTable: "sports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tickets_theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "theaters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_CategoryId",
                table: "tickets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_ConcertId",
                table: "tickets",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_SportId",
                table: "tickets",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TheaterId",
                table: "tickets",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_UserId",
                table: "tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
