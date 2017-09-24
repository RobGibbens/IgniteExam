using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QuestionAppService.Startup))]

namespace QuestionAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}