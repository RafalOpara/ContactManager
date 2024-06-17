using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPcProjectDataBase.Migrations
{
    /// <inheritdoc />
    public partial class addedUserForLoginUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactCat",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactCategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswrodHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCategoryId",
                table: "Contacts",
                column: "ContactCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactCategory_ContactCategoryId",
                table: "Contacts",
                column: "ContactCategoryId",
                principalTable: "ContactCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactCategory_ContactCategoryId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactCategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactCat",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactCategoryId",
                table: "Contacts");
        }
    }
}
