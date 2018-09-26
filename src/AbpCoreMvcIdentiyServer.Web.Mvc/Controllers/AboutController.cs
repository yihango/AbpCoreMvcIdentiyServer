using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCoreMvcIdentiyServer.Controllers;

namespace AbpCoreMvcIdentiyServer.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AbpCoreMvcIdentiyServerControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
