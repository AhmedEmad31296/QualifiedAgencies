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
        public async Task<ActionResult> Index(long? activityTypeId)
        {
            ViewData["ActivityTypeId"] = activityTypeId;
            await GetLookupSelectListItems();
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> GetPaged(long? activityTypeId)
        {
            int draw = Convert.ToInt32(HttpContext.Request.Form["draw"].FirstOrDefault());
            int start = Convert.ToInt32(HttpContext.Request.Form["start"].FirstOrDefault());
            int length = Convert.ToInt32(HttpContext.Request.Form["length"].FirstOrDefault());
            string sortColumn = HttpContext.Request.Form[$"columns[{HttpContext.Request.Form["order[0][column]"].FirstOrDefault()}][name]"].FirstOrDefault();
            string sortColumnDir = HttpContext.Request.Form["order[0][dir]"].FirstOrDefault();
            string searchTerm = HttpContext.Request.Form["search[value]"].FirstOrDefault();


            FilterEligibleEntityPagedInput input = new()
            {
                ActivityTypeId = activityTypeId,
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
            await GetLookupSelectListItems();
            var result = await _IEligibleEntityAppService.Get(id);
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

        private async Task GetLookupSelectListItems()
        {
            var activitySelectListItems = await _ILookupsAppService.GetActivities();
            var areaSelectListItems = await _ILookupsAppService.GetAreas();
            var categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

            var categorySelectListItems = categories.Select(c => new SelectListItem
            {
                Value = ((int)c).ToString(),
                Text = L("QualifiedAgencies." + c.ToString())
            }).ToList();

            ViewData["Categories"] = new SelectList(categorySelectListItems, "Value", "Text");
            ViewData["Activities"] = new SelectList(activitySelectListItems, "Id", "Name");
            ViewData["Areas"] = new SelectList(areaSelectListItems, "Id", "Name");
        }

    }
}
