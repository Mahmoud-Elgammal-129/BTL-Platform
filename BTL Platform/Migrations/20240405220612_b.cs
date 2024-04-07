using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_Platform.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Visits_VisitId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Requests_RequestID",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Requests_VisitId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "UnitName",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf188a02-b734-4e4c-bbdc-a8fc766f4c04", "AQAAAAIAAYagAAAAELmUCWcwRIMotPaNSoExXVVf6jmLRxFCd5P/Ae7Rzui8vyifLhVAj6WqGvksDQrOeQ==", "096b56d9-9677-40a2-8c1e-0b15bf52a535" });

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Places_RequestID",
                table: "Visits",
                column: "RequestID",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Places_RequestID",
                table: "Visits");

            migrationBuilder.AlterColumn<string>(
                name: "UnitName",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "Requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46466b24-eaa6-4488-a6e6-92ac2bcf45aa", "AQAAAAIAAYagAAAAEL8PMWsB2X88mBgwd6jCjG2KyvVGgVQjKagfIHpv7Ilfe4XEISzohevwWJoFnzfC8Q==", "719ca67c-57ec-4e92-8c14-aba5d8cc53d2" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_VisitId",
                table: "Requests",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Visits_VisitId",
                table: "Requests",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Requests_RequestID",
                table: "Visits",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
