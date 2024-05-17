using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class otherEntitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_Libraries_LibraryEntityId",
                table: "BookEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookEntity_LibraryEntityId",
                table: "BookEntity");

            migrationBuilder.DropColumn(
                name: "LibraryEntityId",
                table: "BookEntity");

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "BookEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuthorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEntity_AuthorId",
                table: "BookEntity",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEntity_LibraryId",
                table: "BookEntity",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_AuthorEntity_AuthorId",
                table: "BookEntity",
                column: "AuthorId",
                principalTable: "AuthorEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_Libraries_LibraryId",
                table: "BookEntity",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_AuthorEntity_AuthorId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_Libraries_LibraryId",
                table: "BookEntity");

            migrationBuilder.DropTable(
                name: "AuthorEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookEntity_AuthorId",
                table: "BookEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookEntity_LibraryId",
                table: "BookEntity");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "BookEntity");

            migrationBuilder.AddColumn<int>(
                name: "LibraryEntityId",
                table: "BookEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookEntity_LibraryEntityId",
                table: "BookEntity",
                column: "LibraryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_Libraries_LibraryEntityId",
                table: "BookEntity",
                column: "LibraryEntityId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }
    }
}
