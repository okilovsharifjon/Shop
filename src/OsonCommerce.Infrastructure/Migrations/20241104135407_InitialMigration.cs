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
                name: "manufacture",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    logo_name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    website_url = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    country_of_origin = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "price_type",
                columns: table => new
                {
                    price_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_price_type", x => x.price_type_id);
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
                name: "store_branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    manager_ids = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    OperatingHours = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cashbox",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    store_branch_id = table.Column<Guid>(type: "UUID", nullable: false),
                    chashier_ids = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    key = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    balance = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    last_updated_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox", x => x.id);
                    table.ForeignKey(
                        name: "FK_cashbox_store_branch_store_branch_id",
                        column: x => x.store_branch_id,
                        principalTable: "store_branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    first_name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    position = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    hire_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    department = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    StoreBranchId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_store_branch_StoreBranchId",
                        column: x => x.StoreBranchId,
                        principalTable: "store_branch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cashbox_chashier",
                columns: table => new
                {
                    CashboxId = table.Column<Guid>(type: "UUID", nullable: false),
                    ChashiersId = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox_chashier", x => new { x.CashboxId, x.ChashiersId });
                    table.ForeignKey(
                        name: "FK_cashbox_chashier_cashbox_CashboxId",
                        column: x => x.CashboxId,
                        principalTable: "cashbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cashbox_chashier_employee_ChashiersId",
                        column: x => x.ChashiersId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cashbox_operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CashboxId = table.Column<Guid>(type: "UUID", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UUID", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    transaction_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    CashboxId1 = table.Column<Guid>(type: "UUID", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox_operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cashbox_operation_cashbox_CashboxId",
                        column: x => x.CashboxId,
                        principalTable: "cashbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cashbox_operation_cashbox_CashboxId1",
                        column: x => x.CashboxId1,
                        principalTable: "cashbox",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cashbox_operation_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    manufacture_id = table.Column<Guid>(type: "UUID", nullable: true),
                    category_id = table.Column<Guid>(type: "UUID", nullable: false),
                    product_attribute_id = table.Column<Guid>(type: "UUID", nullable: true),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    unit = table.Column<string>(type: "VARCHAR", nullable: false),
                    image_name = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: true),
                    weight = table.Column<decimal>(type: "DECIMAL", nullable: true),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    manufacture_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    sku = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_manufacture_manufacture_id",
                        column: x => x.manufacture_id,
                        principalTable: "manufacture",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_attribute",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    color = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
                    memory = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
                    ram = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
                    product_id = table.Column<Guid>(type: "UUID", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_attribute_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_price",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    product_id = table.Column<Guid>(type: "UUID", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "UUID", nullable: false),
                    price_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    PriceTypeID1 = table.Column<Guid>(type: "uuid", nullable: true),
                    product_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_price", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_price_price_type_PriceTypeID1",
                        column: x => x.PriceTypeID1,
                        principalTable: "price_type",
                        principalColumn: "price_type_id");
                    table.ForeignKey(
                        name: "FK_product_price_price_type_price_type_id",
                        column: x => x.price_type_id,
                        principalTable: "price_type",
                        principalColumn: "price_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_price_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_price_stock_warehouse_id",
                        column: x => x.warehouse_id,
                        principalTable: "stock",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    is_available = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    last_updated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    product_price_id = table.Column<Guid>(type: "UUID", nullable: false),
                    product_id1 = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_in_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_in_stock_product_price_product_price_id",
                        column: x => x.product_price_id,
                        principalTable: "product_price",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_in_stock_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_in_stock_product_product_id1",
                        column: x => x.product_id1,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_in_stock_provider_provider_id",
                        column: x => x.provider_id,
                        principalTable: "provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_in_stock_stock_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stock",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_store_branch_id",
                table: "cashbox",
                column: "store_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_chashier_ChashiersId",
                table: "cashbox_chashier",
                column: "ChashiersId");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_CashboxId",
                table: "cashbox_operation",
                column: "CashboxId");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_CashboxId1",
                table: "cashbox_operation",
                column: "CashboxId1");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_EmployeeId",
                table: "cashbox_operation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_StoreBranchId",
                table: "employee",
                column: "StoreBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_manufacture_id",
                table: "product",
                column: "manufacture_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_attribute_id",
                table: "product",
                column: "product_attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_product_id",
                table: "product_attribute",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_product_id",
                table: "product_in_stock",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_product_id1",
                table: "product_in_stock",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_product_price_id",
                table: "product_in_stock",
                column: "product_price_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_provider_id",
                table: "product_in_stock",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_in_stock_stock_id",
                table: "product_in_stock",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_price_type_id",
                table: "product_price",
                column: "price_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_PriceTypeID1",
                table: "product_price",
                column: "PriceTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_product_id",
                table: "product_price",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_price_warehouse_id",
                table: "product_price",
                column: "warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_attribute_product_attribute_id",
                table: "product",
                column: "product_attribute_id",
                principalTable: "product_attribute",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_category_category_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_manufacture_manufacture_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_attribute_product_attribute_id",
                table: "product");

            migrationBuilder.DropTable(
                name: "cashbox_chashier");

            migrationBuilder.DropTable(
                name: "cashbox_operation");

            migrationBuilder.DropTable(
                name: "product_in_stock");

            migrationBuilder.DropTable(
                name: "cashbox");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "product_price");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "store_branch");

            migrationBuilder.DropTable(
                name: "price_type");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "manufacture");

            migrationBuilder.DropTable(
                name: "product_attribute");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
