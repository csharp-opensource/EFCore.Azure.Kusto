using Microsoft.EntityFrameworkCore.Query;

namespace EFCore.Azure.Kusto
{
    public class KustoQueryTranslator : IQueryTranslationPreprocessorFactory
    {
        private readonly QueryTranslationPreprocessorDependencies _dependencies;

        public KustoQueryTranslator(QueryTranslationPreprocessorDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public QueryTranslationPreprocessor Create(QueryCompilationContext queryCompilationContext)
        {
            return new KustoQueryTranslationPreprocessor(_dependencies, queryCompilationContext);
        }
    }
}
