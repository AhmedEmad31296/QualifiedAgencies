using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualifiedAgencies.Migrations
{
    public partial class _07102023_0444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "EligibleEntities");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "EligibleEntities");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "EligibleEntities");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                table: "EligibleEntities",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActivityTypeId",
                table: "EligibleEntities",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AreaId",
                table: "EligibleEntities",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EligibleEntities_ActivityId",
                table: "EligibleEntities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleEntities_ActivityTypeId",
                table: "EligibleEntities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleEntities_AreaId",
                table: "EligibleEntities",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleEntities_Activities_ActivityId",
                table: "EligibleEntities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleEntities_ActivityTypes_ActivityTypeId",
                table: "EligibleEntities",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleEntities_Areas_AreaId",
                table: "EligibleEntities",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EligibleEntities_Activities_ActivityId",
                table: "EligibleEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleEntities_ActivityTypes_ActivityTypeId",
                table: "EligibleEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleEntities_Areas_AreaId",
                table: "EligibleEntities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_EligibleEntities_ActivityId",
                table: "EligibleEntities");

            migrationBuilder.DropIndex(
                name: "IX_EligibleEntities_ActivityTypeId",
                table: "EligibleEntities");

            migrationBuilder.DropIndex(
                name: "IX_EligibleEntities_AreaId",
                table: "EligibleEntities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "EligibleEntities");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "EligibleEntities");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "EligibleEntities");

            migrationBuilder.AddColumn<int>(
                name: "Activity",
                table: "EligibleEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityType",
                table: "EligibleEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "EligibleEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
