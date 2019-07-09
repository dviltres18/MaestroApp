using System.Threading.Tasks;
using MaestroApp.Configuration.Dto;

namespace MaestroApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
