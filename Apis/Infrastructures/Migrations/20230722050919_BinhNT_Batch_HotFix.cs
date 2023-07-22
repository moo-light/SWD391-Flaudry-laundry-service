using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class BinhNT_Batch_HotFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecieveTime",
                table: "Batchs");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTime",
                table: "Batchs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToTime",
                table: "Batchs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "RecieveTime",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
