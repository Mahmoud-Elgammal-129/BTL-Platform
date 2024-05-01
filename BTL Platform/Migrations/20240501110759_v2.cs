using System;
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
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitTypes_Unit_type_Id",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_Unit_type_Id",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Unit_type_Id",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnitDetails",
                columns: table => new
                {
                    UnitDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitDetailCount = table.Column<int>(type: "int", nullable: false),
                    UnitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDetails", x => x.UnitDetailId);
                    table.ForeignKey(
                        name: "FK_UnitDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f78e1f4-ef6c-4129-a064-87592ea9aa3b", "AQAAAAIAAYagAAAAELRfsRnP2ciGSwEDLqZrRXucQc3AeY9QmYY41xeWIPXoAo7KMd9f6kGjZH7tEJUxiw==", "c3802a38-42f8-468a-a17a-21a536773ef5" });

            migrationBuilder.CreateIndex(
                name: "IX_UnitDetails_UnitId",
                table: "UnitDetails",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitDetails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Unit_type_Id",
                table: "Units",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c647c237-ffdd-4410-b08a-8ebe499c8167", "AQAAAAIAAYagAAAAEF8WdkzaoLKKYrMIcjmrycfcFNbUHTskhAZ2ekRmbWm/POyOBn5nBIAelP5ajVwyuw==", "1d481bab-ac3b-49b5-b286-95b100729d91" });

            migrationBuilder.CreateIndex(
                name: "IX_Units_Unit_type_Id",
                table: "Units",
                column: "Unit_type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitTypes_Unit_type_Id",
                table: "Units",
                column: "Unit_type_Id",
                principalTable: "UnitTypes",
                principalColumn: "UnitTypeId");
        }
    }
}
