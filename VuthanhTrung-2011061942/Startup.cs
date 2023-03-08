using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VuthanhTrung_2011061942.Startup))]
namespace VuthanhTrung_2011061942
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
