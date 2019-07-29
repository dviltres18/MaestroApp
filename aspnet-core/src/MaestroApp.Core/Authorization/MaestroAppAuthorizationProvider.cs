using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MaestroApp.Authorization
{
    public class MaestroAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Viaje, L("Viajes"));
            context.CreatePermission(PermissionNames.Pages_Contenedor, L("Contenedores"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MaestroAppConsts.LocalizationSourceName);
        }
    }
}
