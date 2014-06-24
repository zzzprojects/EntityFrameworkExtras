using System;
using System.Data;

namespace EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures
{
    [StoredProcedure("ParameterDirectionStoredProcedure")]
    public class OutputParameterSizeSetStoredProcedure
    {

        [StoredProcedureParameter(SqlDbType.NVarChar, Direction = ParameterDirection.InputOutput, Size = 10)]
        public String ParameterDirectionInputOutput { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Direction = ParameterDirection.Output, Size = 10)]
        public String ParameterDirectionOutput { get; set; }
    }
}