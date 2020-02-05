using System;

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    public class AllTypesStoredProcedureReturn
    {
        public String ParameterNvarChar { get; set; }
        public Int64? ParameterBigInt { get; set; }
        public Byte[] ParameterBinary { get; set; }
        public Boolean? ParameterBit { get; set; }
        public String ParameterChar { get; set; }
        public DateTime? ParameterDate { get; set; }
        public DateTime? ParameterDateTime { get; set; }
        public DateTime? ParameterDateTime2 { get; set; }
        public DateTimeOffset? ParameterDateTimeOffset { get; set; }
        public Decimal? ParameterDecimal { get; set; }
        public Double? ParameterFloat { get; set; }
        public Byte[] ParameterImage { get; set; }
        public Int32? ParameterInt { get; set; }
        public Decimal? ParameterMoney { get; set; }
        public String ParameterNChar { get; set; }
        public String ParameterNText { get; set; }
        public Single? ParameterReal { get; set; }
        public DateTime? ParameterSmallDateTime { get; set; }
        public Int16? ParameterSmallInt { get; set; }
        public Decimal? ParameterSmallMoney { get; set; }
        public String ParameterText { get; set; }
        public TimeSpan? ParameterTime { get; set; }
        public Byte? ParameterTinyInt { get; set; }
        public Guid? ParameterUniqueIdentifier { get; set; }
        public Byte[] ParameterVarBinary { get; set; }
        public String ParameterVarChar { get; set; }
        public String ParameterXml { get; set; }
    }
}