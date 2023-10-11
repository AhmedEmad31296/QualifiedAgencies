using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using QualifiedAgencies.Authorization;
using QualifiedAgencies.Common;
using QualifiedAgencies.Controllers;
using QualifiedAgencies.Entities;
using QualifiedAgencies.Entities.Dto;
using QualifiedAgencies.Lookups;
using QualifiedAgencies.Users;
using QualifiedAgencies.Web.Models.Roles;

using System;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

using static QualifiedAgencies.Helpers.Datatable;

namespace QualifiedAgencies.Web.Controllers
{
    public class EntitiesController : QualifiedAgenciesControllerBase
    {
        private readonly IEligibleEntityAppService _IEligibleEntityAppService;
        private readonly ILookupsAppService _ILookupsAppService;
        public EntitiesController(IEligibleEntityAppService iEligibleEntityAppService, ILookupsAppService ILookupsAppService)
        {
            _IEligibleEntityAppService = iEligibleEntityAppService;
            _ILookupsAppService = ILookupsAppService;
        }
        public async Task<ActionResult> Index(Category? category)
        {
            ViewData["category"] = category;
            ViewData["Activities"] = new SelectList(await _ILookupsAppService.GetActivities(), "Id", "Name");
            ViewData["ActivityTypes"] = new SelectList(await _ILookupsAppService.GetActivityTypes(), "Id", "Name");
            ViewData["Areas"] = new SelectList(await _ILookupsAppService.GetAreas(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GetPaged(int? category)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int start = Convert.ToInt32(HttpContext.Request.Form["start"].FirstOrDefault());
            int length = Convert.ToInt32(HttpContext.Request.Form["length"].FirstOrDefault());
            string sortColumn = HttpContext.Request.Form[$"columns[{HttpContext.Request.Form["order[0][column]"].FirstOrDefault()}][name]"].FirstOrDefault();
            string sortColumnDir = HttpContext.Request.Form["order[0][dir]"].FirstOrDefault();
            string searchTerm = HttpContext.Request.Form["search[value]"].FirstOrDefault();


            FilterEligibleEntityPagedInput input = new()
            {
                Category = category,
                Draw = draw,
                Page = start / length + 1,
                PageSize = length,
                SortColumn = sortColumn,
                SortDirection = sortColumnDir,
                SearchTerm = searchTerm
            };

            DatatableFilterdDto<EligibleEntityPagedDto> result = await _IEligibleEntityAppService.GetPaged(input);
            return Json(result);
        }
        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<JsonResult> Delete(long id)
        {
            return Json(await _IEligibleEntityAppService.Delete(id));
        }
        [HttpGet]
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<ActionResult> EditModal(long id)
        {
            var result = await _IEligibleEntityAppService.Get(id);
            ViewData["Activities"] = new SelectList(await _ILookupsAppService.GetActivities(), "Id", "Name");
            ViewData["ActivityTypes"] = new SelectList(await _ILookupsAppService.GetActivityTypes(), "Id", "Name");
            ViewData["Areas"] = new SelectList(await _ILookupsAppService.GetAreas(), "Id", "Name");
            return PartialView("_EditModal", result);
        }
        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<JsonResult> Create(InsertEligibleEntityInput input)
        {
           
            return Json(await _IEligibleEntityAppService.Insert(input));
        }
        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_Users)]
        public async Task<JsonResult> Update(UpdateEligibleEntityInput input)
        {
            return Json(await _IEligibleEntityAppService.Update(input));
        }
    }
}
