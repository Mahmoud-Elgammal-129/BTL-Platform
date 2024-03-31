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
                name: "FK_Requests_Visits_VisitId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_Requests_RequestID",
                table: "RequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_Visits_VisitId",
                table: "RequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitTypes_Visits_VisitId",
                table: "UnitTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Visits_VisitId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitStatuses_Visits_VisitId",
                table: "VisitStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                table: "VisitTypes");

            migrationBuilder.DropIndex(
                name: "IX_VisitTypes_VisitId",
                table: "VisitTypes");

            migrationBuilder.DropIndex(
                name: "IX_VisitStatuses_VisitId",
                table: "VisitStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisitId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UnitTypes_VisitId",
                table: "UnitTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestTypes_VisitId",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "VisitTypes");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "VisitStatuses");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "UnitTypes");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "RequestTypes");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Visits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitStatusId",
                table: "Visits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitTypeId",
                table: "Visits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "Units",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "RequestID",
                table: "RequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VisitId",
                table: "Requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnitType",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnitNumber",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Channel",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Chain",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "count",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_Id",
                table: "Visits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitStatusId",
                table: "Visits",
                column: "VisitStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitTypeId",
                table: "Visits",
                column: "VisitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_VisitId",
                table: "Units",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Visits_VisitId",
                table: "Requests",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_Requests_RequestID",
                table: "RequestTypes",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Visits_VisitId",
                table: "Units",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitStatuses_VisitStatusId",
                table: "Visits",
                column: "VisitStatusId",
                principalTable: "VisitStatuses",
                principalColumn: "VisitStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitTypes_VisitTypeId",
                table: "Visits",
                column: "VisitTypeId",
                principalTable: "VisitTypes",
                principalColumn: "VisitTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Visits_VisitId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_Requests_RequestID",
                table: "RequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Visits_VisitId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_Id",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitStatuses_VisitStatusId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitTypes_VisitTypeId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_Id",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitStatusId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitTypeId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Units_VisitId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitStatusId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitTypeId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Units");

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "VisitTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "VisitStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "UnitTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "RequestID",
                table: "RequestTypes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "VisitId",
                table: "RequestTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "VisitId",
                table: "Requests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "UnitType",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UnitNumber",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Channel",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Chain",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "count",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_VisitTypes_VisitId",
                table: "VisitTypes",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitStatuses_VisitId",
                table: "VisitStatuses",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitId",
                table: "Users",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTypes_VisitId",
                table: "UnitTypes",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypes_VisitId",
                table: "RequestTypes",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Visits_VisitId",
                table: "Requests",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_Requests_RequestID",
                table: "RequestTypes",
                column: "RequestID",
                principalTable: "Requests",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_Visits_VisitId",
                table: "RequestTypes",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitTypes_Visits_VisitId",
                table: "UnitTypes",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Visits_VisitId",
                table: "Users",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitStatuses_Visits_VisitId",
                table: "VisitStatuses",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitTypes_Visits_VisitId",
                table: "VisitTypes",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
