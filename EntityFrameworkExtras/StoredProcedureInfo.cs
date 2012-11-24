using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace EntityFrameworkExtras
{
    internal class StoredProcedureInfo
    {
        internal StoredProcedureInfo() { }

        internal StoredProcedureInfo(string name)
        {
            Name = name;
        }

        internal string Name { get; set; }
        internal string Sql { get; set; }
        internal Collection<StoredProcedureParameterInfo> ParameterInfos { get; set; }
        internal SqlParameter[] SqlParameters { get; set; }
    }

}
