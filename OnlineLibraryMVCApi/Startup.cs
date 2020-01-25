using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineLibraryMVCApi.Startup))]

namespace OnlineLibraryMVCApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}