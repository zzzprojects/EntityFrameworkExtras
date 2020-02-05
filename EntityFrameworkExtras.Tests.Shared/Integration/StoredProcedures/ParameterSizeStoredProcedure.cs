using System.Data;

#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#endif

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    /// <summary>
    /// All parameters in the stored procedure are set to 10 e.g. ParameterSizeNotSet NVARCHAR(10)
    /// </summary>
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