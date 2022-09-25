using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class dates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "ProductImages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a6ac5b3-30a0-45fd-b50b-c0f082201e06", "c957aa51-34e9-417a-a565-12aa495d443b", "user", "USER" },
                    { "b2c005b6-a38c-48c8-a95f-d2c26b0e55ad", "7e8cae11-710e-4cd2-9b4c-baa13b2555d8", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2fcb9e3c-c0cc-48f9-ac8a-b80ffba0f2ee", 0, "7d0187d6-a8f7-4eb1-905f-9922b16687e5", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEGEgdhw1/KCdc63hgRvG9eyyF8MNjKY+FVrGWzbh4OrgdGSPVyjdLQzuY6aw4RKIcg==", null, false, "983b6542-1883-4ab2-8750-f50d42d06c9c", false, "admin" },
                    { "729ae977-1e29-425c-8dbf-5dcbded384a6", 0, "f443c499-cb70-48da-bb28-4699945ac4bf", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEMJ3aT7xV0mpXrD8w1vmii7rE2BlKjFDWNmMrrtcvlg7OGyTKFaprU4e883ktUhEeQ==", null, false, "b7b491e2-ef53-4d22-8470-3869593930cd", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b2c005b6-a38c-48c8-a95f-d2c26b0e55ad", "2fcb9e3c-c0cc-48f9-ac8a-b80ffba0f2ee" },
                    { "6a6ac5b3-30a0-45fd-b50b-c0f082201e06", "729ae977-1e29-425c-8dbf-5dcbded384a6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2c005b6-a38c-48c8-a95f-d2c26b0e55ad", "2fcb9e3c-c0cc-48f9-ac8a-b80ffba0f2ee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a6ac5b3-30a0-45fd-b50b-c0f082201e06", "729ae977-1e29-425c-8dbf-5dcbded384a6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a6ac5b3-30a0-45fd-b50b-c0f082201e06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2c005b6-a38c-48c8-a95f-d2c26b0e55ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fcb9e3c-c0cc-48f9-ac8a-b80ffba0f2ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "729ae977-1e29-425c-8dbf-5dcbded384a6");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "ProductImages");

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
    }
}
