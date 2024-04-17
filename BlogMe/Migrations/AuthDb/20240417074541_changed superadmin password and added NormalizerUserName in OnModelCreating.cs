using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMe.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class changedsuperadminpasswordandaddedNormalizerUserNameinOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b1b9636-35d5-49b7-a86c-455dbdbd8de6",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffe8ceb9-6d9b-4e23-8000-4f54fc40ac34", "superadmin@blogme.com", "AQAAAAIAAYagAAAAEPTP4WBqbVn/tn+xurVuVgfEdpviu2nGRpLuzjEk7DQerKJpYgp9b7XUKYHgsvlaqA==", "4427d2f7-61cd-4c2f-877c-8b1382b45a16" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b1b9636-35d5-49b7-a86c-455dbdbd8de6",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a11a4da1-f975-4c01-bc17-3d0f5960de40", null, "AQAAAAIAAYagAAAAEDyhpsnGCszLL8ADlv1k2PTdi9QaNmlrXHFtRgNl4gWNtdB+mu+SvTEOE5F2kaI43w==", "2f4373f8-3ae0-495e-a96e-86ab6582a37d" });
        }
    }
}
