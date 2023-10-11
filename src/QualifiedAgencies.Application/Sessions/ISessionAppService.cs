using System.Threading.Tasks;
using Abp.Application.Services;
using QualifiedAgencies.Sessions.Dto;

namespace QualifiedAgencies.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
