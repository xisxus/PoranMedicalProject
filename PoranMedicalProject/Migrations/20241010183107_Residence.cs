using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoranMedicalProject.Migrations
{
    /// <inheritdoc />
    public partial class Residence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_Doctors_ResidenceDoctorId",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_Hospitals_ResidenceHospitalId",
                table: "TreatmentPlans");

            migrationBuilder.AddColumn<int>(
                name: "ResidenceDoctorId1",
                table: "TreatmentPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidenceHospitalId1",
                table: "TreatmentPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResidenceHospitals",
                columns: table => new
                {
                    ResidenceHospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceHospitals", x => x.ResidenceHospitalId);
                });

            migrationBuilder.CreateTable(
                name: "ResidenceDoctors",
                columns: table => new
                {
                    ResidenceDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorDasignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidenceHospitalID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceDoctors", x => x.ResidenceDoctorId);
                    table.ForeignKey(
                        name: "FK_ResidenceDoctors_ResidenceHospitals_ResidenceHospitalID",
                        column: x => x.ResidenceHospitalID,
                        principalTable: "ResidenceHospitals",
                        principalColumn: "ResidenceHospitalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_ResidenceDoctorId1",
                table: "TreatmentPlans",
                column: "ResidenceDoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_ResidenceHospitalId1",
                table: "TreatmentPlans",
                column: "ResidenceHospitalId1");

            migrationBuilder.CreateIndex(
                name: "IX_ResidenceDoctors_ResidenceHospitalID",
                table: "ResidenceDoctors",
                column: "ResidenceHospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_ResidenceDoctors_ResidenceDoctorId",
                table: "TreatmentPlans",
                column: "ResidenceDoctorId",
                principalTable: "ResidenceDoctors",
                principalColumn: "ResidenceDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_ResidenceDoctors_ResidenceDoctorId1",
                table: "TreatmentPlans",
                column: "ResidenceDoctorId1",
                principalTable: "ResidenceDoctors",
                principalColumn: "ResidenceDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_ResidenceHospitals_ResidenceHospitalId",
                table: "TreatmentPlans",
                column: "ResidenceHospitalId",
                principalTable: "ResidenceHospitals",
                principalColumn: "ResidenceHospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_ResidenceHospitals_ResidenceHospitalId1",
                table: "TreatmentPlans",
                column: "ResidenceHospitalId1",
                principalTable: "ResidenceHospitals",
                principalColumn: "ResidenceHospitalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_ResidenceDoctors_ResidenceDoctorId",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_ResidenceDoctors_ResidenceDoctorId1",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_ResidenceHospitals_ResidenceHospitalId",
                table: "TreatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlans_ResidenceHospitals_ResidenceHospitalId1",
                table: "TreatmentPlans");

            migrationBuilder.DropTable(
                name: "ResidenceDoctors");

            migrationBuilder.DropTable(
                name: "ResidenceHospitals");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlans_ResidenceDoctorId1",
                table: "TreatmentPlans");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlans_ResidenceHospitalId1",
                table: "TreatmentPlans");

            migrationBuilder.DropColumn(
                name: "ResidenceDoctorId1",
                table: "TreatmentPlans");

            migrationBuilder.DropColumn(
                name: "ResidenceHospitalId1",
                table: "TreatmentPlans");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_Doctors_ResidenceDoctorId",
                table: "TreatmentPlans",
                column: "ResidenceDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlans_Hospitals_ResidenceHospitalId",
                table: "TreatmentPlans",
                column: "ResidenceHospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalID");
        }
    }
}
