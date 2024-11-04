using System;
using System.Data;
using System.Data.Common;

namespace EFCore.Azure.Kusto
{
    public class KustoDbConnection : DbConnection
    {
        public override string ConnectionString { get; set; }

        public override string Database => "KustoDatabase"; // Replace with actual database name

        public override string DataSource => "KustoDataSource"; // Replace with actual data source

        public override string ServerVersion => "1.0"; // Replace with actual server version

        public override ConnectionState State { get; protected set; } = ConnectionState.Closed;

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            // Implement close logic
            State = ConnectionState.Closed;
        }

        public override void Open()
        {
            // Implement open logic
            State = ConnectionState.Open;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            return new KustoDbCommand();
        }
    }
}
