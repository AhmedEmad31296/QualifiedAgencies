using Abp.Application.Services;
using Abp.Application.Services.Dto;

using QualifiedAgencies.Entities.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static QualifiedAgencies.Helpers.Datatable;

namespace QualifiedAgencies.Entities
{
    public interface IEligibleEntityAppService : IApplicationService
    {
        Task<DatatableFilterdDto<EligibleEntityPagedDto>> GetPaged(FilterEligibleEntityPagedInput input);
        Task<string> Insert(InsertEligibleEntityInput input);
        Task<string> Update(UpdateEligibleEntityInput input);
        Task<GetFullInfoEligibleEntityDto> Get(long id);
        Task<string> Delete(long id);
        Task<GetStatisticsDto> GetStatistics();
    }
}
