using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    public partial class IntegrationsTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IntegrationDests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppName = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationDests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    IntegrationDestId = table.Column<int>(type: "integer", nullable: false),
                    TokenValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IntegrationTokens_IntegrationDests_IntegrationDestId",
                        column: x => x.IntegrationDestId,
                        principalTable: "IntegrationDests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93ea2c91-5171-427a-8dc4-5c8a529104f5", "347a49d7-31b7-4383-aca4-8d088f0737a8", "admin", "ADMIN" },
                    { "aec150e5-3f72-4fcb-a695-d671cfefb81e", "e8d1cdcf-53a6-4533-9684-b562a93c41a1", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b6439076-f9b7-4f7e-86a6-b59fa81b4044", 0, "ddd523e1-1a33-4f92-8830-45664efef8b6", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEKCA9NcKB3pztEIAWvdRo+74mWN6nQc8c7Lr/Ltuh8zwin10vhLuEofONIBkTf+VVg==", null, false, "852e7797-0816-4cb1-811e-64c5ab15ac07", false, "user" },
                    { "b8311101-fe4a-425b-9777-e13c2c45598c", 0, "03c95bdd-c47a-47e2-8254-b64c4765ec76", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEKePccljNbjgjHxmGt3Qtr66vrm3z71N9rSafaeARCgpScRm4+5QHARXFCN3NlZxhw==", null, false, "33af8d56-37bb-4e14-9a22-ad56bcd281b7", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "aec150e5-3f72-4fcb-a695-d671cfefb81e", "b6439076-f9b7-4f7e-86a6-b59fa81b4044" },
                    { "93ea2c91-5171-427a-8dc4-5c8a529104f5", "b8311101-fe4a-425b-9777-e13c2c45598c" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationTokens_IntegrationDestId",
                table: "IntegrationTokens",
                column: "IntegrationDestId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationTokens_UserId",
                table: "IntegrationTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationTokens");

            migrationBuilder.DropTable(
                name: "IntegrationDests");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aec150e5-3f72-4fcb-a695-d671cfefb81e", "b6439076-f9b7-4f7e-86a6-b59fa81b4044" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "93ea2c91-5171-427a-8dc4-5c8a529104f5", "b8311101-fe4a-425b-9777-e13c2c45598c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ea2c91-5171-427a-8dc4-5c8a529104f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec150e5-3f72-4fcb-a695-d671cfefb81e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6439076-f9b7-4f7e-86a6-b59fa81b4044");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8311101-fe4a-425b-9777-e13c2c45598c");

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
    }
}
