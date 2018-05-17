﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Boilerplate.TestProject.Migrations
{
    public partial class Added_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedPersonId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPersons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AppPersons_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId",
                principalTable: "AppPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AppPersons_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "AppPersons");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedPersonId",
                table: "Tasks");
        }
    }
}
