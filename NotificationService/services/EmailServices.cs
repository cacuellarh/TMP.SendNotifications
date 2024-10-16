using Microsoft.Extensions.Configuration;
using NotificationService.events.eventArgs;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace NotificationService.services
{
    public class EmailServices : IEmailServices
    {
        private SmtpClient smtpClient { get;  set; }
        private MailMessage mail { get; set; }
        public EmailServices(IConfiguration configuration)
        {
            ConfigurateEmailService(configuration);
        }
        public void SendEmail(NotifyPriceChangeEvent priceScanInfo)
        {
            try
            {
                string lastPrice = priceScanInfo.lastPrice.Product.Precio.ToString("N2");
                var currentPrice = priceScanInfo.productCurrentPrice.Precio.ToString("N2");

                mail.To.Add(priceScanInfo.lastPrice.Email);
                mail.Subject = $"Notificacion cambio de precio {lastPrice}";
                mail.Body = EmailTemplate.GetEmailHtmlFormat("Precio prueba", lastPrice, currentPrice);
                mail.IsBodyHtml = true;

                smtpClient.Send(mail);

                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (SmtpException ex)
            {
                string errorMessage = $"Error al enviar el correo: {ex.Message}";
                Console.WriteLine(errorMessage);
                Log.Error(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Ocurrió un error inesperado: {ex.Message}";
                Console.WriteLine(errorMessage);
            }
        }
        private void ConfigurateEmailService(IConfiguration configuration)
        {
            mail = new MailMessage();
            mail.From = new MailAddress(configuration.GetConnectionString("Email"));

            smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new 
                NetworkCredential(configuration.GetConnectionString("Email"),
                configuration.GetConnectionString("EmailPassword"));
            smtpClient.EnableSsl = true;
        }
    }

}
