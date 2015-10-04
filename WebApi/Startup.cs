using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Owin;

namespace WebApi
{
    public class Startup
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration
            {
                //LocalOnly (default), Always, Never
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never 
            };

            // remove xml formmatter
            var appXmlType = webApiConfiguration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            webApiConfiguration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Web API routes
            webApiConfiguration.MapHttpAttributeRoutes();


            app.UseWebApi(webApiConfiguration);
        }
    }
}