using System.Collections.ObjectModel;
using System.Data.SqlClient;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#endif
{
    internal class StoredProcedureInfo
    {       
        internal string Sql { get; set; }
        internal SqlParameter[] SqlParameters { get; set; }
    }

}
