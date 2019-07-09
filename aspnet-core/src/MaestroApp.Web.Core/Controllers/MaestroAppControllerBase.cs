using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MaestroApp.Controllers
{
    public abstract class MaestroAppControllerBase: AbpController
    {
        protected MaestroAppControllerBase()
        {
            LocalizationSourceName = MaestroAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
