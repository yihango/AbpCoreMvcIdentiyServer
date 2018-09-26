using Microsoft.AspNetCore.Antiforgery;
using AbpCoreMvcIdentiyServer.Controllers;

namespace AbpCoreMvcIdentiyServer.Web.Host.Controllers
{
    public class AntiForgeryController : AbpCoreMvcIdentiyServerControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
