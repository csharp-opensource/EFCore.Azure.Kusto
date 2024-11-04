
using Microsoft.EntityFrameworkCore.Query;

namespace EFCore.Azure.Kusto
{
    public class KustoQueryTranslator : IQueryTranslationPreprocessorFactory
    {
        public QueryTranslationPreprocessor Create(QueryCompilationContext queryCompilationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
