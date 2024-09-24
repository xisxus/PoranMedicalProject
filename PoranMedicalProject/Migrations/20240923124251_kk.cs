using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoranMedicalProject.Migrations
{
    /// <inheritdoc />
    public partial class kk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidPatients_Guids_GuidID",
                table: "GuidPatients");

            migrationBuilder.DropTable(
                name: "Guids");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUps",
                columns: table => new
                {
                    FollowUpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUps", x => x.FollowUpID);
                    table.ForeignKey(
                        name: "FK_FollowUps_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    GuidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.GuidID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_HospitalID",
                table: "Feedbacks",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientID",
                table: "Feedbacks",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUps_PatientID",
                table: "FollowUps",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_GuidPatients_Guide_GuidID",
                table: "GuidPatients",
                column: "GuidID",
                principalTable: "Guide",
                principalColumn: "GuidID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuidPatients_Guide_GuidID",
                table: "GuidPatients");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FollowUps");

            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.CreateTable(
                name: "Guids",
                columns: table => new
                {
                    GuidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guids", x => x.GuidID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GuidPatients_Guids_GuidID",
                table: "GuidPatients",
                column: "GuidID",
                principalTable: "Guids",
                principalColumn: "GuidID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
