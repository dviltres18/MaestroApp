using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MaestroApp.Configuration.Dto;

namespace MaestroApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MaestroAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
