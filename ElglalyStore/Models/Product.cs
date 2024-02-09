using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Product
    {
        [Key]
        public int product_Id { get; set; }


        [Required,Column(TypeName ="nvarchar(100)")]
        [Display(Name ="Product Name")]
        public string product_name { get; set;}


        [Required, Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Product Description")]
        public string product_description { get; set;}


        [Required]
        [DataType(DataType.Currency,ErrorMessage ="Must be Price")]
        [Display(Name ="Product Price")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal product_price { get; set;}


        [ForeignKey("category")]
        public int product_category_id { get; set;}
        public Category category { get; set;}

        [Required]
        [RegularExpression(@"[a-z]\.[jpj|png]")]
        public string product_image {  get; set; }
        
    }
}
