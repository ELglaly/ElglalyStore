using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElglalyStore.Models
{
    public class Customer
    {
        public Customer() {

                 birth_date=DateTime.Now;
                
                }
        [Key]
        public int customer_Id { get; set; }


        [Required(ErrorMessage ="Required Feild")]
        [MinLength(3, ErrorMessage = "at least 3 charachters")]
        [MaxLength(20,ErrorMessage ="maximam 20 charachters")]
        [Display(Name = "First Name")]
        public string fisrt_name { get; set; }



        [Required(ErrorMessage = "Required Feild")]
        [MinLength(3, ErrorMessage = "At least 3 charachters")]
        [MaxLength(20, ErrorMessage = "maximam 20 charachters")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }



        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address")]
        public  string email {  get; set;}



        [Phone,Column(TypeName ="varchar(11)")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        [MinLength(11,ErrorMessage = "Must Be 11 Digits")]
        [Display(Name = "Phone Number")]
        public string phone_number { get; set;}



        [Column(TypeName ="nvarchar(255)")]
        [Display(Name = "Address")]
        public string? address { get; set;}



       // [RegularExpression(@"^()",ErrorMessage = "Password must contain at least one digit and one special character.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Column(TypeName ="nvarchar(100)")]
        [MaxLength(100,ErrorMessage = "Maximam 100 charachters")]
         public string password { get; set;}


        [Required(ErrorMessage ="Enter Birth Date")]
        [Display(Name ="Birth Date")]
        [Range(typeof(DateTime), "1950-01-01", "2100-01-01", ErrorMessage = "Invalid date.")]
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }


    }
}
