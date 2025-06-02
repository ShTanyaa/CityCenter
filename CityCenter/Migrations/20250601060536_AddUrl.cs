using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityCenter.Migrations
{
    /// <inheritdoc />
    public partial class AddUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "СсылкаНаМагазин",
                table: "Помещения",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ЗаявкиНаАренду",
                columns: table => new
                {
                    IDЗаявки = table.Column<int>(name: "ID_Заявки", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDПользователя = table.Column<int>(name: "ID_Пользователя", type: "int", nullable: false),
                    IDПомещения = table.Column<int>(name: "ID_Помещения", type: "int", nullable: false),
                    ДатаЗаявки = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ФотоОплаты = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Комментарий = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Статус = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ЗаявкиНаАренду", x => x.IDЗаявки);
                    table.ForeignKey(
                        name: "FK_ЗаявкиНаАренду_Пользователи_ID_Пользователя",
                        column: x => x.IDПользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_Пользователя",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ЗаявкиНаАренду_Помещения_ID_Помещения",
                        column: x => x.IDПомещения,
                        principalTable: "Помещения",
                        principalColumn: "ID_Помещения",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ЗаявкиНаАренду_ID_Пользователя",
                table: "ЗаявкиНаАренду",
                column: "ID_Пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_ЗаявкиНаАренду_ID_Помещения",
                table: "ЗаявкиНаАренду",
                column: "ID_Помещения");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ЗаявкиНаАренду");

            migrationBuilder.DropColumn(
                name: "СсылкаНаМагазин",
                table: "Помещения");
        }
    }
}
