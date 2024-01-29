using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Order_item
    {
        [Key]
        public int order_item_Id { get; set; }

        [Required]
        public int order_quantity { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        [Required,DataType(DataType.Currency,ErrorMessage ="Must be Price")]
        public decimal price { get; set; }



        [ForeignKey("product")]
        public int order_product_id { get; set; }



        [ForeignKey("order")]
        public int order_order_item { get; set; }

        [Required]
        public Order order { get; set; }
        [Required]
        public Product product { get; set; }    
    }
}
