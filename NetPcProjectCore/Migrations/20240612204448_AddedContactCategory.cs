using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPcProjectDataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ContactCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCategory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCategory");

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
    }
}
