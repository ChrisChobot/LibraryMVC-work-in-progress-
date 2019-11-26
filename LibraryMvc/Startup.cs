using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryMvc.Startup))]
namespace LibraryMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
