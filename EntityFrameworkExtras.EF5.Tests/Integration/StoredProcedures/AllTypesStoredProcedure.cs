using System;
using System.Data;
using EntityFrameworkExtras.EF5;

namespace EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures
{
    [StoredProcedure("AllTypesStoredProcedure")]
    public class AllTypesStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.NVarChar)]
        public String ParameterNvarChar { get; set; }

        [StoredProcedureParameter(SqlDbType.BigInt)]
        public Int64? ParameterBigInt { get; set; }

        [StoredProcedureParameter(SqlDbType.Binary)]
        public Byte[] ParameterBinary { get; set; }

        [StoredProcedureParameter(SqlDbType.Bit)]
        public Boolean? ParameterBit { get; set; }

        [StoredProcedureParameter(SqlDbType.Char)]
        public String ParameterChar { get; set; }

        [StoredProcedureParameter(SqlDbType.Date)]
        public DateTime? ParameterDate { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTime)]
        public DateTime? ParameterDateTime { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTime2)]
        public DateTime? ParameterDateTime2 { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTimeOffset)]
        public DateTimeOffset? ParameterDateTimeOffset { get; set; }

        [StoredProcedureParameter(SqlDbType.Decimal)]
        public Decimal? ParameterDecimal { get; set; }

        [StoredProcedureParameter(SqlDbType.Float)]
        public Double? ParameterFloat { get; set; }

        [StoredProcedureParameter(SqlDbType.Image)]
        public Byte[] ParameterImage { get; set; }

        [StoredProcedureParameter(SqlDbType.Int)]
        public Int32? ParameterInt { get; set; }

        [StoredProcedureParameter(SqlDbType.Decimal)]
        public Decimal? ParameterMoney { get; set; }

        [StoredProcedureParameter(SqlDbType.NChar)]
        public String ParameterNChar { get; set; }

        [StoredProcedureParameter(SqlDbType.NText)]
        public String ParameterNText { get; set; }

        [StoredProcedureParameter(SqlDbType.Real)]
        public Single? ParameterReal { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallDateTime)]
        public DateTime? ParameterSmallDateTime { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallInt)]
        public Int16? ParameterSmallInt { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallMoney)]
        public Decimal? ParameterSmallMoney { get; set; }

        [StoredProcedureParameter(SqlDbType.Text)]
        public String ParameterText { get; set; }

        [StoredProcedureParameter(SqlDbType.Time)]
        public TimeSpan? ParameterTime { get; set; }

        [StoredProcedureParameter(SqlDbType.TinyInt)]
        public Byte? ParameterTinyInt { get; set; }

        [StoredProcedureParameter(SqlDbType.UniqueIdentifier)]
        public Guid? ParameterUniqueIdentifier { get; set; }

        [StoredProcedureParameter(SqlDbType.VarBinary)]
        public Byte[] ParameterVarBinary { get; set; }

        [StoredProcedureParameter(SqlDbType.VarChar)]
        public String ParameterVarChar { get; set; }

        [StoredProcedureParameter(SqlDbType.Xml)]
        public String ParameterXml { get; set; }
    }
}