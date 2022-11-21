using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paymentapidesafio.Migrations
{
    /// <inheritdoc />
    public partial class TabelasBancoItemList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Item_ItemId",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Venda",
                newName: "ItensId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ItemId",
                table: "Venda",
                newName: "IX_Venda_ItensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Item_ItensId",
                table: "Venda",
                column: "ItensId",
                principalTable: "Item",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Item_ItensId",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "ItensId",
                table: "Venda",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ItensId",
                table: "Venda",
                newName: "IX_Venda_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Item_ItemId",
                table: "Venda",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id");
        }
    }
}
