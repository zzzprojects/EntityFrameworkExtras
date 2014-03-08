using System.Data;

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("ParameterSizeStoredProcedure")]
    public class ParameterSizeStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.NVarChar)]
        public string ParameterSizeNotSet { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 5)]
        public string ParameterSizeSetTo5 { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 10)]
        public string ParameterSizeSetTo10 { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 20)]
        public string ParameterSizeSetTo20 { get; set; }

    }
}