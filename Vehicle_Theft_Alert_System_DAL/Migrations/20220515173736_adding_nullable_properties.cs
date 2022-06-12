using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle_Theft_Alert_System_DAL.Migrations
{
    public partial class adding_nullable_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDBs_FamilyDBs_FamilyDBId",
                table: "AccountDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDBs_AccountDBs_AccountDBId",
                table: "ConnectionDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDBs_FamilyDBs_FamilyDBId",
                table: "ConnectionDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDBs_FamilyPlanDBs_FamilyPlanDBId",
                table: "FamilyDBs");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyPlanDBId",
                table: "FamilyDBs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyDBId",
                table: "ConnectionDBs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountDBId",
                table: "ConnectionDBs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyDBId",
                table: "AccountDBs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDBs_FamilyDBs_FamilyDBId",
                table: "AccountDBs",
                column: "FamilyDBId",
                principalTable: "FamilyDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDBs_AccountDBs_AccountDBId",
                table: "ConnectionDBs",
                column: "AccountDBId",
                principalTable: "AccountDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDBs_FamilyDBs_FamilyDBId",
                table: "ConnectionDBs",
                column: "FamilyDBId",
                principalTable: "FamilyDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDBs_FamilyPlanDBs_FamilyPlanDBId",
                table: "FamilyDBs",
                column: "FamilyPlanDBId",
                principalTable: "FamilyPlanDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDBs_FamilyDBs_FamilyDBId",
                table: "AccountDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDBs_AccountDBs_AccountDBId",
                table: "ConnectionDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDBs_FamilyDBs_FamilyDBId",
                table: "ConnectionDBs");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDBs_FamilyPlanDBs_FamilyPlanDBId",
                table: "FamilyDBs");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyPlanDBId",
                table: "FamilyDBs",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyDBId",
                table: "ConnectionDBs",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountDBId",
                table: "ConnectionDBs",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyDBId",
                table: "AccountDBs",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDBs_FamilyDBs_FamilyDBId",
                table: "AccountDBs",
                column: "FamilyDBId",
                principalTable: "FamilyDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDBs_AccountDBs_AccountDBId",
                table: "ConnectionDBs",
                column: "AccountDBId",
                principalTable: "AccountDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDBs_FamilyDBs_FamilyDBId",
                table: "ConnectionDBs",
                column: "FamilyDBId",
                principalTable: "FamilyDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDBs_FamilyPlanDBs_FamilyPlanDBId",
                table: "FamilyDBs",
                column: "FamilyPlanDBId",
                principalTable: "FamilyPlanDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
