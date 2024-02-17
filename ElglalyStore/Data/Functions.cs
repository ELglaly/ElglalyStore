using ElglalyStore.Models;
using System.Net.Mail;
using System.Net;

namespace ElglalyStore.Data
{
    public class Functions
    {

		
		public static void Send_Email(string email, Customer customer)
        {

            if (!string.IsNullOrWhiteSpace(email))
            {
             
                Random random = new Random();
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                mailMessage.Subject = "Authentication Code for Password Change - CCMS";
                mailMessage.From = new MailAddress(email);
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Body = $"Dear {customer.Fisrt_name},\n\n" +
                       $"We hope this email finds you well. Your request to change the password for your account on the CCMS app has been received.\n\n" +
                       $"To proceed with the password change, please use the following authentication code:\n\n" +

                       $"Please enter this code within the CCMS app to verify your identity and initiate the password change process.\n\n" +
                       $"If you did not make this request, or if you have any concerns regarding your account security, please contact our support team immediately at winformapp010@gmail.com.\n\n" +
                       $"Thank you for choosing CCMS. We are committed to ensuring the security of your account.\n\n" +
                       $"Best regards,\n" +
                       $"Elglaly Store - Sherif Elglaly \n" +
                       $"01026386402";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                // Use an application-specific password or a secure method to handle credentials
                string yourGmailAddress = "winformapp010@gmail.com";
                string yourAppSpecificPassword = "qdsqwsnazpxajhes";

                smtp.Credentials = new NetworkCredential(yourGmailAddress, yourAppSpecificPassword);

               
                    smtp.Send(mailMessage);
                
               


            }
        }


            public interface IEmailSender<T> where T : Customer
              {
                   void SendEmail(T entity, string subject, string body);
            
              }





    }
}

