using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cart_Id { get; set; }

        [Required, Display(Name = "Quantity")]
        public int Cart_quantity { get; set; }

        [Required]
        public int Cart_custmer_id { get; set; }

        [Required]
        public int Cart_product_id { get; set; }

        [ForeignKey("Cart_custmer_id")]
        public Customer? customer { get; set; }

        [ForeignKey("Cart_product_id")]
        public Product? product { get; set; }
    }
}
