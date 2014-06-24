using System;
using System.Data;

namespace EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures
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