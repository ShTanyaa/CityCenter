using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityCenter.Migrations
{
    /// <inheritdoc />
    public partial class BackToSinglePurpose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Помещения__ID_На__398D8EEE",
                table: "Помещения");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SvgRooms");

            migrationBuilder.AlterColumn<string>(
                name: "StoreId",
                table: "SvgRooms",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Помещения_Расположение",
                table: "Помещения",
                column: "Расположение");

            migrationBuilder.CreateIndex(
                name: "IX_SvgRooms_StoreId",
                table: "SvgRooms",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Помещения_Назначения",
                table: "Помещения",
                column: "ID_Назначения",
                principalTable: "НазначенияПомещений",
                principalColumn: "ID_Назначения");

            migrationBuilder.AddForeignKey(
                name: "FK_SvgRooms_Помещения_StoreId",
                table: "SvgRooms",
                column: "StoreId",
                principalTable: "Помещения",
                principalColumn: "Расположение",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Помещения_Назначения",
                table: "Помещения");

            migrationBuilder.DropForeignKey(
                name: "FK_SvgRooms_Помещения_StoreId",
                table: "SvgRooms");

            migrationBuilder.DropIndex(
                name: "IX_SvgRooms_StoreId",
                table: "SvgRooms");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Помещения_Расположение",
                table: "Помещения");

            migrationBuilder.AlterColumn<string>(
                name: "StoreId",
                table: "SvgRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SvgRooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Помещения__ID_На__398D8EEE",
                table: "Помещения",
                column: "ID_Назначения",
                principalTable: "НазначенияПомещений",
                principalColumn: "ID_Назначения");
        }
    }
}
