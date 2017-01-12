using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffListWork.Startup))]
namespace StaffListWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
