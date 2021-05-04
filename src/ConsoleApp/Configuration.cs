using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    public class Configuration
    {
        public Configuration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<Program>()
                .Build();

            MandrillApiKey = config.GetValue<string>("Mandrill:ApiKey");
        }

        public string MandrillApiKey { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Config");
            stringBuilder.AppendLine("======================================================");
            stringBuilder.AppendLine(" -> Mandrill");
            stringBuilder.AppendLine($"     - ApiKey: {MandrillApiKey}");
            stringBuilder.AppendLine("======================================================");

            return stringBuilder.ToString();
        }
    }
}
