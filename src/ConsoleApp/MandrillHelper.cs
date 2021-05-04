using System;
using System.Threading.Tasks;
using Mandrill;
using Mandrill.Models;

namespace ConsoleApp
{
    public class MandrillHelper
    {
        private readonly IMandrillApi _api;

        public MandrillHelper(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or whitespace.", nameof(apiKey));
            }

            _api = new MandrillApi(apiKey);
        }

        public async Task<string> DownloadTemplateAsync(string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
            {
                throw new ArgumentException($"'{nameof(templateName)}' cannot be null or whitespace.", nameof(templateName));
            }

            var templateInfo = await _api.TemplateInfo(new Mandrill.Requests.Templates.TemplateInfoRequest(templateName));
            return templateInfo.Code;
        }

        public async Task SendMessageAsync(string from, string to, string html)
        {
            if (string.IsNullOrWhiteSpace(from))
            {
                throw new ArgumentException($"'{nameof(from)}' cannot be null or empty.", nameof(from));
            }

            if (string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentException($"'{nameof(to)}' cannot be null or empty.", nameof(to));
            }

            if (string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentException($"'{nameof(html)}' cannot be null or empty.", nameof(html));
            }            

            var emailResult = await _api.SendMessage(new Mandrill.Requests.Messages.SendMessageRequest(new EmailMessage
            {
                FromEmail = from,
                To = new[] { new EmailAddress(to)},
                Html = html
            }));
        }
    }
}
