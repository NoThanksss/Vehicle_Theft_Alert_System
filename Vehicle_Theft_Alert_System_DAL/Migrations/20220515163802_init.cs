using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle_Theft_Alert_System_DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContinentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPlanDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    MaxMemberNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPlanDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackerDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsOn = table.Column<bool>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    ExperationDate = table.Column<DateTime>(nullable: false),
                    LastCoordinates = table.Column<string>(nullable: true),
                    Mac = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackerDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CountryDBId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDBs_CountryDBs_CountryDBId",
                        column: x => x.CountryDBId,
                        principalTable: "CountryDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FamilyPlanDBId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDBs_FamilyPlanDBs_FamilyPlanDBId",
                        column: x => x.FamilyPlanDBId,
                        principalTable: "FamilyPlanDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityScheduleDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    ActivityStatus = table.Column<bool>(nullable: false),
                    TrackerDBId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityScheduleDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityScheduleDBs_TrackerDBs_TrackerDBId",
                        column: x => x.TrackerDBId,
                        principalTable: "TrackerDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserDBId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BillAmount = table.Column<decimal>(nullable: false),
                    FamilyDBId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDBs_FamilyDBs_FamilyDBId",
                        column: x => x.FamilyDBId,
                        principalTable: "FamilyDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDBs_UserDBs_UserDBId",
                        column: x => x.UserDBId,
                        principalTable: "UserDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ConnectionType = table.Column<string>(nullable: true),
                    AccountDBId = table.Column<Guid>(nullable: false),
                    FamilyDBId = table.Column<Guid>(nullable: false),
                    TrackerDBId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectionDBs_AccountDBs_AccountDBId",
                        column: x => x.AccountDBId,
                        principalTable: "AccountDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionDBs_FamilyDBs_FamilyDBId",
                        column: x => x.FamilyDBId,
                        principalTable: "FamilyDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionDBs_TrackerDBs_TrackerDBId",
                        column: x => x.TrackerDBId,
                        principalTable: "TrackerDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDBs_FamilyDBId",
                table: "AccountDBs",
                column: "FamilyDBId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDBs_UserDBId",
                table: "AccountDBs",
                column: "UserDBId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityScheduleDBs_TrackerDBId",
                table: "ActivityScheduleDBs",
                column: "TrackerDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionDBs_AccountDBId",
                table: "ConnectionDBs",
                column: "AccountDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionDBs_FamilyDBId",
                table: "ConnectionDBs",
                column: "FamilyDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionDBs_TrackerDBId",
                table: "ConnectionDBs",
                column: "TrackerDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDBs_FamilyPlanDBId",
                table: "FamilyDBs",
                column: "FamilyPlanDBId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDBs_CountryDBId",
                table: "UserDBs",
                column: "CountryDBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityScheduleDBs");

            migrationBuilder.DropTable(
                name: "ConnectionDBs");

            migrationBuilder.DropTable(
                name: "AccountDBs");

            migrationBuilder.DropTable(
                name: "TrackerDBs");

            migrationBuilder.DropTable(
                name: "FamilyDBs");

            migrationBuilder.DropTable(
                name: "UserDBs");

            migrationBuilder.DropTable(
                name: "FamilyPlanDBs");

            migrationBuilder.DropTable(
                name: "CountryDBs");
        }
    }
}
