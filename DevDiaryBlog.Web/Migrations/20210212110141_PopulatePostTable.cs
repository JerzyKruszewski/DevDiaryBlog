using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DevDiaryBlog.Web.Migrations
{
    public partial class PopulatePostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO dbo.Posts (Title, Text, PublishDate, AuthorId)
VALUES ('Lorem Ipsum', 'Lorem Ipsum dolor sit amet', '{DateTime.Now}', '3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
