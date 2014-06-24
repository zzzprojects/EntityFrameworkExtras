using System.Data.SqlClient;

namespace EntityFrameworkExtras.EF5
{
    internal class StoredProcedureInfo
    {       
        internal string Sql { get; set; }
        internal SqlParameter[] SqlParameters { get; set; }
    }

}
