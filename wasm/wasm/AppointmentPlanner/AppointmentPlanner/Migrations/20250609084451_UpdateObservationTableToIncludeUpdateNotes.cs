using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateObservationTableToIncludeUpdateNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpdateNote",
                columns: table => new
                {
                    UpdateNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservationId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateNote", x => x.UpdateNoteId);
                    table.ForeignKey(
                        name: "FK_UpdateNote_Observations_ObservationId",
                        column: x => x.ObservationId,
                        principalTable: "Observations",
                        principalColumn: "ObservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpdateNote_ObservationId",
                table: "UpdateNote",
                column: "ObservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpdateNote");
        }
    }
}
