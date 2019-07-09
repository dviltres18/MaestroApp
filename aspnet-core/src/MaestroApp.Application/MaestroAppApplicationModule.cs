using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MaestroApp.Authorization;

namespace MaestroApp
{
    [DependsOn(
        typeof(MaestroAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MaestroAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MaestroAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MaestroAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
