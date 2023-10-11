using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using QualifiedAgencies.Controllers;

namespace QualifiedAgencies.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : QualifiedAgenciesControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
