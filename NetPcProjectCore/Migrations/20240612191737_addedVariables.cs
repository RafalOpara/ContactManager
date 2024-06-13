using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPcProjectDataBase.Migrations
{
    /// <inheritdoc />
    public partial class addedVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subcategory",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubcategoryDictionary",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubcategoryOther",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubcategoryDictionary",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubcategoryOther",
                table: "Contacts");
        }
    }
}
