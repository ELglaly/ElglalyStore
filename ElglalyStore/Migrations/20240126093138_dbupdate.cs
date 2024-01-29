using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElglalyStore.Migrations
{
    /// <inheritdoc />
    public partial class dbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fisrt_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_Id);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "Categorys",
                        principalColumn: "category_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.payment_Id);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_payment_customer_id",
                        column: x => x.payment_customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cart_Id = table.Column<int>(type: "int", nullable: false),
                    Cart_custmer_id = table.Column<int>(type: "int", nullable: false),
                    Cart_quantity = table.Column<int>(type: "int", nullable: false),
                    Cart_product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.cart_Id, x.Cart_custmer_id });
                    table.ForeignKey(
                        name: "FK_Carts_Customers_Cart_custmer_id",
                        column: x => x.Cart_custmer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Carts_Products_Cart_product_id",
                        column: x => x.Cart_product_id,
                        principalTable: "Products",
                        principalColumn: "product_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customer_product_id = table.Column<int>(type: "int", nullable: false),
                    order_payment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customer_product_id",
                        column: x => x.customer_product_id,
                        principalTable: "Customers",
                        principalColumn: "customer_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_order_payment_id",
                        column: x => x.order_payment_id,
                        principalTable: "Payments",
                        principalColumn: "payment_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orderitems",
                columns: table => new
                {
                    order_item_Id = table.Column<int>(type: "int", nullable: false),
                    order_order_item = table.Column<int>(type: "int", nullable: false),
                    order_quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    order_product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderitems", x => new { x.order_item_Id, x.order_order_item });
                    table.ForeignKey(
                        name: "FK_Orderitems_Orders_order_order_item",
                        column: x => x.order_order_item,
                        principalTable: "Orders",
                        principalColumn: "order_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orderitems_Products_order_product_id",
                        column: x => x.order_product_id,
                        principalTable: "Products",
                        principalColumn: "product_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Cart_custmer_id",
                table: "Carts",
                column: "Cart_custmer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Cart_product_id",
                table: "Carts",
                column: "Cart_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_order_order_item",
                table: "Orderitems",
                column: "order_order_item");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_order_product_id",
                table: "Orderitems",
                column: "order_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_product_id",
                table: "Orders",
                column: "customer_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_order_payment_id",
                table: "Orders",
                column: "order_payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_payment_customer_id",
                table: "Payments",
                column: "payment_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_product_category_id",
                table: "Products",
                column: "product_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orderitems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
