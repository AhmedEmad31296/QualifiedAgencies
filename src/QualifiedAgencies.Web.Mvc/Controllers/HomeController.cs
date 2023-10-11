using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using QualifiedAgencies.Controllers;
using QualifiedAgencies.Entities;
using System.Threading.Tasks;
using QualifiedAgencies.Entities.Dto;
using System.Collections.Generic;

namespace QualifiedAgencies.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : QualifiedAgenciesControllerBase
    {
        private readonly IEligibleEntityAppService _IEligibleEntityAppService;
        public HomeController(IEligibleEntityAppService IEligibleEntityAppService)
        {
            _IEligibleEntityAppService = IEligibleEntityAppService;
        }
        public async Task<ActionResult> Index()
        {
            GetStatisticsDto statistics = await _IEligibleEntityAppService.GetStatistics();
            return View(statistics);
        }
    }
}
