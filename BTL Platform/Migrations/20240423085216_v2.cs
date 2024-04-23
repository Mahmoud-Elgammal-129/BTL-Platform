using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientMobile",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f263cfe-d397-41fb-9f70-6b1527d73ac1", "AQAAAAIAAYagAAAAEDlfUW8dfuNJB8X+xpdvCvo/bh2V9Dy/8egSeWfltr7n02JUfof3FG+fRLI9ryP4xw==", "b6872911-d56a-4393-8161-d47a4ca7eb44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ClientMobile",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fa42c90-bfa3-4516-b6b9-79bf6c0fb4f0", "AQAAAAIAAYagAAAAEKq4+6mFd2/+6UtR69WBKrtjcbZ+uU37GFQFDmK2qyTq+ipXep22C2Ptt7lqFDf0Ag==", "1edb0292-edc0-49ee-9a29-2450930e19ba" });
        }
    }
}
