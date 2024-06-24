using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobName",
                table: "Jobs",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "JobName");
        }
    }
}
