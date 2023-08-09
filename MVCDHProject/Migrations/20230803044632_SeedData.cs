using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCDHProject.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Custid", "Balance", "City", "Continent", "Country", "Name", "State", "Status" },
                values: new object[,]
                {
                    { 101, 50000.00m, "Delhi", null, null, "Sai", null, true },
                    { 102, 40000.00m, "Mumbai", null, null, "Sonia", null, true },
                    { 103, 30000.00m, "Chennai", null, null, "Pankaj", null, true },
                    { 104, 25000.00m, "Bengaluru", null, null, "Samuels", null, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Custid",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Custid",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Custid",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Custid",
                keyValue: 104);
        }
    }
}
