using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRecords",
                columns: table => new
                {
                    BorrowRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecords", x => x.BorrowRecordId);
                    table.ForeignKey(
                        name: "FK_BorrowRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "ISBN", "IsAvailable", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Andrew Hunt and David Thomas", "978-0201616224", true, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pragmatic Programmer" },
                    { 2, "Robert C. Martin", "978-0132350884", true, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Pattern using C#" },
                    { 3, "Pranaya Kumar Rout", "978-0451616235", true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mastering ASP.NET Core" },
                    { 4, "Rakesh Kumat", "978-4562350123", true, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server with DBA" }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "IsAvailable", "PublishedDate", "Publisher", "Title", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "The Daily Times", 0 },
                    { 2, true, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "WallSt Press", "Financial Chronicle", 0 },
                    { 3, true, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silicon Valley Pubs", "Tech Weekly News", 0 },
                    { 4, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Press House", "Metro Morning Post", 0 },
                    { 5, false, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "Saturday Sports Herald", 0 },
                    { 6, true, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NatGeo Society", "National Geographic Vol 45", 1 },
                    { 7, true, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conde Nast", "Vogue Fashion Summer", 1 },
                    { 8, false, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forbes Media", "Forbes Business 30 Under 30", 1 },
                    { 9, true, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future US", "PC Gamer Ultimate", 1 },
                    { 10, true, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Springer Nature", "Scientific American", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_BookId",
                table: "BorrowRecords",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
