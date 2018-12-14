using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTwitterClone.Startup))]
namespace MyTwitterClone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
