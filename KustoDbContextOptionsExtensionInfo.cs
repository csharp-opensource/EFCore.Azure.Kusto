using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace EFCore.Azure.Kusto
{
    public class KustoDbContextOptionsExtensionInfo : DbContextOptionsExtensionInfo
    {
        public KustoDbContextOptionsExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
        {
        }

        public override bool IsDatabaseProvider { get; }

        public override string LogFragment { get; }

        public override int GetServiceProviderHashCode()
        {

        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {

        }

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
        {

        }
    }
}
