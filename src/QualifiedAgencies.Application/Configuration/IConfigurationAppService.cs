using System.Threading.Tasks;
using QualifiedAgencies.Configuration.Dto;

namespace QualifiedAgencies.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
