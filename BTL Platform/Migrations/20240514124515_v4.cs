using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Places");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fdc52f5-767e-4ff0-80f8-c996899aa91e", "AQAAAAIAAYagAAAAEODHkJg9F6Nx6NnXpET200YIL/8WGNkrh8tTuQ5qspId2HuWuHrLmMpEoe2Yicn1gw==", "8f87da4b-3a4e-4fb2-964e-b6df5ce14f18" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e74e4e6e-e74a-43b7-92de-d4670f5f9a67", "AQAAAAIAAYagAAAAEBicUXuMIEZsp2wuDP31FssYf+z9oCAkpQIhmzPXsxLECyjW7U/eTiWE7uPBDi8frQ==", "2baa349e-4497-4908-9df9-c5dbc57a7403" });
        }
    }
}
