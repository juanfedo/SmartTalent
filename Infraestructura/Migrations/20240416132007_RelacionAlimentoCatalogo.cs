using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class RelacionAlimentoCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_Alimentos_AlimentoId",
                table: "Catalogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Alimentos_AlimentoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_AlimentoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Catalogos_AlimentoId",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "AlimentoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "AlimentoId",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "CantidadDisponible",
                table: "Catalogos");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Catalogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlimentoCatalogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    CatalogoId = table.Column<int>(type: "int", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoCatalogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlimentoCatalogos_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentoCatalogos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoCatalogos_AlimentoId",
                table: "AlimentoCatalogos",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlimentoCatalogos_CatalogoId",
                table: "AlimentoCatalogos",
                column: "CatalogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentoCatalogos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Catalogos");

            migrationBuilder.AddColumn<int>(
                name: "AlimentoId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlimentoId",
                table: "Catalogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadDisponible",
                table: "Catalogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AlimentoId",
                table: "Pedidos",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_AlimentoId",
                table: "Catalogos",
                column: "AlimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_Alimentos_AlimentoId",
                table: "Catalogos",
                column: "AlimentoId",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Alimentos_AlimentoId",
                table: "Pedidos",
                column: "AlimentoId",
                principalTable: "Alimentos",
                principalColumn: "Id");
        }
    }
}
