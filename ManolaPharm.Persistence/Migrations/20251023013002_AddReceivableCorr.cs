using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManolaPharm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReceivableCorr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountReceived",
                table: "AccountsReceivables",
                newName: "AmountPaid");

            migrationBuilder.RenameColumn(
                name: "AmountDue",
                table: "AccountsReceivables",
                newName: "AmountOwed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "AccountsReceivables",
                newName: "AmountReceived");

            migrationBuilder.RenameColumn(
                name: "AmountOwed",
                table: "AccountsReceivables",
                newName: "AmountDue");
        }
    }
}
