using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoranMedicalProject.Migrations
{
    /// <inheritdoc />
    public partial class nect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisaID",
                table: "Visas",
                newName: "VisaProcessingID");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "Visas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Visas");

            migrationBuilder.RenameColumn(
                name: "VisaProcessingID",
                table: "Visas",
                newName: "VisaID");
        }
    }
}
