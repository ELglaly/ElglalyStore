using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElglalyStore.Models
{
    public class CheckoutModelView 
    {
		[Required(ErrorMessage = "Required Feild")]
		[MinLength(3, ErrorMessage = "at least 3 charachters")]
		[MaxLength(20, ErrorMessage = "maximam 20 charachters")]
		[Display(Name = "First Name")]
		public string Fisrt_name { get; set; }



		[Required(ErrorMessage = "Required Feild")]
		[MinLength(3, ErrorMessage = "At least 3 charachters")]
		[MaxLength(20, ErrorMessage = "maximam 20 charachters")]
		[Display(Name = "Last Name")]
		public string Last_name { get; set; }


		[Required]
		[DataType(DataType.Currency, ErrorMessage = "Must be Price"),]
		[Column(TypeName = "decimal(10,2)")]
		public decimal total_price { get; set; }


		public string? Note { get; set; }



		[Required(ErrorMessage = "Required")]
		[Column(TypeName = "nvarchar(255)")]
		[Display(Name = "Address")]
		public string Address { get; set; }



		[Required]
		[Phone, Column(TypeName = "varchar(11)")]
		[DataType(DataType.PhoneNumber)]
		[MaxLength(11)]
		[MinLength(11, ErrorMessage = "Must Be 11 Digits")]
		[Display(Name = "Phone Number")]
		public string Phone_number { get; set; }


		public string? Posta_code { get; set; }

		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage ="Required")]
		public string City { get; set; }

		
		public List<CartModelView> CartView { get; set; }

	}
}
