using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToAppDbContextToAddDbSetUpdateNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpdateNote_Observations_ObservationId",
                table: "UpdateNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpdateNote",
                table: "UpdateNote");

            migrationBuilder.RenameTable(
                name: "UpdateNote",
                newName: "UpdateNotes");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateNote_ObservationId",
                table: "UpdateNotes",
                newName: "IX_UpdateNotes_ObservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpdateNotes",
                table: "UpdateNotes",
                column: "UpdateNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateNotes_Observations_ObservationId",
                table: "UpdateNotes",
                column: "ObservationId",
                principalTable: "Observations",
                principalColumn: "ObservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpdateNotes_Observations_ObservationId",
                table: "UpdateNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpdateNotes",
                table: "UpdateNotes");

            migrationBuilder.RenameTable(
                name: "UpdateNotes",
                newName: "UpdateNote");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateNotes_ObservationId",
                table: "UpdateNote",
                newName: "IX_UpdateNote_ObservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpdateNote",
                table: "UpdateNote",
                column: "UpdateNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateNote_Observations_ObservationId",
                table: "UpdateNote",
                column: "ObservationId",
                principalTable: "Observations",
                principalColumn: "ObservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
