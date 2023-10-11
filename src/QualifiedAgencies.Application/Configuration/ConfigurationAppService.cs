using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using QualifiedAgencies.Configuration.Dto;

namespace QualifiedAgencies.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QualifiedAgenciesAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
