using System;
using System.Data;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#elif EFCORE
namespace EntityFrameworkExtras.EFCore
#endif
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
        /// Size of the parameter, typically used for output parameters. If an output parameter has a size of 0 then its default to -1 (equivalent to MAX)
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Specifies the name of the Procedure parameter, if different than the property name. 
        /// </summary>
        public string ParameterName { get; set; }

        public ParameterDirection Direction { get; set; } 

        // NEED TEXT!
        public byte Precision { get; set; } 

        // NEED TEXT!
        public byte Scale { get; set; }
    }
}