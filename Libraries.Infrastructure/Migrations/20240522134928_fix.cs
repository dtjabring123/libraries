using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libraries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_AuthorEntity_AuthorId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_Libraries_LibraryId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_UserEntity_UserId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntity_Libraries_LibraryId",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorEntity",
                table: "AuthorEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "BookEntity",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "AuthorEntity",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_LibraryId",
                table: "Users",
                newName: "IX_Users_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_UserId",
                table: "Books",
                newName: "IX_Books_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_LibraryId",
                table: "Books",
                newName: "IX_Books_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                table: "Users",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Libraries_LibraryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "BookEntity");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "AuthorEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LibraryId",
                table: "UserEntity",
                newName: "IX_UserEntity_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_UserId",
                table: "BookEntity",
                newName: "IX_BookEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LibraryId",
                table: "BookEntity",
                newName: "IX_BookEntity_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "BookEntity",
                newName: "IX_BookEntity_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorEntity",
                table: "AuthorEntity",
                column: "Id");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_UserEntity_UserId",
                table: "BookEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntity_Libraries_LibraryId",
                table: "UserEntity",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }
    }
}