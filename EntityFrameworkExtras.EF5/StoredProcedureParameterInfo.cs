using System.Data;
using System.Reflection;

namespace EntityFrameworkExtras.EF5
{
    internal class StoredProcedureParameterInfo
    {
        internal ParameterDirection Direction { get; set; }
        internal string Name { get; set; }
        internal SqlDbType SqlDataType { get; set; }
        internal bool IsMandatory { get; set; }
        internal bool IsUserDefinedTable { get; set; }
        internal int Size { get; set; }
        internal PropertyInfo PropertyInfo { get; set; }
    }
}