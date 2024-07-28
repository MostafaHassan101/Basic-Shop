using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationsCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_Id",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_Id",
                table: "CartItems",
                column: "Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
