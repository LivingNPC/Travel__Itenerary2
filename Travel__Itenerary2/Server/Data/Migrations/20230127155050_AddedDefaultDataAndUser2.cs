using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel__Itenerary2.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NRIC",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "6fc1f693-ae74-454e-8af4-85f175b13d5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "0285467f-0714-42c5-ba2d-0e7e1b3775dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2f8c934-041b-491a-bc97-a8a4fdff1997", "AQAAAAEAACcQAAAAELQf/bGIN7rdItQhLOZPZvGDdO9txlDISdqMT8d8gvcNz7HPpMtyogSKBPA9yWbGog==", "03be2c8b-7893-4006-8b7d-e1fa4b39ea47" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NRIC",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "6df25073-e6fa-4a81-9653-e55371df939c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "15dd0e22-04c7-44e6-83bf-92af4a2d2962");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db6017bf-32c3-4f5e-87b7-e0c4c86fda52", "AQAAAAEAACcQAAAAEDBeLiGCRY4i+X71NQ44hgejarzop04VHycu7+rrG1BEVUlx0+l3/F1PllweNjtNFQ==", "a8e37e99-2cd3-4736-b8eb-d93dd4dfa8e6" });
        }
    }
}
