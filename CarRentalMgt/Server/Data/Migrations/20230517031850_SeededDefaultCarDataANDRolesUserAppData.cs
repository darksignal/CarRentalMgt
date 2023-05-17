using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalMgt.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultCarDataANDRolesUserAppData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", null, "User", "USER" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "9ca64360-7941-4345-bc00-b60be40fc96b", "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEnYp5HfBibtw//rCVZ298COZBOkKfBq/b6vCQ8WqvkfyPLVS+YYBLanlK6kSoq7jw==", null, false, "d555c8f8-ef29-4674-a09f-575ae9888dd5", false, "admin@localhost.com" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, "5f865533-470c-416d-8231-ad4fb2abaff0", "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDfBmU32xZLR6bVOJF9weckFFmDQk/6wdTV3FSUA3keiT5OeJLZufVcSe2icLLr8ow==", null, false, "a4bc056e-9ec2-4869-92e5-9ac64fb26209", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4628), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4645), "Black", "System" },
                    { 2, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4649), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4650), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6396), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6407), "Toyota", "System" },
                    { 2, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6412), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6414), "BMW", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7225), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7230), "Prius", "System" },
                    { 2, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7234), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7235), "Vitz", "System" },
                    { 3, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7236), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7237), "3 Series", "System" },
                    { 4, "System", new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7239), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7239), "X5", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9");
        }
    }
}
