using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AnalysisResultText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "analysisresults",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "analysisresults");
        }
    }
}
