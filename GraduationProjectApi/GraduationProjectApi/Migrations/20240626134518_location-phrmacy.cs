﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class locationphrmacy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "Pharmacies",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MyLocation",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "MyLocation",
                table: "Pharmacies");
        }
    }
}
