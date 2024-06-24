using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHospitalKindId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KindId",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_KindId",
                table: "Hospitals",
                column: "KindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Kinds_KindId",
                table: "Hospitals",
                column: "KindId",
                principalTable: "Kinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Kinds_KindId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_KindId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "KindId",
                table: "Hospitals");
        }
    }
}
