﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtorWebApp.Data.Migrations
{
    public partial class AddOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Debtors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Debtors");
        }
    }
}
