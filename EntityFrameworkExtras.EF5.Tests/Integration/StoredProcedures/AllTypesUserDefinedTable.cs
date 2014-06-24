using System;
using System.Data;

namespace EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures
{
    [UserDefinedTableType("AllTypesUDT")]
    public class AllTypesUserDefinedTable
    {
   
        [UserDefinedTableTypeColumn(1)]
        public String ParameterNvarChar { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public Int64? ParameterBigInt { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public Byte[] ParameterBinary { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public Boolean? ParameterBit { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public String ParameterChar { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? ParameterDate { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public DateTime? ParameterDateTime { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public DateTime? ParameterDateTime2 { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public DateTimeOffset? ParameterDateTimeOffset { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public Decimal? ParameterDecimal { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public Double? ParameterFloat { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public Byte[] ParameterImage { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public Int32? ParameterInt { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public Decimal? ParameterMoney { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public String ParameterNChar { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public String ParameterNText { get; set; }

        [UserDefinedTableTypeColumn(17)]
        public Single? ParameterReal { get; set; }

        [UserDefinedTableTypeColumn(18)]
        public DateTime? ParameterSmallDateTime { get; set; }

        [UserDefinedTableTypeColumn(19)]
        public Int16? ParameterSmallInt { get; set; }

        [UserDefinedTableTypeColumn(20)]
        public Decimal? ParameterSmallMoney { get; set; }

        [UserDefinedTableTypeColumn(21)]
        public String ParameterText { get; set; }

        [UserDefinedTableTypeColumn(22)]
        public TimeSpan? ParameterTime { get; set; }
        
        [UserDefinedTableTypeColumn(23)]
        public Byte? ParameterTinyInt { get; set; }

        [UserDefinedTableTypeColumn(24)]
        public Guid? ParameterUniqueIdentifier { get; set; }

        [UserDefinedTableTypeColumn(25)]
        public Byte[] ParameterVarBinary { get; set; }

        [UserDefinedTableTypeColumn(26)]
        public String ParameterVarChar { get; set; }

        [UserDefinedTableTypeColumn(27)]
        public String ParameterXml { get; set; }
    }


}