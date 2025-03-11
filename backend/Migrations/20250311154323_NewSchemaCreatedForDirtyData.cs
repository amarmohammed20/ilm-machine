using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class NewSchemaCreatedForDirtyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dirtyData");

            migrationBuilder.RenameTable(
                name: "QuranQuotes",
                newName: "QuranQuotes",
                newSchema: "dirtyData");

            migrationBuilder.RenameTable(
                name: "Hadiths",
                newName: "Hadiths",
                newSchema: "dirtyData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "QuranQuotes",
                schema: "dirtyData",
                newName: "QuranQuotes");

            migrationBuilder.RenameTable(
                name: "Hadiths",
                schema: "dirtyData",
                newName: "Hadiths");
        }
    }
}
