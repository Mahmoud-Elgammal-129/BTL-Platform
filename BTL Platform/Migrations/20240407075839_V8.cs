using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d2be72f-4463-4bfe-86eb-09b3f4a6df84", "AQAAAAIAAYagAAAAEAzUYm4zF6e+LNghli30rIDeWrm1LalF3uGM0BZYY2aMw38FkLjVTvNtkqntwESZog==", "66b16358-855f-4ca5-80ff-00ef1ebd10fc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf188a02-b734-4e4c-bbdc-a8fc766f4c04", "AQAAAAIAAYagAAAAELmUCWcwRIMotPaNSoExXVVf6jmLRxFCd5P/Ae7Rzui8vyifLhVAj6WqGvksDQrOeQ==", "096b56d9-9677-40a2-8c1e-0b15bf52a535" });
        }
    }
}
