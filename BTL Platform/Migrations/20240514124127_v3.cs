using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Places");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e74e4e6e-e74a-43b7-92de-d4670f5f9a67", "AQAAAAIAAYagAAAAEBicUXuMIEZsp2wuDP31FssYf+z9oCAkpQIhmzPXsxLECyjW7U/eTiWE7uPBDi8frQ==", "2baa349e-4497-4908-9df9-c5dbc57a7403" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "444f3883-c20e-4f4c-bdb7-12c5afef17eb", "AQAAAAIAAYagAAAAEJhb7K03Iv3j75B7yAwwfPdfgD2g/yErzvdGUDmqzEmeBaJWERVCg27PJ99dYTHm+Q==", "e916a0f0-06b8-4899-a3e6-22d3357b86a0" });
        }
    }
}
