using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class smallChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4d7447d-ec82-4616-ae6a-16d249e8a08f", "2aa2f4c6-f097-47c7-a59f-ffad0c2209c6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94d0299a-68d3-4d19-8a40-514e1a18a816", "8e97cb5c-9f2b-4012-9e00-64508798ec6b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d0299a-68d3-4d19-8a40-514e1a18a816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d7447d-ec82-4616-ae6a-16d249e8a08f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aa2f4c6-f097-47c7-a59f-ffad0c2209c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e97cb5c-9f2b-4012-9e00-64508798ec6b");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94d0299a-68d3-4d19-8a40-514e1a18a816", "231dcbcf-7596-4722-9034-2cf5bcd28276", "admin", "ADMIN" },
                    { "f4d7447d-ec82-4616-ae6a-16d249e8a08f", "956f7f6d-68d4-4971-b9b9-3d2d14b6d0ad", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2aa2f4c6-f097-47c7-a59f-ffad0c2209c6", 0, "ecb95f1e-3a50-4748-b0a3-1ba298dd09eb", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAELhXGkOU+GyUmZIJ40RWbe5Zm0P+fG07vZfCmFBJv6m3yzpfwaMp9Cna71Dc1YUaLQ==", null, false, "6912e89a-7eee-421b-b97c-0d7f45b0d8f6", false, "user" },
                    { "8e97cb5c-9f2b-4012-9e00-64508798ec6b", 0, "5f9064d9-a97c-45d8-8b0b-8b6300460c8f", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEEaPdfZ1uGtyeWaCYJ5iJgPQSbf7rHelM4P9ieXwCBvgeNElvLN8+qwaCV8CUE3vWw==", null, false, "c0f35048-5105-45a8-8502-3ea00e59eb66", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f4d7447d-ec82-4616-ae6a-16d249e8a08f", "2aa2f4c6-f097-47c7-a59f-ffad0c2209c6" },
                    { "94d0299a-68d3-4d19-8a40-514e1a18a816", "8e97cb5c-9f2b-4012-9e00-64508798ec6b" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
