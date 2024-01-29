using Microsoft.EntityFrameworkCore;

namespace ElglalyStore.Models
{
    public class Appdbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-114872S;Initial Catalog=E-CommerceDB; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.cart_Id, c.Cart_custmer_id });
            modelBuilder.Entity<Order_item>()
               .HasKey(c => new { c.order_item_Id, c.order_order_item });

            //modelBuilder.Entity("ElglalyStore.Models.Order", b =>
            //{
            //    b.HasOne("ElglalyStore.Models.Customer", "customer")
            //        .WithMany()
            //        .HasForeignKey("customer_product_id")
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .IsRequired();

            //    b.HasOne("ElglalyStore.Models.Payment", "payment")
            //        .WithMany()
            //        .HasForeignKey("order_payment_id")
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .IsRequired();

            //    b.Navigation("customer");

            //    b.Navigation("payment");
            //});

        }
       public  DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_item> Orderitems { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }


    }

    



}
