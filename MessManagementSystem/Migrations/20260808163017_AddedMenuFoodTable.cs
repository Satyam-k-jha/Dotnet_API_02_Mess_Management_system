using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedMenuFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMenu");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Menus");

            migrationBuilder.CreateTable(
                name: "FoodMenu",
                columns: table => new
                {
                    FoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenusMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenu", x => new { x.FoodsId, x.MenusMenuId });
                    table.ForeignKey(
                        name: "FK_FoodMenu_Foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMenu_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenu_MenusMenuId",
                table: "FoodMenu",
                column: "MenusMenuId");
        }
    }
}
