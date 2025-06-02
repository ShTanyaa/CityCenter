using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityCenter.Migrations
{
    /// <inheritdoc />
    public partial class SvgMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ВидДеятельности",
                columns: table => new
                {
                    IDДеятельности = table.Column<int>(name: "ID_Деятельности", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ВидДеяте__64328B69758C284C", x => x.IDДеятельности);
                });

            migrationBuilder.CreateTable(
                name: "НазначенияПомещений",
                columns: table => new
                {
                    IDНазначения = table.Column<int>(name: "ID_Назначения", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Назначен__CB1EA4F902C954BF", x => x.IDНазначения);
                });

            migrationBuilder.CreateTable(
                name: "Роли",
                columns: table => new
                {
                    IDРоли = table.Column<int>(name: "ID_Роли", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Роли__3F882696F47105EF", x => x.IDРоли);
                });

            migrationBuilder.CreateTable(
                name: "SvgRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvgRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Помещения",
                columns: table => new
                {
                    IDПомещения = table.Column<int>(name: "ID_Помещения", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Расположение = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Этаж = table.Column<int>(type: "int", nullable: false),
                    Площадь = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    СтоимостьАренды = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ДоступноДляАренды = table.Column<bool>(type: "bit", nullable: false),
                    Фото = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Описание = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDНазначения = table.Column<int>(name: "ID_Назначения", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Помещени__DF905A4F2EB2470F", x => x.IDПомещения);
                    table.ForeignKey(
                        name: "FK__Помещения__ID_На__398D8EEE",
                        column: x => x.IDНазначения,
                        principalTable: "НазначенияПомещений",
                        principalColumn: "ID_Назначения");
                });

            migrationBuilder.CreateTable(
                name: "Пользователи",
                columns: table => new
                {
                    IDПользователя = table.Column<int>(name: "ID_Пользователя", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ФИО = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Телефон = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Пароль = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDРоли = table.Column<int>(name: "ID_Роли", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Пользова__A1478CAD8401136C", x => x.IDПользователя);
                    table.ForeignKey(
                        name: "FK__Пользоват__ID_Ро__4316F928",
                        column: x => x.IDРоли,
                        principalTable: "Роли",
                        principalColumn: "ID_Роли");
                });

            migrationBuilder.CreateTable(
                name: "Мероприятия",
                columns: table => new
                {
                    IDМероприятия = table.Column<int>(name: "ID_Мероприятия", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ДатаМероприятия = table.Column<DateTime>(type: "date", nullable: false),
                    IDПомещения = table.Column<int>(name: "ID_Помещения", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Мероприя__64E4CF809C75D0A0", x => x.IDМероприятия);
                    table.ForeignKey(
                        name: "FK__Мероприят__ID_По__5BE2A6F2",
                        column: x => x.IDПомещения,
                        principalTable: "Помещения",
                        principalColumn: "ID_Помещения");
                });

            migrationBuilder.CreateTable(
                name: "Арендаторы",
                columns: table => new
                {
                    IDАрендатора = table.Column<int>(name: "ID_Арендатора", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    КонтактнаяИнформация = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    НомерДоговора = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ДатаНачалаДоговора = table.Column<DateTime>(type: "date", nullable: true),
                    ДатаОкончанияДоговора = table.Column<DateTime>(type: "date", nullable: true),
                    Статус = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDПользователя = table.Column<int>(name: "ID_Пользователя", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Арендато__2CDA605951F51B5C", x => x.IDАрендатора);
                    table.ForeignKey(
                        name: "FK__Арендатор__ID_По__5535A963",
                        column: x => x.IDПользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_Пользователя");
                });

            migrationBuilder.CreateTable(
                name: "Аренда",
                columns: table => new
                {
                    IDАренды = table.Column<int>(name: "ID_Аренды", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDПомещения = table.Column<int>(name: "ID_Помещения", type: "int", nullable: false),
                    IDАрендатора = table.Column<int>(name: "ID_Арендатора", type: "int", nullable: false),
                    Цель = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ДатаНачала = table.Column<DateTime>(type: "date", nullable: false),
                    ДатаОкончания = table.Column<DateTime>(type: "date", nullable: false),
                    ДатаПоследнегоИзменения = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Аренда__1475B6F76682E109", x => x.IDАренды);
                    table.ForeignKey(
                        name: "FK__Аренда__ID_Аренд__60A75C0F",
                        column: x => x.IDАрендатора,
                        principalTable: "Арендаторы",
                        principalColumn: "ID_Арендатора");
                    table.ForeignKey(
                        name: "FK__Аренда__ID_Помещ__5FB337D6",
                        column: x => x.IDПомещения,
                        principalTable: "Помещения",
                        principalColumn: "ID_Помещения");
                });

            migrationBuilder.CreateTable(
                name: "ДеятельностьАрендатора",
                columns: table => new
                {
                    IdАрендатора = table.Column<int>(type: "int", nullable: false),
                    IdДеятельности = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Деятельн__AA9948EF409EA385", x => new { x.IdАрендатора, x.IdДеятельности });
                    table.ForeignKey(
                        name: "FK__Деятельно__ID_Ар__5812160E",
                        column: x => x.IdАрендатора,
                        principalTable: "Арендаторы",
                        principalColumn: "ID_Арендатора");
                    table.ForeignKey(
                        name: "FK__Деятельно__ID_Де__59063A47",
                        column: x => x.IdДеятельности,
                        principalTable: "ВидДеятельности",
                        principalColumn: "ID_Деятельности");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Аренда_ID_Арендатора",
                table: "Аренда",
                column: "ID_Арендатора");

            migrationBuilder.CreateIndex(
                name: "UQ_УникальнаяАренда",
                table: "Аренда",
                columns: new[] { "ID_Помещения", "ДатаНачала", "ДатаОкончания" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Арендаторы_ID_Пользователя",
                table: "Арендаторы",
                column: "ID_Пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_ДеятельностьАрендатора_IdДеятельности",
                table: "ДеятельностьАрендатора",
                column: "IdДеятельности");

            migrationBuilder.CreateIndex(
                name: "IX_Мероприятия_ID_Помещения",
                table: "Мероприятия",
                column: "ID_Помещения");

            migrationBuilder.CreateIndex(
                name: "IX_Пользователи_ID_Роли",
                table: "Пользователи",
                column: "ID_Роли");

            migrationBuilder.CreateIndex(
                name: "IX_Помещения_ID_Назначения",
                table: "Помещения",
                column: "ID_Назначения");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Аренда");

            migrationBuilder.DropTable(
                name: "ДеятельностьАрендатора");

            migrationBuilder.DropTable(
                name: "Мероприятия");

            migrationBuilder.DropTable(
                name: "SvgRooms");

            migrationBuilder.DropTable(
                name: "Арендаторы");

            migrationBuilder.DropTable(
                name: "ВидДеятельности");

            migrationBuilder.DropTable(
                name: "Помещения");

            migrationBuilder.DropTable(
                name: "Пользователи");

            migrationBuilder.DropTable(
                name: "НазначенияПомещений");

            migrationBuilder.DropTable(
                name: "Роли");
        }
    }
}
