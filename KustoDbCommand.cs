﻿using System.Data;
using System.Data.Common;
using Kusto.Data.Common;

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
        }

        public override int ExecuteNonQuery()
        {
            var result = _queryProvider.ExecuteControlCommand(CommandText);
            return result.Status == "Success" ? 1 : 0;
        }

        public override object ExecuteScalar()
        {
            var result = _queryProvider.ExecuteQuery(CommandText);
            return result.PrimaryResults.FirstOrDefault()?.Rows.FirstOrDefault()?.Values.FirstOrDefault();
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
