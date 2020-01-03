using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(FRI_ride.Startup))]
namespace FRI_ride
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
