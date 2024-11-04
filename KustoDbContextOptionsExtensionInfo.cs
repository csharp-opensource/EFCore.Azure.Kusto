using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace EFCore.Azure.Kusto
{
    public class KustoDbContextOptionsExtensionInfo : DbContextOptionsExtensionInfo
    {
        public KustoDbContextOptionsExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
        {
        }

        public override bool IsDatabaseProvider => true;

        public override string LogFragment => "using Kusto";

        public override int GetServiceProviderHashCode()
        {
            return 0; // Implement a proper hash code calculation if needed
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
            debugInfo["Kusto"] = "1";
        }

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
        {
            return other is KustoDbContextOptionsExtensionInfo;
        }
    }
}
