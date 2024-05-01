using System;
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
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PlacesDetails",
                columns: table => new
                {
                    PlacesDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlacesDetailCount = table.Column<int>(type: "int", nullable: false),
                    PlacesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PlacesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    unitId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesDetails", x => x.PlacesDetailId);
                    table.ForeignKey(
                        name: "FK_PlacesDetails_Places_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacesDetails_Units_unitId",
                        column: x => x.unitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitDetails",
                columns: table => new
                {
                    VisitDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitDetailCount = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VisitId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitDetails", x => x.VisitDetailId);
                    table.ForeignKey(
                        name: "FK_VisitDetails_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "VisitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0093e1-99f6-4000-908d-7198c2d8f18f", "AQAAAAIAAYagAAAAELSUMj8L6+Hrd0BLe2Pplfaj9zU9z+XeDz/qTxiK6Ij+KMmjSjU6olT9EoqVhWvQNg==", "2195943d-06fe-4a04-9d55-9bc08eccdd66" });

            migrationBuilder.CreateIndex(
                name: "IX_PlacesDetails_PlacesId",
                table: "PlacesDetails",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesDetails_unitId",
                table: "PlacesDetails",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitDetails_VisitId",
                table: "VisitDetails",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "PlacesDetails");

            migrationBuilder.DropTable(
                name: "VisitDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af3a1000-1eed-4c81-82aa-d4995f6efccd", "AQAAAAIAAYagAAAAEOj5qDQ4JLfxhbWtP3Fq2AfZz0XH7rB6C31fNc6fh5fvByJEN2OYHZ3FtuOrQi8tfQ==", "1831964c-3ff6-4b06-a6f6-056c2fe236ea" });

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
