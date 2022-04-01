using Microsoft.Extensions.Configuration;
using Prombox.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly SmtpClient _client;
        private readonly IConfiguration _configuration;
        private readonly string TemplateNamespace = "Prombox.Service.Services.Mail.Templates.";
        private string Email { get; set; }
        private string AppUrl { get; set; }
        private string Label { get; set; }
        private string EMailDev { get; set; }

        public MailService(IConfiguration configuration
            )
        {
            _configuration = configuration;
            _client = CreateSmtpClient();
        }

        private SmtpClient CreateSmtpClient()
        {
            this.AppUrl = _configuration.GetSection("General").GetSection("AppUrl").Value;
            this.Label = _configuration.GetSection("MailSettings").GetSection("Label").Value;
            var host = _configuration.GetSection("MailSettings").GetSection("Host").Value;
            var port = Convert.ToInt32(_configuration.GetSection("MailSettings").GetSection("Port").Value);
            this.Email = _configuration.GetSection("MailSettings").GetSection("Email").Value;
            this.EMailDev = _configuration.GetSection("MailSettings").GetSection("EMailDev").Value;
            var password = _configuration.GetSection("MailSettings").GetSection("Password").Value;

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 10000;

            var networkCredential = new NetworkCredential(this.Email, password);
            // smtpClient.UseDefaultCredentials = false;  // ********* incluí
            smtpClient.Credentials = networkCredential;

            return smtpClient;
        }

        public void NovoUsuario(string nome, string email, string senha)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("APP_URL", this.AppUrl);
            tags.Add("NOME", nome);
            tags.Add("LOGIN", email);
            tags.Add("SENHA", senha);

            message.Subject = "Prombox - Usuário cadastrado";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("NovoUsuario.html", tags);

            Send(message);
        }
        public void NovoUsuarioCliente(string nome, string email, string cpf)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("APP_URL", this.AppUrl);
            tags.Add("NOME", nome);
            tags.Add("CPF", cpf);            

            message.Subject = "Prombox - Usuário cadastrado";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("NovoUsuarioCliente.html", tags);

            Send(message);
        }

        public void SenhaAlterada(string nome, string email, string cpf)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("APP_URL", this.AppUrl);
            tags.Add("NOME", nome);
            tags.Add("CPF", cpf);

            message.Subject = "Prombox - Senha Alterada";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("SenhaAlterada.html", tags);

            Send(message);
        }
        public void RecuperarSenha(string nome, string email, int code, string codeEncrypt)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("APP_URL", this.AppUrl);
            tags.Add("CODE_ENCRYPT", codeEncrypt);
            tags.Add("CODE", code.ToString());

            message.Subject = "Prombox - Esqueci minha senha";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("RecuperarSenha.html", tags);

            Send(message);
        }

        public void RecuperarSenhaUsuarioCliente(string nome, string email, string cpf, int code, string codeEncrypt)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("APP_URL", this.AppUrl);
            tags.Add("CODE_ENCRYPT", codeEncrypt);
            tags.Add("CPF", cpf);
            tags.Add("CODE", code.ToString());

            message.Subject = "Prombox - Esqueci minha senha";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("RecuperarSenhaUsuarioCliente.html", tags);

            Send(message);
        }

        public void NovaSenha(string nome, string email, string novaSenha)
        {
            var message = new MailMessage(
                new MailAddress(this.Email, this.Label),
                new MailAddress(email, nome));

            var tags = new Dictionary<string, string>();
            tags.Add("PASSWORD", novaSenha);

            message.Subject = "Prombox - Esqueci minha senha";
            message.IsBodyHtml = true;
            message.Body = ReplaceTags("NovaSenha.html", tags);

            Send(message);
        }

        private void Send(MailMessage message, List<string> attachments = null, bool deleteAttachments = false)
        {
            try
            {
                if (attachments != null && attachments.Count > 0)
                {
                    foreach (var attachment in attachments)
                        message.Attachments.Add(new Attachment(attachment));
                }

                if (!String.IsNullOrEmpty(this.EMailDev))
                {
                    message.To.Clear();
                    message.To.Add(this.EMailDev);

                    if (message.CC.Count > 0)
                    {
                        message.CC.Clear();
                    }

                    if (message.Bcc.Count > 0)
                    {
                        message.Bcc.Clear();
                    }
                }

                _client.Send(message);
            }
            catch (Exception ex)
            {
               var x = ex;
                // _logger.LogError(ex.Message, ex);
            }
            finally
            {
                if (_client != null)
                    _client.Dispose();

                if (attachments != null && attachments.Count > 0 && deleteAttachments)
                {
                    foreach (var attachment in attachments)
                    {
                        /*
                        if (File.Exists(attachment))
                            File.Delete(attachment);
                        */
                    }
                }
            }
        }

        private string ReplaceTags(string templateKey, Dictionary<string, string> tags)
        {
            var content = GetTemplate(templateKey);

            foreach (KeyValuePair<string, string> entry in tags)
                content = content.Replace(String.Format("#{0}#", entry.Key), entry.Value);

            return content;
        }

        private string GetTemplate(string template)
        {
            var content = String.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(TemplateNamespace + template))
            {
                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            return content;
        }
    }
}
