﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace NausheenBooks.DataAccess.Migrations
{
    public partial class addCoverTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    CoverTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.CoverTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverTypes");
        }
    }
}
