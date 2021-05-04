using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Read config.
            var configuration = new Configuration();
            Console.WriteLine(configuration.ToString());

            // Download templates from Mandrill.
            var mandrillHelper = new MandrillHelper(configuration.MandrillApiKey);
            var mainTemplate = await mandrillHelper.DownloadTemplateAsync("handlebars-test");
            var partialTemplate = await mandrillHelper.DownloadTemplateAsync("handlebars-partial-test");

            // Compile using Handlebars.NET
            var handlebarsHelper = new HandlebarsHelper(mainTemplate, partialTemplate);
            var data = new
            {
                names = new[]
                {
                    new { name = "Karen" },
                    new { name = "Jon" }
                }
            };
            var rendered = handlebarsHelper.CompileAndRender(data);

            // Send email using Mandrill.NET SendMessage API.
            await mandrillHelper.SendMessageAsync("ryan@homely.com.au",
                                                  "ryan@homely.com.au",
                                                  rendered);

            Console.WriteLine("Finished! Press any key to exit..");

            Console.ReadKey();
        }

        
    }
}
