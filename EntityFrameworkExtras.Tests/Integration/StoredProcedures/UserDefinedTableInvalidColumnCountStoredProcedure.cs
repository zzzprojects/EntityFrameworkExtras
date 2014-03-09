using System.Collections.Generic;
using System.Data;

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("UserDefinedTableStoredProcedure")]
    public class UserDefinedTableInvalidColumnCountStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<InvalidColumnCountUserDefinedTable> UserDefinedTableParameter { get; set; } 
    }
}