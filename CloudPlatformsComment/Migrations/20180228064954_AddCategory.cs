﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CloudPlatformsComment.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CloudProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "CloudPlatformList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloudProducts_CategoryId",
                table: "CloudProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloudProducts_Categories_CategoryId",
                table: "CloudProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloudProducts_Categories_CategoryId",
                table: "CloudProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CloudProducts_CategoryId",
                table: "CloudProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CloudProducts");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "CloudPlatformList");
        }
    }
}
