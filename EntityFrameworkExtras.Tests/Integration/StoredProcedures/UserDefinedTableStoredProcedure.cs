using System;
using System.Collections.Generic;
using System.Data;

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("UserDefinedTableStoredProcedure")]
    public class UserDefinedTableStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<AllTypesUDT> UserDefinedTableParameter { get; set; }
    }
}