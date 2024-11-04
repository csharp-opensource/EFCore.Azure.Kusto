using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Azure.Kusto
{
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
