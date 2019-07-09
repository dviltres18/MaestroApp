using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaestroApp.EntityFrameworkCore
{
  
    public static class MaestroAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MaestroAppDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MaestroAppDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
