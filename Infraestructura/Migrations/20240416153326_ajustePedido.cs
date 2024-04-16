using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class ajustePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CatalogoId",
                table: "Pedidos",
                column: "CatalogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Catalogos_CatalogoId",
                table: "Pedidos",
                column: "CatalogoId",
                principalTable: "Catalogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Catalogos_CatalogoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CatalogoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CatalogoId",
                table: "Pedidos");
        }
    }
}
