using System.Collections.ObjectModel;

#if EF4 || EF5 || EF6
using System.Data.SqlClient;
#elif EFCORE
using Microsoft.Data.SqlClient;
#endif

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
    internal class StoredProcedureInfo
    {       
        internal string Sql { get; set; }
        internal SqlParameter[] SqlParameters { get; set; }
    }

}
