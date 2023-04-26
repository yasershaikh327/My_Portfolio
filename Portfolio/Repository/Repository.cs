using Portfolio.Models;
using System.Net.Mail;

namespace Portfolio.Repository
{
    public class Repository
    {
        public interface IRepository 
        {
            void SendMail(MailModel mail);
        }

        public class RepositoryService : IRepository 
        {
            public void SendMail(MailModel mail)
            {
                //Sending An Email
                try
                {
                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credential = new System.Net.NetworkCredential("syaser327@outlook.com", ",zk7ZLkTE#7f4Y^");
                    client.EnableSsl = true;
                    client.Credentials = credential;
                    MailMessage message = new MailMessage("syaser327@outlook.com", mail.email);
                    message.Subject = "Reply";
                    message.Body = "<table style=\"border:2px solid black;\">\r\n    <tr>\r\n       " +
                        " <td style=\"border:2px solid black;text-align: center;background-color: white;font-family: Poppins, " +
                        "sans-serif;font-size: x-large;font-weight: bolder;\">Port<span style=\"color: green;\">folio</span>" +
                        "</td>\r\n    </tr>\r\n    <tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;" +
                        "text-align: center;\">Thank You for contacting Us</td>\r\n    </tr>\r\n    <tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;text-align: center;\">We " +
                        "will get back to you as soon as Possible</td>\r\n   <tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;text-align: center;\">"+mail.name+"</td>\r\n<tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;text-align: center;\">"+mail.email+"</td>\r\n<tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;text-align: center;\">"+mail.subject+"</td>\r\n<tr>\r\n        <td style=\"border:2px solid black;font-family: cursive;text-align: center;\">"+mail.message+"</td>\r\n </tr>\r\n</table>";
                    message.IsBodyHtml = true;
                    client.Send(message);

                    // return Content(FirstName,LastName,Phone, Email, gender, Address,DOB,Username,Password,CPassword);
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
        }
    }
}
