using System.Data;
using System.Data.Common;

namespace EFCore.Azure.Kusto
{
    public class KustoDbCommand : DbCommand
    {
        public override string CommandText { get; set; }
        public override int CommandTimeout { get; set; }
        public override CommandType CommandType { get; set; }
        public override bool DesignTimeVisible { get; set; }
        public override UpdateRowSource UpdatedRowSource { get; set; }
        protected override DbConnection DbConnection { get; set; }
        protected override DbParameterCollection DbParameterCollection { get; } = new KustoDbParameterCollection();
        protected override DbTransaction DbTransaction { get; set; }

        public override void Cancel()
        {
            // Implement cancel logic
        }

        public override int ExecuteNonQuery()
        {
            // Implement execute non-query logic
            return 0;
        }

        public override object ExecuteScalar()
        {
            // Implement execute scalar logic
            return null;
        }

        public override void Prepare()
        {
            // Implement prepare logic
        }

        protected override DbParameter CreateDbParameter() => new KustoDbParameter();

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            // Implement execute reader logic
            return new KustoDbDataReader();
        }
    }
}
