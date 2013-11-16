using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace EntityFrameworkExtras
{
    internal class StoredProcedureInfo
    {       
        internal string Sql { get; set; }
        internal SqlParameter[] SqlParameters { get; set; }
    }

}
