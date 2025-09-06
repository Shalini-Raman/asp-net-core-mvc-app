using Microsoft.EntityFrameworkCore.Migrations;

namespace eMovieTickets.Migrations
{
    public partial class ShoppingCartItem_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_Movies_MovieId",
                table: "orderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_Order_OrderId",
                table: "orderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItem",
                table: "orderItem");

            migrationBuilder.RenameTable(
                name: "orderItem",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_orderItem_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItem_MovieId",
                table: "OrderItem",
                newName: "IX_OrderItem_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Movies_MovieId",
                table: "OrderItem",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Movies_MovieId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "orderItem",
                newName: "IX_orderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_MovieId",
                table: "orderItem",
                newName: "IX_orderItem_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItem",
                table: "orderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_Movies_MovieId",
                table: "orderItem",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_Order_OrderId",
                table: "orderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
