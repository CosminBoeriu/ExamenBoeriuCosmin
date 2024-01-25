using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenBoeriuCosmin.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materii",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nume = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materii", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profesori",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nume = table.Column<string>(type: "TEXT", nullable: true),
                    prenume = table.Column<string>(type: "TEXT", nullable: true),
                    tip = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesori", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MaterieProfesor",
                columns: table => new
                {
                    Materiiid = table.Column<int>(type: "INTEGER", nullable: false),
                    Profesoriid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterieProfesor", x => new { x.Materiiid, x.Profesoriid });
                    table.ForeignKey(
                        name: "FK_MaterieProfesor_Materii_Materiiid",
                        column: x => x.Materiiid,
                        principalTable: "Materii",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterieProfesor_Profesori_Profesoriid",
                        column: x => x.Profesoriid,
                        principalTable: "Profesori",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterieProfesor_Profesoriid",
                table: "MaterieProfesor",
                column: "Profesoriid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterieProfesor");

            migrationBuilder.DropTable(
                name: "Materii");

            migrationBuilder.DropTable(
                name: "Profesori");
        }
    }
}
