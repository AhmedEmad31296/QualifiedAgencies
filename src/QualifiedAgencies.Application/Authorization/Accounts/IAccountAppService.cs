using System.Threading.Tasks;
using Abp.Application.Services;
using QualifiedAgencies.Authorization.Accounts.Dto;

namespace QualifiedAgencies.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
