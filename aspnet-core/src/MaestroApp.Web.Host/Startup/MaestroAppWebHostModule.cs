using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MaestroApp.Configuration;

namespace MaestroApp.Web.Host.Startup
{
    [DependsOn(
       typeof(MaestroAppWebCoreModule))]
    public class MaestroAppWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MaestroAppWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MaestroAppWebHostModule).GetAssembly());
        }
    }
}
