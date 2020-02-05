using System.Collections.Generic;
using System.Data;

#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#elif EFCORE
using EntityFrameworkExtras.EFCore;
#endif

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("UserDefinedTableStoredProcedure")]
    public class UserDefinedTableExplicitlySetColumnNameStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<ExplicitySetColumnNamesUserDefinedTable> UserDefinedTableParameter { get; set; }
    }
}