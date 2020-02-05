using System;
using System.Data;

#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#endif

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("ParameterDirectionStoredProcedure")]
    public class OutputParameterSizeNotSetStoredProcedure
    {

        [StoredProcedureParameter(SqlDbType.NVarChar, Direction = ParameterDirection.InputOutput)]
        public String ParameterDirectionInputOutput { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Direction = ParameterDirection.Output)]
        public String ParameterDirectionOutput { get; set; }
    }
}