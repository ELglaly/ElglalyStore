using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElglalyStore.Migrations
{
    /// <inheritdoc />
    public partial class cartPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_Cart_custmer_id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_Cart_product_id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Orders_order_order_item",
                table: "Orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Products_order_product_id",
                table: "Orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customer_product_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_order_payment_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_payment_customer_id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_product_category_id",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                columns: new[] { "cart_Id", "Cart_product_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_Cart_custmer_id",
                table: "Carts",
                column: "Cart_custmer_id",
                principalTable: "Customers",
                principalColumn: "customer_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_Cart_product_id",
                table: "Carts",
                column: "Cart_product_id",
                principalTable: "Products",
                principalColumn: "product_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Orders_order_order_item",
                table: "Orderitems",
                column: "order_order_item",
                principalTable: "Orders",
                principalColumn: "order_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Products_order_product_id",
                table: "Orderitems",
                column: "order_product_id",
                principalTable: "Products",
                principalColumn: "product_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customer_product_id",
                table: "Orders",
                column: "customer_product_id",
                principalTable: "Customers",
                principalColumn: "customer_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_order_payment_id",
                table: "Orders",
                column: "order_payment_id",
                principalTable: "Payments",
                principalColumn: "payment_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_payment_customer_id",
                table: "Payments",
                column: "payment_customer_id",
                principalTable: "Customers",
                principalColumn: "customer_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_product_category_id",
                table: "Products",
                column: "product_category_id",
                principalTable: "Categorys",
                principalColumn: "category_Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_Cart_custmer_id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_Cart_product_id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Orders_order_order_item",
                table: "Orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Products_order_product_id",
                table: "Orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customer_product_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_order_payment_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_payment_customer_id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_product_category_id",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "cart_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_Cart_custmer_id",
                table: "Carts",
                column: "Cart_custmer_id",
                principalTable: "Customers",
                principalColumn: "customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_Cart_product_id",
                table: "Carts",
                column: "Cart_product_id",
                principalTable: "Products",
                principalColumn: "product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Orders_order_order_item",
                table: "Orderitems",
                column: "order_order_item",
                principalTable: "Orders",
                principalColumn: "order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Products_order_product_id",
                table: "Orderitems",
                column: "order_product_id",
                principalTable: "Products",
                principalColumn: "product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customer_product_id",
                table: "Orders",
                column: "customer_product_id",
                principalTable: "Customers",
                principalColumn: "customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_order_payment_id",
                table: "Orders",
                column: "order_payment_id",
                principalTable: "Payments",
                principalColumn: "payment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_payment_customer_id",
                table: "Payments",
                column: "payment_customer_id",
                principalTable: "Customers",
                principalColumn: "customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_product_category_id",
                table: "Products",
                column: "product_category_id",
                principalTable: "Categorys",
                principalColumn: "category_Id");
        }
    }
}
