using System;
using System.Collections.Generic;
using System.Data;

namespace EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures
{
    [StoredProcedure("UserDefinedTableStoredProcedure")]
    public class UserDefinedTableStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<AllTypesUserDefinedTable> UserDefinedTableParameter { get; set; }
    }
}