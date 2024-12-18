﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OsonCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
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
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
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
                    is_available = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
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
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    first_name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cashbox",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    store_branch_id = table.Column<Guid>(type: "UUID", nullable: false),
                    cashier_ids = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    key = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    balance = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true),
                    last_updated_date = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false)
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
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    shipping_address = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    position = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    hire_date = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true),
                    department = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: true),
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
                    table.ForeignKey(
                        name: "FK_employee_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cashbox_cashier",
                columns: table => new
                {
                    CashboxId = table.Column<Guid>(type: "UUID", nullable: false),
                    CashiersId = table.Column<Guid>(type: "UUID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox_cashier", x => new { x.CashboxId, x.CashiersId });
                    table.ForeignKey(
                        name: "FK_cashbox_cashier_cashbox_CashboxId",
                        column: x => x.CashboxId,
                        principalTable: "cashbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cashbox_cashier_employee_CashiersId",
                        column: x => x.CashiersId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cashbox_operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    cashbox_id = table.Column<Guid>(type: "UUID", nullable: false),
                    employee_id = table.Column<Guid>(type: "UUID", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    transaction_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    CashboxId1 = table.Column<Guid>(type: "UUID", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashbox_operation", x => x.id);
                    table.ForeignKey(
                        name: "FK_cashbox_operation_cashbox_CashboxId1",
                        column: x => x.CashboxId1,
                        principalTable: "cashbox",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cashbox_operation_cashbox_cashbox_id",
                        column: x => x.cashbox_id,
                        principalTable: "cashbox",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cashbox_operation_employee_employee_id",
                        column: x => x.employee_id,
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
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
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
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
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
                    is_available = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true),
                    last_updated = table.Column<DateTime>(type: "TIMESTAMP WITH TIME ZONE", nullable: false),
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

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" },
                    { 3, "Cashier" },
                    { 4, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "first_name", "last_name", "password", "phone_number" },
                values: new object[] { new Guid("9643a27f-5910-4dde-b804-f4aef76efc8b"), "adminadmin@gmail.com", "Admin", "Admin", "$2a$11$ui9LyxF8SdsmW4npcBp0mepQVpo3L.xJ6E4KtOSWXZhd6ebCxF572", "+992-00-000-00-00" });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "department", "hire_date", "is_active", "position", "StoreBranchId" },
                values: new object[] { new Guid("9643a27f-5910-4dde-b804-f4aef76efc8b"), "Admin", new DateTime(2024, 11, 26, 11, 59, 14, 365, DateTimeKind.Utc).AddTicks(2523), true, "Admin", null });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { 1, new Guid("9643a27f-5910-4dde-b804-f4aef76efc8b") });

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_store_branch_id",
                table: "cashbox",
                column: "store_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_cashier_CashiersId",
                table: "cashbox_cashier",
                column: "CashiersId");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_cashbox_id",
                table: "cashbox_operation",
                column: "cashbox_id");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_CashboxId1",
                table: "cashbox_operation",
                column: "CashboxId1");

            migrationBuilder.CreateIndex(
                name: "IX_cashbox_operation_employee_id",
                table: "cashbox_operation",
                column: "employee_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

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
                name: "cashbox_cashier");

            migrationBuilder.DropTable(
                name: "cashbox_operation");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "product_in_stock");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "cashbox");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "product_price");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "store_branch");

            migrationBuilder.DropTable(
                name: "user");

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
