using Microsoft.EntityFrameworkCore.Infrastructure;
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
}
