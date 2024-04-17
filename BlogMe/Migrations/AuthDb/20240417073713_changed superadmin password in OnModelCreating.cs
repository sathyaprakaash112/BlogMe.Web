using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMe.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class changedsuperadminpasswordinOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b1b9636-35d5-49b7-a86c-455dbdbd8de6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a11a4da1-f975-4c01-bc17-3d0f5960de40", "AQAAAAIAAYagAAAAEDyhpsnGCszLL8ADlv1k2PTdi9QaNmlrXHFtRgNl4gWNtdB+mu+SvTEOE5F2kaI43w==", "2f4373f8-3ae0-495e-a96e-86ab6582a37d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b1b9636-35d5-49b7-a86c-455dbdbd8de6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0ca790-1296-4b95-a93e-fd6da8e23eba", "AQAAAAIAAYagAAAAEMSYiZojiuQ3AbOGy5sIzJXOprokRf0LsKtmz9oujLCznp6ap7NxD+H11rvTaK09YQ==", "ecf797ec-4d96-41dd-8327-9d8dcad784a1" });
        }
    }
}
