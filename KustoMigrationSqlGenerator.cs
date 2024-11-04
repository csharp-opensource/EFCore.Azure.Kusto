
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Azure.Kusto
{
    public class KustoMigrationSqlGenerator : MigrationsSqlGenerator
    {
        public KustoMigrationSqlGenerator(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }
    }
}
