using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElglalyStore.Models
{
    public class Payment
    {
        [Key]
        public int payment_Id { get; set; }

        [Required,DataType(DataType.Currency,ErrorMessage ="Must be Price")]
        [Column(TypeName ="decimal(10,2)")]
        public decimal amount { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Must Choose A date"),Required]
        public DateTime order_date { get; set; }

        [ForeignKey("customer")]
        public int payment_customer_id { get; set; }
        public Customer customer { get; set; }

        






    }
}
