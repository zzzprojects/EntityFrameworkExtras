using System.Collections.Generic;
using System.Data;

#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#endif

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("UserDefinedTableStoredProcedure")]
    public class UserDefinedTableInvalidColumnCountStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<InvalidColumnCountUserDefinedTable> UserDefinedTableParameter { get; set; } 
    }
}