using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCompanyColumnFromObservationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Observations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Observations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
