using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit_Id",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f541f3a-a395-4399-87de-05037d4c9e0f", "AQAAAAIAAYagAAAAEOyQ4n/MhhDVhqxEA/TfLS+UC44CxXeCw7tLZKYpiRpomhHkEuyLms108gS5ioKauQ==", "5da837fc-ceff-4e02-a3f0-f0c725d4734e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit_Id",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fdc52f5-767e-4ff0-80f8-c996899aa91e", "AQAAAAIAAYagAAAAEODHkJg9F6Nx6NnXpET200YIL/8WGNkrh8tTuQ5qspId2HuWuHrLmMpEoe2Yicn1gw==", "8f87da4b-3a4e-4fb2-964e-b6df5ce14f18" });
        }
    }
}
