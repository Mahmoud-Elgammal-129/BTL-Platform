using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Units_unit_Id",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_Request_type_Id",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_unit_Id",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "unit_Id",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Request_type_Id",
                table: "Requests",
                newName: "RequestTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_Request_type_Id",
                table: "Requests",
                newName: "IX_Requests_RequestTypeID");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "RequestTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46466b24-eaa6-4488-a6e6-92ac2bcf45aa", "AQAAAAIAAYagAAAAEL8PMWsB2X88mBgwd6jCjG2KyvVGgVQjKagfIHpv7Ilfe4XEISzohevwWJoFnzfC8Q==", "719ca67c-57ec-4e92-8c14-aba5d8cc53d2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeID",
                table: "Requests",
                column: "RequestTypeID",
                principalTable: "RequestTypes",
                principalColumn: "RequestTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeID",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestTypeID",
                table: "Requests",
                newName: "Request_type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestTypeID",
                table: "Requests",
                newName: "IX_Requests_Request_type_Id");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "RequestTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "unit_Id",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4eb72d4-f9a1-4328-a45a-1e04edafee79", "AQAAAAIAAYagAAAAED/X2DA+hn/Y/FdWFQBU9wsKGjuYmNNxwJ17vhxzRW/vRwhEHIH23rAkt9UYQIlqtA==", "0e280813-2b70-42f0-a569-9545b49ba9c8" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_unit_Id",
                table: "Inventories",
                column: "unit_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Units_unit_Id",
                table: "Inventories",
                column: "unit_Id",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_Request_type_Id",
                table: "Requests",
                column: "Request_type_Id",
                principalTable: "RequestTypes",
                principalColumn: "RequestTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
