using DALL.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BLL.services
{
    public class SMSService
    {
        private const string accountSID = "ACd2b780751336226831d550dcdd7bd164";
        private const string authToken = "0cd23586eb94058984b5b94adc8f3e80";

        public void enviarSMS(ref SMSDal smsInfo)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            TwilioClient.Init(accountSID, authToken);

            var msj = MessageResource.Create(
                body: smsInfo.Contenido,
                from: new Twilio.Types.PhoneNumber("+12056198350"),
                to: new Twilio.Types.PhoneNumber(smsInfo.NumeroDestino)
                );
        }
    }
}
