using HandlebarsDotNet;

namespace ConsoleApp
{
    public class HandlebarsHelper
    {
        private HandlebarsTemplate<object, object> _mainTemplate;

        public HandlebarsHelper(string mainTemplateRaw, string partialTemplateRaw)
        {
            Handlebars.RegisterTemplate("user", partialTemplateRaw);
            _mainTemplate = Handlebars.Compile(mainTemplateRaw);
        }

        public string CompileAndRender(object data) => _mainTemplate(data);
    }
}
