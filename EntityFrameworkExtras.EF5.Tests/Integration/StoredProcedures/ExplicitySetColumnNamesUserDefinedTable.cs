using System;
using System.Data;

namespace EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures
{
    [UserDefinedTableType("AllTypesUDT")]
    public class ExplicitySetColumnNamesUserDefinedTable
    {

        [UserDefinedTableTypeColumn(1, Name = "ParameterNvarChar")]
        public String NvarChar { get; set; }

        [UserDefinedTableTypeColumn(2, Name = "ParameterBigInt")]
        public Int64? BigInt { get; set; }

        [UserDefinedTableTypeColumn(3, Name = "ParameterBinary")]
        public Byte[] Binary { get; set; }

        [UserDefinedTableTypeColumn(4, Name = "ParameterBit")]
        public Boolean? Bit { get; set; }

        [UserDefinedTableTypeColumn(5, Name = "ParameterChar")]
        public String Char { get; set; }

        [UserDefinedTableTypeColumn(6, Name = "ParameterDate")]
        public DateTime? Date { get; set; }

        [UserDefinedTableTypeColumn(7, Name = "ParameterDateTime")]
        public DateTime? DateTime { get; set; }

        [UserDefinedTableTypeColumn(8, Name = "ParameterDateTime2")]
        public DateTime? DateTime2 { get; set; }

        [UserDefinedTableTypeColumn(9, Name = "ParameterDateTimeOffset")]
        public DateTimeOffset? DateTimeOffset { get; set; }

        [UserDefinedTableTypeColumn(10, Name = "ParameterDecimal")]
        public Decimal? Decimal { get; set; }

        [UserDefinedTableTypeColumn(11, Name = "ParameterFloat")]
        public Double? Float { get; set; }

        [UserDefinedTableTypeColumn(12, Name = "ParameterImage")]
        public Byte[] Image { get; set; }

        [UserDefinedTableTypeColumn(13, Name = "ParameterInt")]
        public Int32? Int { get; set; }

        [UserDefinedTableTypeColumn(14, Name = "ParameterMoney")]
        public Decimal? Money { get; set; }

        [UserDefinedTableTypeColumn(15, Name = "ParameterNChar")]
        public String NChar { get; set; }

        [UserDefinedTableTypeColumn(16, Name = "ParameterNText")]
        public String NText { get; set; }

        [UserDefinedTableTypeColumn(17, Name = "ParameterReal")]
        public Single? Real { get; set; }

        [UserDefinedTableTypeColumn(18, Name = "ParameterSmallDateTime")]
        public DateTime? SmallDateTime { get; set; }

        [UserDefinedTableTypeColumn(19, Name = "ParameterSmallInt")]
        public Int16? SmallInt { get; set; }

        [UserDefinedTableTypeColumn(20, Name = "ParameterSmallMoney")]
        public Decimal? SmallMoney { get; set; }

        [UserDefinedTableTypeColumn(21, Name = "ParameterText")]
        public String Text { get; set; }

        [UserDefinedTableTypeColumn(22, Name = "ParameterTime")]
        public TimeSpan? Time { get; set; }

        [UserDefinedTableTypeColumn(23, Name = "ParameterTinyInt")]
        public Byte? TinyInt { get; set; }

        [UserDefinedTableTypeColumn(24, Name = "ParameterUniqueIdentifier")]
        public Guid? UniqueIdentifier { get; set; }

        [UserDefinedTableTypeColumn(25, Name = "ParameterVarBinary")]
        public Byte[] VarBinary { get; set; }

        [UserDefinedTableTypeColumn(26, Name = "ParameterVarChar")]
        public String VarChar { get; set; }

        [UserDefinedTableTypeColumn(27, Name = "ParameterXml")]
        public String Xml { get; set; }
    }


}