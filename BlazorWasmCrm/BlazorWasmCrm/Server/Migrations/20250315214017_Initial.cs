﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorWasmCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "Latitude", "Longitude", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2211), null, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter", false, "Parker", null, null, "Spider-Man", "New York City" },
                    { 2, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2269), null, new DateTime(1970, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tony", false, "Stark", null, null, "Iron Man", "Malibu" },
                    { 3, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2274), null, new DateTime(1915, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bruce", false, "Wayne", null, null, "Batman", "Gotham City" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "ContactId", "DateCreated", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2460), "With great power comes great responsibility." },
                    { 2, 2, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2466), "I am Iron Man" },
                    { 3, 3, new DateTime(2025, 3, 15, 22, 40, 17, 136, DateTimeKind.Local).AddTicks(2469), "I'm Batman!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
