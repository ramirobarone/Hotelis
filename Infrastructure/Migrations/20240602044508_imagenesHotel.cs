using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class imagenesHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPictures_Hotels_HotelId",
                table: "RoomPictures");

            migrationBuilder.DropIndex(
                name: "IX_RoomPictures_HotelId",
                table: "RoomPictures");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomPictures");

            migrationBuilder.CreateTable(
                name: "HotelPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(type: "longtext", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelPicture_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPicture_HotelId",
                table: "HotelPicture",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelPicture");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomPictures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomPictures_HotelId",
                table: "RoomPictures",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPictures_Hotels_HotelId",
                table: "RoomPictures",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
