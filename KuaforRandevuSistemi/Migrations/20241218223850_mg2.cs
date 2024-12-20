using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuaforRandevuSistemi.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "Randevular",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_MusteriId",
                table: "Randevular",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Musteriler_MusteriId",
                table: "Randevular",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Musteriler_MusteriId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_MusteriId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "Randevular");
        }
    }
}
