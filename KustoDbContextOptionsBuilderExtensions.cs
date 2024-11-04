using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Azure.Kusto
{
    public static class KustoDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseKusto(this DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            var extension = new KustoOptionsExtension();
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            optionsBuilder.UseInternalServiceProvider(new ServiceCollection()
                .AddEntityFrameworkKusto()
                .BuildServiceProvider());

            return optionsBuilder;
        }
    }
}
