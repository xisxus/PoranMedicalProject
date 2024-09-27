using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoranMedicalProject.Migrations
{
    /// <inheritdoc />
    public partial class next2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Patients_PatientID1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientID1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientID1",
                table: "Patients");

            migrationBuilder.CreateTable(
                name: "Complains",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complains", x => x.ComplainId);
                });

            migrationBuilder.CreateTable(
                name: "TeleMedichineRequests",
                columns: table => new
                {
                    TeleMedichineRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Charge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleMedichineRequests", x => x.TeleMedichineRequestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complains");

            migrationBuilder.DropTable(
                name: "TeleMedichineRequests");

            migrationBuilder.AddColumn<int>(
                name: "PatientID1",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientID1",
                table: "Patients",
                column: "PatientID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Patients_PatientID1",
                table: "Patients",
                column: "PatientID1",
                principalTable: "Patients",
                principalColumn: "PatientID");
        }
    }
}
