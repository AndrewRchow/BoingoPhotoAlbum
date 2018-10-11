using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoingoPhotoAlbum.Startup))]
namespace BoingoPhotoAlbum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
