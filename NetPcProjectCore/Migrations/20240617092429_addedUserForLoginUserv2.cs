using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPcProjectDataBase.Migrations
{
    /// <inheritdoc />
    public partial class addedUserForLoginUserv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactCat",
                table: "Contacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactCat",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
