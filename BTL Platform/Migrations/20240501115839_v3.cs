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
            migrationBuilder.AddColumn<string>(
                name: "TypeInserted",
                table: "UnitDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af3a1000-1eed-4c81-82aa-d4995f6efccd", "AQAAAAIAAYagAAAAEOj5qDQ4JLfxhbWtP3Fq2AfZz0XH7rB6C31fNc6fh5fvByJEN2OYHZ3FtuOrQi8tfQ==", "1831964c-3ff6-4b06-a6f6-056c2fe236ea" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeInserted",
                table: "UnitDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f78e1f4-ef6c-4129-a064-87592ea9aa3b", "AQAAAAIAAYagAAAAELRfsRnP2ciGSwEDLqZrRXucQc3AeY9QmYY41xeWIPXoAo7KMd9f6kGjZH7tEJUxiw==", "c3802a38-42f8-468a-a17a-21a536773ef5" });
        }
    }
}
