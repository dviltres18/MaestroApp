using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MaestroApp.MultiTenancy.Dto;

namespace MaestroApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

