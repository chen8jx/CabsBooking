﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabsBooking.Infrastructure.Migrations
{
    public partial class BookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "cast(getdate() as date)"),
                    BookingTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, defaultValueSql: "convert(varchar(5),getdate(),108)"),
                    FromPlace = table.Column<int>(type: "int", nullable: true),
                    ToPlace = table.Column<int>(type: "int", nullable: true),
                    PickupAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "cast(getdate() as date)"),
                    PickupTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, defaultValueSql: "convert(varchar(5),getdate(),108)"),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_FromPlace",
                        column: x => x.FromPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_ToPlace",
                        column: x => x.ToPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabTypeId",
                table: "Bookings",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FromPlace",
                table: "Bookings",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToPlace",
                table: "Bookings",
                column: "ToPlace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
