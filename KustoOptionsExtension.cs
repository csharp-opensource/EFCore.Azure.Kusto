using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Azure.Kusto
{
    public class KustoOptionsExtension : IDbContextOptionsExtension
    {
        private DbContextOptionsExtensionInfo _info;

        public DbContextOptionsExtensionInfo Info => _info ??= new KustoDbContextOptionsExtensionInfo(this);

        public void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkKusto();
        }

        public void Validate(IDbContextOptions options)
        {
            // Add validation logic if needed
        }
    }

    public static class KustoServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkKusto(this IServiceCollection services)
        {
            // Register Kusto services
            services.AddSingleton<IQueryTranslationPreprocessorFactory, KustoQueryTranslator>();
            services.AddSingleton<IMigrationsSqlGenerator, KustoMigrationSqlGenerator>();
            services.AddSingleton<IRelationalConnection, KustoConnection>();
            return services;
        }
    }
}
