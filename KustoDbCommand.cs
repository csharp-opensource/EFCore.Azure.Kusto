using System.Data;
using System.Data.Common;
using Kusto.Data.Common;
using System.Linq;
using System;

namespace EFCore.Azure.Kusto
{
    public class KustoDbCommand : DbCommand
    {
        private readonly ICslQueryProvider _queryProvider;

        public KustoDbCommand(ICslQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

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
            // Cancel the command
            // Note: Kusto doesn't support canceling queries directly, so this might be a no-op
        }

        public override int ExecuteNonQuery()
        {
            var result = _queryProvider.ExecuteQuery(CommandText);
            if (result == null)
            {
                throw new InvalidOperationException("Query execution did not return a valid IDataReader.");
            }
            var table = new DataTable();
            table.Load(result);
            return table.Rows.Count;
        }

        public override object ExecuteScalar()
        {
            var result = _queryProvider.ExecuteQuery(CommandText);
            if (result == null)
            {
                throw new InvalidOperationException("Query execution did not return a valid IDataReader.");
            }
            var table = new DataTable();
            table.Load(result);
            var firstRow = table.Rows.Cast<DataRow>().FirstOrDefault();
            return firstRow != null ? firstRow[0] : null;
        }

        public override void Prepare()
        {
            // Prepare the command
        }

        protected override DbParameter CreateDbParameter() => new KustoDbParameter();

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            // Execute the command and return a data reader
            var result = _queryProvider.ExecuteQuery(CommandText);
            return new KustoDbDataReader(result);
        }
    }
}
