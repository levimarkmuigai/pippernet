using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipperNet.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionDuration",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionDuration",
                table: "AspNetUsers");
        }
    }
}
