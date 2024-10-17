using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Repositories.Database.Migrations
{
    /// <inheritdoc />
    public partial class modify_column_order_created_at_to_completed_at : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "CompletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompletedAt",
                table: "Orders",
                newName: "CreatedAt");
        }
    }
}
