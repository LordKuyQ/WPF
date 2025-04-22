using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_Age.Migrations
{
    public partial class EnableAutoIncrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Измерения",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    давление = table.Column<int>(type: "INTEGER", nullable: false),
                    описание = table.Column<string>(type: "TEXT", nullable: false),
                    абсолютная_высота = table.Column<int>(type: "INTEGER", nullable: false),
                    расстояние = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Измерения", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Площадь",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    координаты = table.Column<int>(type: "INTEGER", nullable: false),
                    площадь = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Площадь", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Пользователь",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    тип_пользователя = table.Column<string>(type: "TEXT", nullable: false),
                    ФИО = table.Column<string>(type: "TEXT", nullable: false),
                    пароль = table.Column<string>(type: "TEXT", nullable: false),
                    емайл = table.Column<string>(type: "TEXT", nullable: false),
                    телефон = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Пользователь", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Проект",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    дата_начала = table.Column<DateOnly>(type: "DATE", nullable: false),
                    дата_конца = table.Column<DateOnly>(type: "DATE", nullable: false),
                    цена = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Проект", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Профиль",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    длина = table.Column<int>(type: "INTEGER", nullable: false),
                    высота = table.Column<int>(type: "INTEGER", nullable: false),
                    описание = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Профиль", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Пункты_наблюд",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    x = table.Column<int>(type: "INTEGER", nullable: false),
                    y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Пункты_наблюд", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "координаты_площади",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_площади = table.Column<int>(type: "INTEGER", nullable: false),
                    x = table.Column<int>(type: "INTEGER", nullable: false),
                    y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_координаты_площади", x => x.id);
                    table.ForeignKey(
                        name: "FK_координаты_площади_Площадь_id_площади",
                        column: x => x.id_площади,
                        principalTable: "Площадь",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "координаты_профиля",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_площади = table.Column<int>(type: "INTEGER", nullable: false),
                    x = table.Column<int>(type: "INTEGER", nullable: false),
                    y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_координаты_профиля", x => x.id);
                    table.ForeignKey(
                        name: "FK_координаты_профиля_Площадь_id_площади",
                        column: x => x.id_площади,
                        principalTable: "Площадь",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "список_площадей",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_проекта = table.Column<int>(type: "INTEGER", nullable: false),
                    id_площади = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_список_площадей", x => x.id);
                    table.ForeignKey(
                        name: "FK_список_площадей_Площадь_id_площади",
                        column: x => x.id_площади,
                        principalTable: "Площадь",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_список_площадей_Проект_id_проекта",
                        column: x => x.id_проекта,
                        principalTable: "Проект",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "список_участников",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_проекта = table.Column<int>(type: "INTEGER", nullable: false),
                    id_пользователя = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_список_участников", x => x.id);
                    table.ForeignKey(
                        name: "FK_список_участников_Пользователь_id_пользователя",
                        column: x => x.id_пользователя,
                        principalTable: "Пользователь",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_список_участников_Проект_id_проекта",
                        column: x => x.id_проекта,
                        principalTable: "Проект",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "список_профилей",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_площади = table.Column<int>(type: "INTEGER", nullable: false),
                    id_профиля = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_список_профилей", x => x.id);
                    table.ForeignKey(
                        name: "FK_список_профилей_Площадь_id_площади",
                        column: x => x.id_площади,
                        principalTable: "Площадь",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_список_профилей_Профиль_id_профиля",
                        column: x => x.id_профиля,
                        principalTable: "Профиль",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "список_измерений",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_пункта = table.Column<int>(type: "INTEGER", nullable: false),
                    id_измерения = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_список_измерений", x => x.id);
                    table.ForeignKey(
                        name: "FK_список_измерений_Измерения_id_измерения",
                        column: x => x.id_измерения,
                        principalTable: "Измерения",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_список_измерений_Пункты_наблюд_id_пункта",
                        column: x => x.id_пункта,
                        principalTable: "Пункты_наблюд",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "список_пунктов",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_профиля = table.Column<int>(type: "INTEGER", nullable: false),
                    id_пункта = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_список_пунктов", x => x.id);
                    table.ForeignKey(
                        name: "FK_список_пунктов_Профиль_id_профиля",
                        column: x => x.id_профиля,
                        principalTable: "Профиль",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_список_пунктов_Пункты_наблюд_id_пункта",
                        column: x => x.id_пункта,
                        principalTable: "Пункты_наблюд",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_координаты_площади_id_площади",
                table: "координаты_площади",
                column: "id_площади");

            migrationBuilder.CreateIndex(
                name: "IX_координаты_профиля_id_площади",
                table: "координаты_профиля",
                column: "id_площади");

            migrationBuilder.CreateIndex(
                name: "IX_список_измерений_id_измерения",
                table: "список_измерений",
                column: "id_измерения");

            migrationBuilder.CreateIndex(
                name: "IX_список_измерений_id_пункта",
                table: "список_измерений",
                column: "id_пункта");

            migrationBuilder.CreateIndex(
                name: "IX_список_площадей_id_площади",
                table: "список_площадей",
                column: "id_площади");

            migrationBuilder.CreateIndex(
                name: "IX_список_площадей_id_проекта",
                table: "список_площадей",
                column: "id_проекта");

            migrationBuilder.CreateIndex(
                name: "IX_список_профилей_id_площади",
                table: "список_профилей",
                column: "id_площади");

            migrationBuilder.CreateIndex(
                name: "IX_список_профилей_id_профиля",
                table: "список_профилей",
                column: "id_профиля");

            migrationBuilder.CreateIndex(
                name: "IX_список_пунктов_id_профиля",
                table: "список_пунктов",
                column: "id_профиля");

            migrationBuilder.CreateIndex(
                name: "IX_список_пунктов_id_пункта",
                table: "список_пунктов",
                column: "id_пункта");

            migrationBuilder.CreateIndex(
                name: "IX_список_участников_id_пользователя",
                table: "список_участников",
                column: "id_пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_список_участников_id_проекта",
                table: "список_участников",
                column: "id_проекта");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "координаты_площади");

            migrationBuilder.DropTable(
                name: "координаты_профиля");

            migrationBuilder.DropTable(
                name: "список_измерений");

            migrationBuilder.DropTable(
                name: "список_площадей");

            migrationBuilder.DropTable(
                name: "список_профилей");

            migrationBuilder.DropTable(
                name: "список_пунктов");

            migrationBuilder.DropTable(
                name: "список_участников");

            migrationBuilder.DropTable(
                name: "Измерения");

            migrationBuilder.DropTable(
                name: "Площадь");

            migrationBuilder.DropTable(
                name: "Профиль");

            migrationBuilder.DropTable(
                name: "Пункты_наблюд");

            migrationBuilder.DropTable(
                name: "Пользователь");

            migrationBuilder.DropTable(
                name: "Проект");
        }
    }
}
