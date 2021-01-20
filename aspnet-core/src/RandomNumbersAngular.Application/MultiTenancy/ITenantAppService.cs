using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RandomNumbersAngular.MultiTenancy.Dto;

namespace RandomNumbersAngular.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

