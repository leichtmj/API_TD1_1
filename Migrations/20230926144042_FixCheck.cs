﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_TD1_1.Migrations
{
    public partial class FixCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mar_nom",
                table: "t_e_marque_mar",
                type: "character varying(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mar_nom",
                table: "t_e_marque_mar",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85);
        }
    }
}
