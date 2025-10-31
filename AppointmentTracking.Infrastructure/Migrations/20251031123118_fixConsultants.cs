using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixConsultants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Consultants");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Consultants",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ConsultantProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProfilePhotoUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantProfiles_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantServices_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantProfiles_ConsultantId",
                table: "ConsultantProfiles",
                column: "ConsultantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantServices_ConsultantId_ServiceId",
                table: "ConsultantServices",
                columns: new[] { "ConsultantId", "ServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantServices_ServiceId",
                table: "ConsultantServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantProfiles");

            migrationBuilder.DropTable(
                name: "ConsultantServices");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Consultants");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Consultants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Consultants",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Consultants",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
