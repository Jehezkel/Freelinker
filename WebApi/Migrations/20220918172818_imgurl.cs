using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class imgurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5bc044c9-6980-4f2b-b1a8-cb27374f3624", "95886dbb-2d23-4bc3-b27a-93920cc67541" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c47d23ea-5d95-46d1-a73f-1e81e0441eb9", "ee61a9e9-f5a1-441c-99ed-0de581092251" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc044c9-6980-4f2b-b1a8-cb27374f3624");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47d23ea-5d95-46d1-a73f-1e81e0441eb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95886dbb-2d23-4bc3-b27a-93920cc67541");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee61a9e9-f5a1-441c-99ed-0de581092251");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d92916a-b00c-4ece-90cf-debaee72eeef", "746aa642-b45a-4f2b-a2f0-937955abb53f", "user", "USER" },
                    { "bf762d80-2e57-46a9-a743-cf2af62edf73", "12aee63a-3ec0-4f13-9501-e0a79c3fa9fc", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "84a1bb9c-3282-42b8-9bb9-2551adef06ea", 0, "7a5dbde1-7517-4ef5-9159-78e4512c7785", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEEMazAMGgF3GhkdAMEY4Xyx5lkxbL5YMpgPfygvS8n2OfcfBynECxLZEueOx8zjCPQ==", null, false, "6ac88e73-87c0-4585-baa7-97747d913c06", false, "user" },
                    { "b92673cd-d558-43f7-9163-9e21317868d8", 0, "85d48dd7-ef55-42db-a0a8-9bbcadca93a7", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAELT03jjuPcRyyyL5XE9wtbUd5uWn0MuQY+fqI6iuuGhLce07KYeNE96ctnGcppIQog==", null, false, "a79cc13a-1923-42ef-a793-61ee4415664c", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0d92916a-b00c-4ece-90cf-debaee72eeef", "84a1bb9c-3282-42b8-9bb9-2551adef06ea" },
                    { "bf762d80-2e57-46a9-a743-cf2af62edf73", "b92673cd-d558-43f7-9163-9e21317868d8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d92916a-b00c-4ece-90cf-debaee72eeef", "84a1bb9c-3282-42b8-9bb9-2551adef06ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf762d80-2e57-46a9-a743-cf2af62edf73", "b92673cd-d558-43f7-9163-9e21317868d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d92916a-b00c-4ece-90cf-debaee72eeef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf762d80-2e57-46a9-a743-cf2af62edf73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84a1bb9c-3282-42b8-9bb9-2551adef06ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b92673cd-d558-43f7-9163-9e21317868d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bc044c9-6980-4f2b-b1a8-cb27374f3624", "17e901ca-1b09-4b77-b9b0-4a5a09672a56", "admin", "ADMIN" },
                    { "c47d23ea-5d95-46d1-a73f-1e81e0441eb9", "1e42a078-0606-483c-b655-f4a7274a9bfb", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "95886dbb-2d23-4bc3-b27a-93920cc67541", 0, "1cdc57e5-e447-47de-8736-f578d185c61b", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEK++IBpwiHn8luOYbcAl3wCExNVB3ifPiZdtjpAbDGAzXhzH24vh0cIJ+nG8f+e+dg==", null, false, "202d01a7-68c3-4d62-acce-d8e7be0866ed", false, "admin" },
                    { "ee61a9e9-f5a1-441c-99ed-0de581092251", 0, "dc904418-7f15-42e8-98b5-a5721275c58c", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEPQiFen2sjjj4Xlw6XeEZCLCIHcCJXC6BBx07mxc6bpAdAFqmo2JyuM69zbqk0Ajag==", null, false, "47473d03-434b-486c-9b2a-3ba2b7f77fcd", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5bc044c9-6980-4f2b-b1a8-cb27374f3624", "95886dbb-2d23-4bc3-b27a-93920cc67541" },
                    { "c47d23ea-5d95-46d1-a73f-1e81e0441eb9", "ee61a9e9-f5a1-441c-99ed-0de581092251" }
                });
        }
    }
}
