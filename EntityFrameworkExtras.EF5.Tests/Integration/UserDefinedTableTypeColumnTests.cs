using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF5.Tests.Integration
{
    [TestFixture]
    public partial class UserDefinedTableParameterTests
    {
        public void Execute_CorrectColumnOrder_NoErrors()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDecimal = 555m /* ParameterDecimal - Column 10 */
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(555m, result.ParameterBigInt);
        }

        [Test]
        public void Execute_InvalidUdtColumnCount_CorrectError()
        {
            try
            {
                var proc = new UserDefinedTableInvalidColumnCountStoredProcedure();

                proc.UserDefinedTableParameter = new List<InvalidColumnCountUserDefinedTable>()
                {
                    new InvalidColumnCountUserDefinedTable()
                    {
                        ParameterBigInt = 100,
                        ParameterBit = true,
                        ParameterNvarChar = "Invalid Column Count"
                    }
                };

                ExecuteStoredProcedure(proc);
            }
            catch (SqlException exception)
            {
                Assert.AreEqual("Trying to pass a table-valued parameter with 4 column(s) where the corresponding user-defined table type requires 27 column(s).",
                    exception.Message);
            }
        }

        [Test]
        public void Execute_ExplicitySetColumnName_CorrectValueReturned()
        {
            var proc = new UserDefinedTableExplicitlySetColumnNameStoredProcedure();

            proc.UserDefinedTableParameter = new List<ExplicitySetColumnNamesUserDefinedTable>()
                {
                    new ExplicitySetColumnNamesUserDefinedTable()
                    {
                        NvarChar = "Theses Columns Names were Explicity Set",
                        BigInt = 1000,
                        Binary = GetBytes("michael rodda")
                    }
                };

           var result =  ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(proc);

            Assert.AreEqual("Theses Columns Names were Explicity Set", result.ParameterNvarChar);
            Assert.AreEqual(1000, result.ParameterBigInt);
            Assert.AreEqual(GetBytes("michael rodda"), result.ParameterBinary);

        }
    }
}