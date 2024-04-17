using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogMe.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addedoverridetoOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "336f9cb4-edaa-4013-96fe-bd10d832c9e3", "336f9cb4-edaa-4013-96fe-bd10d832c9e3", "Admin", "Admin" },
                    { "3707b455-422b-481d-9313-79d1eb68aebe", "3707b455-422b-481d-9313-79d1eb68aebe", "SuperAdmin", "SuperAdmin" },
                    { "9f2a908c-2790-4698-8bef-af0c7b30923e", "9f2a908c-2790-4698-8bef-af0c7b30923e", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9b1b9636-35d5-49b7-a86c-455dbdbd8de6", 0, "4b0ca790-1296-4b95-a93e-fd6da8e23eba", "superadmin@blogme.com", false, false, null, "SUPERADMIN@BLOGME.COM", null, "AQAAAAIAAYagAAAAEMSYiZojiuQ3AbOGy5sIzJXOprokRf0LsKtmz9oujLCznp6ap7NxD+H11rvTaK09YQ==", null, false, "ecf797ec-4d96-41dd-8327-9d8dcad784a1", false, "superadmin@blogme.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "336f9cb4-edaa-4013-96fe-bd10d832c9e3", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" },
                    { "3707b455-422b-481d-9313-79d1eb68aebe", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" },
                    { "9f2a908c-2790-4698-8bef-af0c7b30923e", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "336f9cb4-edaa-4013-96fe-bd10d832c9e3", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3707b455-422b-481d-9313-79d1eb68aebe", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f2a908c-2790-4698-8bef-af0c7b30923e", "9b1b9636-35d5-49b7-a86c-455dbdbd8de6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336f9cb4-edaa-4013-96fe-bd10d832c9e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3707b455-422b-481d-9313-79d1eb68aebe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f2a908c-2790-4698-8bef-af0c7b30923e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b1b9636-35d5-49b7-a86c-455dbdbd8de6");
        }
    }
}
