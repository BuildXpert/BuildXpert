using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BX.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStates_ProjectStateId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectStateId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Canton",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ConstructionSize",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ConstructionType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Floors",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "HasGarage",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsCondominium",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LandSize",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectStateId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectStateId",
                table: "ProjectStates",
                newName: "ProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "GarageCapacity",
                table: "Projects",
                newName: "PropertyId");

            migrationBuilder.AddColumn<string>(
                name: "ProjectStatusId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PropertyId",
                table: "Projects",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStates_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "ProjectStates",
                principalColumn: "ProjectStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Properties_PropertyId",
                table: "Projects",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStates_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Properties_PropertyId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PropertyId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectStatusId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusId",
                table: "ProjectStates",
                newName: "ProjectStateId");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Projects",
                newName: "GarageCapacity");

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bedrooms",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Canton",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ConstructionSize",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ConstructionType",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasGarage",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCondominium",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "LandSize",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProjectStateId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStateId",
                table: "Projects",
                column: "ProjectStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStates_ProjectStateId",
                table: "Projects",
                column: "ProjectStateId",
                principalTable: "ProjectStates",
                principalColumn: "ProjectStateId");
        }
    }
}
