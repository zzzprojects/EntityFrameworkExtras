using System;
using System.Data;

namespace EntityFrameworkExtras
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StoredProcedureParameterAttribute : Attribute
    {
        public StoredProcedureParameterAttribute(SqlDbType dataType)
        {
            DataType = dataType;
            Direction = ParameterDirection.Input;
        }

        public StoredProcedureParameterAttribute(SqlDbType dataType, StoredProcedureParameterOptions options)
        {
            DataType = dataType;
            Options = options;
            Direction = ParameterDirection.Input;
        }

        public SqlDbType DataType { get; set; }

        public StoredProcedureParameterOptions Options { get; set; }

        public ParameterDirection Direction { get; set; }
    }
}