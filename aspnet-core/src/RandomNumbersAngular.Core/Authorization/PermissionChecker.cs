using Abp.Authorization;
using RandomNumbersAngular.Authorization.Roles;
using RandomNumbersAngular.Authorization.Users;

namespace RandomNumbersAngular.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
