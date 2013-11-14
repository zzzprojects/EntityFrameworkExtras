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

        public StoredProcedureParameterAttribute(SqlDbType dataType, int size)
        {
            DataType = dataType;
            Direction = ParameterDirection.Input;
            Size = size;
        }

        public StoredProcedureParameterAttribute(SqlDbType dataType, StoredProcedureParameterOptions options, int size)
        {
            DataType = dataType;
            Options = options;
            Direction = ParameterDirection.Input;
            Size = size;
        }

        public SqlDbType DataType { get; set; }

        public StoredProcedureParameterOptions Options { get; set; }

        /// <summary>
        /// Specifies the Max Size for the SqlParameter, which is required for execution when this error occurs: "String[1]: the Size property has an invalid size of 0."
        /// More Info: http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparameter.size(v=vs.110).aspx
        /// For varchar(max), use -1: http://stackoverflow.com/questions/973260/what-size-do-you-use-for-varcharmax-in-your-parameter-declaration
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Specifies the name of the Procedure parameter, if different than the property name. 
        /// </summary>
        public string ParameterName { get; set; }

        public ParameterDirection Direction { get; set; }
    }
}