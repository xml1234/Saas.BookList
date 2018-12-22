using Abp.Authorization;
using Yoyosoft.BookList.Authorization.Roles;
using Yoyosoft.BookList.Authorization.Users;

namespace Yoyosoft.BookList.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
