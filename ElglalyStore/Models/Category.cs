using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Category
    {
        [Key]
        public int category_Id { get; set; }

        [Required,Column(TypeName= "nvarchar(100)")]
        [Display(Name ="Category Name")]
        public string category_name { get; set;}
    }
}
