using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Order
    {
        [Key]
        public int order_Id { get; set; }


        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Must be Price"),]
        [Column(TypeName = "decimal(10,2)")]
        public decimal total_price { get; set; }



        [Required]
        [DataType(DataType.Date,ErrorMessage ="Must Choose A date"),]
        public DateTime order_date { get; set; }    

        [ForeignKey("customer")]
        public int customer_product_id { get; set; }
        [Required]
        public Customer customer { get; set; }




        [ForeignKey("payment")]
        public int order_payment_id { get; set; }
        [Required(ErrorMessage = "Payment is required")]
        public Payment payment { get; set; }

     
    }
}
