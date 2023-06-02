using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalMgt.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookingNotMandatoryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2923cce9-7e7d-4121-a198-6dded71b984f", "AQAAAAIAAYagAAAAEPh+hWzJrkGNIMKGW7oybj0FyEX3jHm1ibnrzaBS0CHQ9jLY6bqAxC4bSMj1Yk8a3A==", "9a589c9e-a1e1-48bf-96b6-aae79f0dd03c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afdae69f-b4e3-45c5-956f-be69000112ad", "AQAAAAIAAYagAAAAEKJI73oFyP/frK6rCyDZvcrQzgMDF+CzvLh1iUEgOpBRI29gZ3ZUIkjEItRjFVeVjQ==", "bb523699-850f-4e03-be6d-30a3720ecfdd" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(6759), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(6773), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(6774) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(7599), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(7604), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(7604) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8058), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8062), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8064), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8066), new DateTime(2023, 6, 2, 15, 34, 51, 994, DateTimeKind.Local).AddTicks(8067) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ca64360-7941-4345-bc00-b60be40fc96b", "AQAAAAIAAYagAAAAEEnYp5HfBibtw//rCVZ298COZBOkKfBq/b6vCQ8WqvkfyPLVS+YYBLanlK6kSoq7jw==", "d555c8f8-ef29-4674-a09f-575ae9888dd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f865533-470c-416d-8231-ad4fb2abaff0", "AQAAAAIAAYagAAAAEDfBmU32xZLR6bVOJF9weckFFmDQk/6wdTV3FSUA3keiT5OeJLZufVcSe2icLLr8ow==", "a4bc056e-9ec2-4869-92e5-9ac64fb26209" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4628), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4649), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6396), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6407) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6412), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7225), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7234), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7236), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7237) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7239), new DateTime(2023, 5, 17, 11, 18, 49, 387, DateTimeKind.Local).AddTicks(7239) });
        }
    }
}
