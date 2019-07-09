using System.Threading.Tasks;
using Abp.Application.Services;
using MaestroApp.Authorization.Accounts.Dto;

namespace MaestroApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
