using Abp.Application.Services;

using QualifiedAgencies.Lookups.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifiedAgencies.Lookups
{
    public interface ILookupsAppService : IApplicationService
    {
        Task<List<CustomLookupsDto>> GetActivityTypes();
        Task<List<CustomLookupsDto>> GetActivities();
        Task<List<CustomLookupsDto>> GetAreas();
    }
}
