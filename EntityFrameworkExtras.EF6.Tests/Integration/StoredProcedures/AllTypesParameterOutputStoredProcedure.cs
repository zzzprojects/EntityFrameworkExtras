using System;
using System.Data;

namespace EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures
{
    [StoredProcedure("AllTypesParameterOutputStoredProcedure")]
    public class AllTypesParameterOutputStoredProcedure
    {
        [StoredProcedureParameter(SqlDbType.NVarChar, Direction = ParameterDirection.Output)]
        public String ParameterNvarChar { get; set; }

        [StoredProcedureParameter(SqlDbType.BigInt, Direction = ParameterDirection.Output)]
        public Int64? ParameterBigInt { get; set; }

        [StoredProcedureParameter(SqlDbType.Binary, Direction = ParameterDirection.Output)]
        public Byte[] ParameterBinary { get; set; }

        [StoredProcedureParameter(SqlDbType.Bit, Direction = ParameterDirection.Output)]
        public Boolean? ParameterBit { get; set; }

        [StoredProcedureParameter(SqlDbType.Char, Direction = ParameterDirection.Output)]
        public String ParameterChar { get; set; }

        [StoredProcedureParameter(SqlDbType.Date, Direction = ParameterDirection.Output)]
        public DateTime? ParameterDate { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTime, Direction = ParameterDirection.Output)]
        public DateTime? ParameterDateTime { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTime2, Direction = ParameterDirection.Output)]
        public DateTime? ParameterDateTime2 { get; set; }

        [StoredProcedureParameter(SqlDbType.DateTimeOffset, Direction = ParameterDirection.Output)]
        public DateTimeOffset? ParameterDateTimeOffset { get; set; }

        [StoredProcedureParameter(SqlDbType.Decimal, Direction = ParameterDirection.Output)]
        public Decimal? ParameterDecimal { get; set; }

        [StoredProcedureParameter(SqlDbType.Float, Direction = ParameterDirection.Output)]
        public Double? ParameterFloat { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
        public Int32? ParameterInt { get; set; }

        [StoredProcedureParameter(SqlDbType.Decimal, Direction = ParameterDirection.Output)]
        public Decimal? ParameterMoney { get; set; }

        [StoredProcedureParameter(SqlDbType.NChar, Direction = ParameterDirection.Output)]
        public String ParameterNChar { get; set; }
        
        [StoredProcedureParameter(SqlDbType.Real, Direction = ParameterDirection.Output)]
        public Single? ParameterReal { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallDateTime, Direction = ParameterDirection.Output)]
        public DateTime? ParameterSmallDateTime { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallInt, Direction = ParameterDirection.Output)]
        public Int16? ParameterSmallInt { get; set; }

        [StoredProcedureParameter(SqlDbType.SmallMoney, Direction = ParameterDirection.Output)]
        public Decimal? ParameterSmallMoney { get; set; }
        
        [StoredProcedureParameter(SqlDbType.Time, Direction = ParameterDirection.Output)]
        public TimeSpan? ParameterTime { get; set; }

        [StoredProcedureParameter(SqlDbType.TinyInt, Direction = ParameterDirection.Output)]
        public Byte? ParameterTinyInt { get; set; }

        [StoredProcedureParameter(SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Output)]
        public Guid? ParameterUniqueIdentifier { get; set; }

        [StoredProcedureParameter(SqlDbType.VarBinary, Direction = ParameterDirection.Output)]
        public Byte[] ParameterVarBinary { get; set; }

        [StoredProcedureParameter(SqlDbType.VarChar, Direction = ParameterDirection.Output)]
        public String ParameterVarChar { get; set; }

        [StoredProcedureParameter(SqlDbType.Xml, Direction = ParameterDirection.Output)]
        public String ParameterXml { get; set; }
    }
}