using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class MailManager : IMailService
    {

        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> options)
        {
            _smtpSettings = options.Value;
        }

        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.Email) },
                Subject = emailSendDto.Subject,
                Body = emailSendDto.Message,
                IsBodyHtml = true,
            };

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            smtpClient.Send(message);
            return new Result(ResultStatus.Success, "Başarılı");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress("malikulle7@gmail.com") },
                Subject = emailSendDto.Subject,
                Body = $"Gönderen Kişi : {emailSendDto.Name} , Gönderen E-Posta Adresi : {emailSendDto.Email}\n {emailSendDto.Message}",
                IsBodyHtml = true,                
            };

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            smtpClient.Send(message);
            return new Result(ResultStatus.Success, "Başarılı");
        }
    }
}
