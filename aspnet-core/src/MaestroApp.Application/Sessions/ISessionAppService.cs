using System.Threading.Tasks;
using Abp.Application.Services;
using MaestroApp.Sessions.Dto;

namespace MaestroApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
