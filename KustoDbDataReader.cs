using System.Collections;
using System.Data.Common;
using Microsoft.Azure.Kusto.Data.Common;

namespace EFCore.Azure.Kusto
{
    public class KustoDbDataReader : DbDataReader
    {
        private readonly IDataReader _dataReader;

        public KustoDbDataReader(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public override int Depth => 0;
        public override int FieldCount => _dataReader.FieldCount;
        public override bool HasRows => _dataReader.HasRows;
        public override bool IsClosed => _dataReader.IsClosed;
        public override int RecordsAffected => _dataReader.RecordsAffected;
        public override object this[int ordinal] => _dataReader.GetValue(ordinal);
        public override object this[string name] => _dataReader.GetValue(_dataReader.GetOrdinal(name));

        public override bool GetBoolean(int ordinal) => _dataReader.GetBoolean(ordinal);
        public override byte GetByte(int ordinal) => _dataReader.GetByte(ordinal);
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => _dataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        public override char GetChar(int ordinal) => _dataReader.GetChar(ordinal);
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) => _dataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        public override string GetDataTypeName(int ordinal) => _dataReader.GetDataTypeName(ordinal);
        public override DateTime GetDateTime(int ordinal) => _dataReader.GetDateTime(ordinal);
        public override decimal GetDecimal(int ordinal) => _dataReader.GetDecimal(ordinal);
        public override double GetDouble(int ordinal) => _dataReader.GetDouble(ordinal);
        public override IEnumerator GetEnumerator() => _dataReader.GetEnumerator();
        public override Type GetFieldType(int ordinal) => _dataReader.GetFieldType(ordinal);
        public override float GetFloat(int ordinal) => _dataReader.GetFloat(ordinal);
        public override Guid GetGuid(int ordinal) => _dataReader.GetGuid(ordinal);
        public override short GetInt16(int ordinal) => _dataReader.GetInt16(ordinal);
        public override int GetInt32(int ordinal) => _dataReader.GetInt32(ordinal);
        public override long GetInt64(int ordinal) => _dataReader.GetInt64(ordinal);
        public override string GetName(int ordinal) => _dataReader.GetName(ordinal);
        public override int GetOrdinal(string name) => _dataReader.GetOrdinal(name);
        public override string GetString(int ordinal) => _dataReader.GetString(ordinal);
        public override object GetValue(int ordinal) => _dataReader.GetValue(ordinal);
        public override int GetValues(object[] values) => _dataReader.GetValues(values);
        public override bool IsDBNull(int ordinal) => _dataReader.IsDBNull(ordinal);
        public override bool NextResult() => _dataReader.NextResult();
        public override bool Read() => _dataReader.Read();
    }
}
