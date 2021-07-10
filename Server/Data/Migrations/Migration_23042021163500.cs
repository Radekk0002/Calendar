using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("Migration_23042021163500")]
    public class Migration_23042021163500 : Migration
    {
        protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: cb => new
                {
                    Id = cb.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    UserToDoId = cb.Column<int>(nullable: false),
                    Email = cb.Column<string>(nullable: false, maxLength: 50),
                    Start = cb.Column<DateTime>(nullable: false),
                    End = cb.Column<DateTime>(nullable: false),
                    Text = cb.Column<string>(nullable: false, maxLength: 50),
                },
                constraints: ctb => ctb.PrimaryKey("PK_ToDoID_Key", x => x.Id)
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ToDos");
        }
    }
}
