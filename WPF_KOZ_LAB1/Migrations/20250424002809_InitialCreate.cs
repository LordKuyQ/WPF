using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_KOZ_LAB1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fio = table.Column<string>(type: "TEXT", nullable: false),
                    telefon = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<int>(type: "INTEGER", nullable: false),
                    type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false),
                    model = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skidka",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skidka", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bron",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dt_bron = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    inv_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bron", x => x.id);
                    table.ForeignKey(
                        name: "FK_bron_inventory_inv_id",
                        column: x => x.inv_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "zakaz",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    inv_id = table.Column<int>(type: "INTEGER", nullable: false),
                    time = table.Column<int>(type: "INTEGER", nullable: false),
                    clent_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zakaz", x => x.id);
                    table.ForeignKey(
                        name: "FK_zakaz_client_clent_id",
                        column: x => x.clent_id,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_zakaz_inventory_inv_id",
                        column: x => x.inv_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "zakaz_skidka",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_zakaz = table.Column<int>(type: "INTEGER", nullable: false),
                    id_skidka = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zakaz_skidka", x => x.id);
                    table.ForeignKey(
                        name: "FK_zakaz_skidka_skidka_id_skidka",
                        column: x => x.id_skidka,
                        principalTable: "skidka",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_zakaz_skidka_zakaz_id_zakaz",
                        column: x => x.id_zakaz,
                        principalTable: "zakaz",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bron_inv_id",
                table: "bron",
                column: "inv_id");

            migrationBuilder.CreateIndex(
                name: "IX_zakaz_clent_id",
                table: "zakaz",
                column: "clent_id");

            migrationBuilder.CreateIndex(
                name: "IX_zakaz_inv_id",
                table: "zakaz",
                column: "inv_id");

            migrationBuilder.CreateIndex(
                name: "IX_zakaz_skidka_id_skidka",
                table: "zakaz_skidka",
                column: "id_skidka");

            migrationBuilder.CreateIndex(
                name: "IX_zakaz_skidka_id_zakaz",
                table: "zakaz_skidka",
                column: "id_zakaz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bron");

            migrationBuilder.DropTable(
                name: "type");

            migrationBuilder.DropTable(
                name: "zakaz_skidka");

            migrationBuilder.DropTable(
                name: "skidka");

            migrationBuilder.DropTable(
                name: "zakaz");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "inventory");
        }
    }
}
