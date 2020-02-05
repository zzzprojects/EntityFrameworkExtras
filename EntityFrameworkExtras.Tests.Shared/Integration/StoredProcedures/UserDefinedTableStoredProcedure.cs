using System;
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
    public class UserDefinedTableStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<AllTypesUserDefinedTable> UserDefinedTableParameter { get; set; }
    }
}