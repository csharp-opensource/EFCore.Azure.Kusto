
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Azure.Kusto
{
    public class KustoOptionsExtension : IDbContextOptionsExtension
    {
        public DbContextOptionsExtensionInfo Info { get; }

        public void ApplyServices(IServiceCollection services)
        {
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }
}
