using System.Data;
using System.Reflection;

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
    internal class StoredProcedureParameterInfo
    {
        internal ParameterDirection Direction { get; set; }
        internal string Name { get; set; }
        internal SqlDbType SqlDataType { get; set; }
        internal bool IsMandatory { get; set; }
        internal bool IsUserDefinedTable { get; set; }
        internal int Size { get; set; }
        internal byte Precision { get; set; }
        internal byte Scale { get; set; }
        internal PropertyInfo PropertyInfo { get; set; }
    }
}