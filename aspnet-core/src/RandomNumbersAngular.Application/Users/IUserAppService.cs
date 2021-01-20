using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RandomNumbersAngular.Roles.Dto;
using RandomNumbersAngular.Users.Dto;

namespace RandomNumbersAngular.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
