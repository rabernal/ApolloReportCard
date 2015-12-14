using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApolloReportCard.Startup))]
namespace ApolloReportCard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
