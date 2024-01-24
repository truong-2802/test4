using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test4.Migrations
{
    /// <inheritdoc />
    public partial class f2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "ItemQty");

            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "Orders",
                newName: "OrderDelivery");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "Orders",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "OrderAddress");

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Orders",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "OrderDelivery",
                table: "Orders",
                newName: "DeliveryTime");

            migrationBuilder.RenameColumn(
                name: "OrderAddress",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "ItemQty",
                table: "Orders",
                newName: "Quantity");
        }
    }
}
