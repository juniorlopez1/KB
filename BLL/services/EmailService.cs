using DALL.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.services
{
    public class EmailService
    {
        private string server = "smtp.gmail.com";
        private MailAddress origen = new MailAddress("greenplanet.cr2019@gmail.com", "Green Planet");
        private string contrasenna = "GREENplanet1";

        public void enviarCorreo(ref EmailDal emailInfo)
        {
            SmtpClient client = new SmtpClient {
                Host = server,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(origen.Address, contrasenna),
                Timeout = 5000
            };

            MailAddress destino = new MailAddress(emailInfo.Destino);

            MailMessage mensaje = new MailMessage(origen, destino)
            {
                Subject = emailInfo.Subject,
                IsBodyHtml = true,
                Body = emailInfo.Cuerpo
            };

            try
            {
                client.Send(mensaje);
            } catch(Exception e)
            {

            }
        }
    }
}
