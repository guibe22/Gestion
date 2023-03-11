using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gestion.Server.Migrations
{
    /// <inheritdoc />
    public partial class inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    AporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.AporteId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAportado = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposAportes",
                columns: table => new
                {
                    TipoAporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta = table.Column<float>(type: "real", nullable: false),
                    Logrado = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAportes", x => x.TipoAporteId);
                });

            migrationBuilder.CreateTable(
                name: "AporteDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAporteId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    AporteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AporteDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AporteDetalles_Aportes_AporteId",
                        column: x => x.AporteId,
                        principalTable: "Aportes",
                        principalColumn: "AporteId");
                    table.ForeignKey(
                        name: "FK_AporteDetalles_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId");
                    table.ForeignKey(
                        name: "FK_AporteDetalles_TiposAportes_TipoAporteId",
                        column: x => x.TipoAporteId,
                        principalTable: "TiposAportes",
                        principalColumn: "TipoAporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposAportes",
                columns: new[] { "TipoAporteId", "Descripcion", "Logrado", "Meta" },
                values: new object[,]
                {
                    { 1, "Pintura Bancos", 0f, 10000f },
                    { 2, "Reparacion Techo", 0f, 20000f },
                    { 3, "Mantenimiento Piscina", 0f, 30000f },
                    { 4, "Cambio Mesas", 0f, 40000f },
                    { 5, "Compra Cortinas", 0f, 50000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AporteDetalles_AporteId",
                table: "AporteDetalles",
                column: "AporteId");

            migrationBuilder.CreateIndex(
                name: "IX_AporteDetalles_PersonaId",
                table: "AporteDetalles",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_AporteDetalles_TipoAporteId",
                table: "AporteDetalles",
                column: "TipoAporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AporteDetalles");

            migrationBuilder.DropTable(
                name: "Aportes");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TiposAportes");
        }
    }
}
