using Abp.Application.Services;
using QualifiedAgencies.MultiTenancy.Dto;

namespace QualifiedAgencies.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

