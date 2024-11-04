using System;
using System.Data;
using System.Data.Common;
using Kusto.Data;
using Kusto.Data.Common;
using Kusto.Data.Net.Client;

namespace EFCore.Azure.Kusto
{
    public class KustoDbConnection : DbConnection
    {
        private KustoConnectionStringBuilder _connectionStringBuilder;
        private ICslQueryProvider _queryProvider;

        public override string ConnectionString
        {
            get => _connectionStringBuilder?.ToString();
            set => _connectionStringBuilder = new KustoConnectionStringBuilder(value);
        }

        public override string Database => _connectionStringBuilder.InitialCatalog;

        public override string DataSource => _connectionStringBuilder.DataSource;

        public override string ServerVersion => "1.0"; // Replace with actual server version

        private ConnectionState _state;
        public override ConnectionState State => _state;

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            // Close the connection
            _queryProvider.Dispose();
            _state = ConnectionState.Closed;
        }

        public override void Open()
        {
            // Open the connection
            _queryProvider = KustoClientFactory.CreateCslQueryProvider(_connectionStringBuilder);
            _state = ConnectionState.Open;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            return new KustoDbCommand(_queryProvider);
        }
    }
}
