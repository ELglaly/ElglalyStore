using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Cart
    {
        [Key]
        public int cart_Id { get; set; }

        [Required,Display(Name = "Quantity")]
        public int Cart_quantity { get; set; }


        [Required,ForeignKey("customer")]
        public int Cart_custmer_id { get; set;}



        [Required,ForeignKey("product")]
        public int Cart_product_id { get; set; }


        [Required]
        public Customer customer { get; set; }
        [Required]
        public Product product { get; set;}

    }
}
