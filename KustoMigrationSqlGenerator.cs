using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Azure.Kusto
{
    public class KustoMigrationSqlGenerator : MigrationsSqlGenerator
    {
        public KustoMigrationSqlGenerator(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }

        protected override void Generate(CreateTableOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            // Implement SQL generation logic for creating a table
            builder.Append("CREATE TABLE ")
                   .Append(operation.Name)
                   .AppendLine(" (");

            // Add columns
            foreach (var column in operation.Columns)
            {
                builder.Append(column.Name)
                       .Append(" ")
                       .Append(column.ColumnType)
                       .AppendLine(",");
            }

            builder.AppendLine(");");
        }

        // Implement other SQL generation methods as needed
        protected override void Generate(DropTableOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            builder.Append("DROP TABLE ")
                   .Append(operation.Name)
                   .AppendLine(";");
        }

        protected override void Generate(RenameTableOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            builder.Append("RENAME TABLE ")
                   .Append(operation.Name)
                   .Append(" TO ")
                   .Append(operation.NewName)
                   .AppendLine(";");
        }
    }
}
