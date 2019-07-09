using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MaestroApp.Roles.Dto;
using MaestroApp.Users.Dto;

namespace MaestroApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
