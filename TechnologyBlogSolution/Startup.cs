using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechnologyBlogSolution.Startup))]
namespace TechnologyBlogSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
