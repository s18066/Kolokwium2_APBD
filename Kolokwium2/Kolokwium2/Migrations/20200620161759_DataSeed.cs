using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[] { 1, "nick" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, new DateTime(2020, 6, 22, 18, 17, 58, 628, DateTimeKind.Local).AddTicks(9064), "e1", new DateTime(2020, 6, 20, 18, 17, 58, 631, DateTimeKind.Local).AddTicks(7354) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[] { 2, new DateTime(2020, 6, 23, 18, 17, 58, 631, DateTimeKind.Local).AddTicks(8128), "e2", new DateTime(2020, 6, 21, 18, 17, 58, 631, DateTimeKind.Local).AddTicks(8156) });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "ArtistId", "EventId", "PerformanceDate" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 20, 19, 17, 58, 631, DateTimeKind.Local).AddTicks(9196) });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "ArtistId", "EventId", "PerformanceDate" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 21, 19, 17, 58, 631, DateTimeKind.Local).AddTicks(9899) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "ArtistId", "EventId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 2);
        }
    }
}
