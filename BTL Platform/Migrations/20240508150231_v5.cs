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
                values: new object[] { "d77c8161-febd-4301-9220-88c159f05792", "AQAAAAIAAYagAAAAEGKDUckO1RsJZoyNhPqQ0EwItR17HdXMnIm7Egi2tbJE7LNmdE9qzQFBrt8q6KKw2w==", "42b5fb62-29bc-4100-b8b6-cf3315851bba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit_Id",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0093e1-99f6-4000-908d-7198c2d8f18f", "AQAAAAIAAYagAAAAELSUMj8L6+Hrd0BLe2Pplfaj9zU9z+XeDz/qTxiK6Ij+KMmjSjU6olT9EoqVhWvQNg==", "2195943d-06fe-4a04-9d55-9bc08eccdd66" });
        }
    }
}
