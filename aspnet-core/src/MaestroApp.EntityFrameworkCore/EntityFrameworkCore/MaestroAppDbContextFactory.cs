using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MaestroApp.Configuration;
using MaestroApp.Web;

namespace MaestroApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MaestroAppDbContextFactory : IDesignTimeDbContextFactory<MaestroAppDbContext>
    {
        public MaestroAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MaestroAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MaestroAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MaestroAppConsts.ConnectionStringName));

            return new MaestroAppDbContext(builder.Options);
        }
    }
}
