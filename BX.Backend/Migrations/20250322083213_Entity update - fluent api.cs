using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BX.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Entityupdatefluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AdminId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ClientId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStates_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Properties_PropertyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrders_Suppliers_SupplierId",
                table: "SupplierOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPayments_Suppliers_SupplierId",
                table: "SupplierPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierPayments",
                table: "SupplierPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierOrders",
                table: "SupplierOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStates",
                table: "ProjectStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PropertyId",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "SupplierPayments",
                newName: "SupplierPayment");

            migrationBuilder.RenameTable(
                name: "SupplierOrders",
                newName: "SupplierOrder");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "ProjectStates",
                newName: "ProjectStatus");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayment",
                newName: "IX_SupplierPayment_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierOrders_SupplierId",
                table: "SupplierOrder",
                newName: "IX_SupplierOrder_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Project",
                newName: "IX_Project_ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ClientId",
                table: "Project",
                newName: "IX_Project_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_AdminId",
                table: "Project",
                newName: "IX_Project_AdminId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Project",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierPayment",
                table: "SupplierPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierOrder",
                table: "SupplierOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus",
                column: "ProjectStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PropertyId",
                table: "Project",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_AdminId",
                table: "Project",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatus",
                principalColumn: "ProjectStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Property_PropertyId",
                table: "Project",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPayment_Supplier_SupplierId",
                table: "SupplierPayment",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_AdminId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ClientId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Property_PropertyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPayment_Supplier_SupplierId",
                table: "SupplierPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierPayment",
                table: "SupplierPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierOrder",
                table: "SupplierOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_PropertyId",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "SupplierPayment",
                newName: "SupplierPayments");

            migrationBuilder.RenameTable(
                name: "SupplierOrder",
                newName: "SupplierOrders");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameTable(
                name: "ProjectTask",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "ProjectStatus",
                newName: "ProjectStates");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierPayment_SupplierId",
                table: "SupplierPayments",
                newName: "IX_SupplierPayments_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierOrder_SupplierId",
                table: "SupplierOrders",
                newName: "IX_SupplierOrders_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Projects",
                newName: "IX_Projects_ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ClientId",
                table: "Projects",
                newName: "IX_Projects_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_AdminId",
                table: "Projects",
                newName: "IX_Projects_AdminId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierPayments",
                table: "SupplierPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierOrders",
                table: "SupplierOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStates",
                table: "ProjectStates",
                column: "ProjectStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PropertyId",
                table: "Projects",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AdminId",
                table: "Projects",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrders_Suppliers_SupplierId",
                table: "SupplierOrders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPayments_Suppliers_SupplierId",
                table: "SupplierPayments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
