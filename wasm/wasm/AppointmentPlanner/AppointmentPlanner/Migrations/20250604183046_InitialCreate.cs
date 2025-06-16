using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ObservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    TypeOfReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NatureOfObservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionOfSuggestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionOfObservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaisedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedOutDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseOutNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForInvalid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ObservationId);
                    table.ForeignKey(
                        name: "FK_Observations_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_SiteId",
                table: "Observations",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
