using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace EFCore.Azure.Kusto
{
    public class KustoConnection : RelationalConnection
    {
        public KustoConnection(RelationalConnectionDependencies dependencies) : base(dependencies)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            return new KustoDbConnection();
        }
    }
}
