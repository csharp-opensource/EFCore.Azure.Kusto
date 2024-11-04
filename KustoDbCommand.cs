using System.Collections;
using System.Collections.Generic;
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

    public class KustoDbParameterCollection : DbParameterCollection
    {
        private readonly List<DbParameter> _parameters = new List<DbParameter>();

        public override int Count => _parameters.Count;

        public override object SyncRoot => ((ICollection)_parameters).SyncRoot;

        public override int Add(object value)
        {
            _parameters.Add((DbParameter)value);
            return _parameters.Count - 1;
        }

        public override void AddRange(Array values)
        {
            foreach (var value in values)
            {
                _parameters.Add((DbParameter)value);
            }
        }

        public override void Clear()
        {
            _parameters.Clear();
        }

        public override bool Contains(object value)
        {
            return _parameters.Contains((DbParameter)value);
        }

        public override bool Contains(string value)
        {
            return _parameters.Exists(p => p.ParameterName == value);
        }

        public override void CopyTo(Array array, int index)
        {
            ((ICollection)_parameters).CopyTo(array, index);
        }

        public override IEnumerator GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public override int IndexOf(object value)
        {
            return _parameters.IndexOf((DbParameter)value);
        }

        public override int IndexOf(string parameterName)
        {
            return _parameters.FindIndex(p => p.ParameterName == parameterName);
        }

        public override void Insert(int index, object value)
        {
            _parameters.Insert(index, (DbParameter)value);
        }

        public override void Remove(object value)
        {
            _parameters.Remove((DbParameter)value);
        }

        public override void RemoveAt(int index)
        {
            _parameters.RemoveAt(index);
        }

        public override void RemoveAt(string parameterName)
        {
            var index = IndexOf(parameterName);
            if (index >= 0)
            {
                _parameters.RemoveAt(index);
            }
        }

        protected override DbParameter GetParameter(int index)
        {
            return _parameters[index];
        }

        protected override DbParameter GetParameter(string parameterName)
        {
            return _parameters.Find(p => p.ParameterName == parameterName);
        }

        protected override void SetParameter(int index, DbParameter value)
        {
            _parameters[index] = value;
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            var index = IndexOf(parameterName);
            if (index >= 0)
            {
                _parameters[index] = value;
            }
        }
    }

    public class KustoDbDataReader : DbDataReader
    {
        public override int Depth => 0;
        public override int FieldCount => 0;
        public override bool HasRows => false;
        public override bool IsClosed => false;
        public override int RecordsAffected => 0;
        public override object this[int ordinal] => null;
        public override object this[string name] => null;

        public override bool GetBoolean(int ordinal) => false;
        public override byte GetByte(int ordinal) => 0;
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => 0;
        public override char GetChar(int ordinal) => '\0';
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) => 0;
        public override string GetDataTypeName(int ordinal) => string.Empty;
        public override DateTime GetDateTime(int ordinal) => DateTime.MinValue;
        public override decimal GetDecimal(int ordinal) => 0;
        public override double GetDouble(int ordinal) => 0;
        public override IEnumerator GetEnumerator() => null;
        public override Type GetFieldType(int ordinal) => null;
        public override float GetFloat(int ordinal) => 0;
        public override Guid GetGuid(int ordinal) => Guid.Empty;
        public override short GetInt16(int ordinal) => 0;
        public override int GetInt32(int ordinal) => 0;
        public override long GetInt64(int ordinal) => 0;
        public override string GetName(int ordinal) => string.Empty;
        public override int GetOrdinal(string name) => 0;
        public override string GetString(int ordinal) => string.Empty;
        public override object GetValue(int ordinal) => null;
        public override int GetValues(object[] values) => 0;
        public override bool IsDBNull(int ordinal) => true;
        public override bool NextResult() => false;
        public override bool Read() => false;
    }
}
