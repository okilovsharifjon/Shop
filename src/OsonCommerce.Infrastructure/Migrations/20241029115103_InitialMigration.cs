using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OsonCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LogoName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cashbox",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    StoreBranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    key = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    balance = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    last_updated_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    contact_info = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    address = table.Column<string>(type: "VARCHAR", maxLength: 300, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", nullable: false),
                    stock_code = table.Column<string>(type: "VARCHAR", nullable: false),
                    location = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    current_load = table.Column<int>(type: "INTEGER", nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR", nullable: false),
                    is_available = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoryId = table.Column<Guid>(type: "UUID", nullable: true),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    unit = table.Column<string>(type: "VARCHAR", nullable: false),
                    image_name = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    weight = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    manufacture_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    sku = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_in_stock",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    product_id = table.Column<Guid>(type: "UUID", nullable: false),
                    stock_id = table.Column<Guid>(type: "UUID", nullable: false),
                    provider_id = table.Column<Guid>(type: "UUID", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    is_available = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    last_updated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_in_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_in_stock_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cashbox_operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CashboxId = table.Column<Guid>(type: "UUID", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox_operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cashbox_operation_cashbox_CashboxId",
                        column: x => x.CashboxId,
                        principalTable: "cashbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreBranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Position = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Department = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "store_branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    OperatingHours = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_store_branch_employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_CashboxId",
                table: "cashbox_operation",
                column: "CashboxId");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_EmployeeId",
                table: "cashbox_operation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_StoreBranchId",
                table: "employee",
                column: "StoreBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_product_BrandId",
                table: "product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_product_id",
                table: "product_in_stock",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_branch_ManagerId",
                table: "store_branch",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cashbox_operation_employee_EmployeeId",
                table: "cashbox_operation",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_store_branch_StoreBranchId",
                table: "employee",
                column: "StoreBranchId",
                principalTable: "store_branch",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_store_branch_employee_ManagerId",
                table: "store_branch");

            migrationBuilder.DropTable(
                name: "cashbox_operation");

            migrationBuilder.DropTable(
                name: "product_in_stock");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "cashbox");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "store_branch");
        }
    }
}
