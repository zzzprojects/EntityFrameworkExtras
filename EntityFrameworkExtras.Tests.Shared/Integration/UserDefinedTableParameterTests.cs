using System;
using System.Collections.Generic;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public partial class UserDefinedTableParameterTests : DatabaseIntegrationTests
    {

        [Test]
        public void Execute_ParameterNvarChar_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterNvarChar = "England"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("England", result.ParameterNvarChar);
        }

        [Test]
        public void Execute_ParameterBigInt_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterBigInt = 555
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(555, result.ParameterBigInt);
        }


        [Test]
        public void Execute_ParameterBinary_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterBinary = GetBytes("Kourtney Wood")
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(GetBytes("Kourtney Wood"), result.ParameterBinary);
        }


        [Test]
        public void Execute_ParameterBit_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterBit = true
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(true, result.ParameterBit);
        }

        [Test]
        public void Execute_ParameterChar_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterChar = "Mike Rodda"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("Mike Rodda", result.ParameterChar);
        }

        [Test]
        public void Execute_ParameterDate_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDate = new DateTime(2014,03,08)
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(2014, 03, 08), result.ParameterDate);
        }

        [Test]
        public void Execute_ParameterDateTime_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDateTime = new DateTime(2014,03,08, 12, 15, 3)
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(2014, 03, 08, 12, 15, 3), result.ParameterDateTime);
        }

        [Test]
        public void Execute_ParameterDateTime2_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDateTime2 = new DateTime(2014,03,08, 12, 15, 3)
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(2014, 03, 08, 12, 15, 3), result.ParameterDateTime2);
        }

        [Test]
        public void Execute_ParameterDateTimeOffset_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDateTimeOffset = new DateTimeOffset(2014, 5, 2, 9, 4, 8, new TimeSpan(0, 13, 22 , 0))
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTimeOffset(2014, 5, 2, 9, 4, 8, new TimeSpan(0, 13, 22, 0)), result.ParameterDateTimeOffset);
        }

        [Test]
        public void Execute_ParameterDecimal_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterDecimal = 452m
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(452m, result.ParameterDecimal);
        }

        [Test]
        public void Execute_ParameterFloat_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterFloat = 87
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(87, result.ParameterFloat);
        }

        [Test]
        public void Execute_ParameterImage_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterImage = GetBytes("Test Image")
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(GetBytes("Test Image"), result.ParameterImage);
        }


        [Test]
        public void Execute_ParameterInt_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterInt = 45
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(45, result.ParameterInt);
        }


        [Test]
        public void Execute_ParameterMoney_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterMoney = 64.99m
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(64.99m, result.ParameterMoney);
        }

        [Test]
        public void Execute_ParameterNChar_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterNChar = "Michael"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("Michael   ", result.ParameterNChar);
        }

        [Test]
        public void Execute_ParameterNText_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterNText = "Michael Rodda"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("Michael Rodda", result.ParameterNText);
        }

        [Test]
        public void Execute_ParameterReal_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterReal = 45
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(45, result.ParameterReal);
        }

        [Test] 
        public void Execute_ParameterSmallDateTime_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterSmallDateTime = new DateTime(2014,03,08)
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(2014, 03, 08), result.ParameterSmallDateTime);
        }

        [Test]
        public void Execute_ParameterSmallInt_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterSmallInt = 45
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(45, result.ParameterSmallInt);
        }


        [Test]
        public void Execute_ParameterText_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterText = "James Bond"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("James Bond", result.ParameterText);
        }

        [Test]
        public void Execute_ParameterTime_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterTime = new TimeSpan(0, 2,88,2)
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(new TimeSpan(0, 2, 88, 2), result.ParameterTime);
        }

        [Test]
        public void Execute_ParameterTinyInt_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterTinyInt = 88
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(88, result.ParameterTinyInt);
        }

        [Test]
        public void Execute_ParameterUniqueIdentifier_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            var uniqueIdentifier = Guid.NewGuid();
            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterUniqueIdentifier = uniqueIdentifier
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(uniqueIdentifier, result.ParameterUniqueIdentifier);
        }

        
        [Test]
        public void Execute_ParameterVarBinary_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterVarBinary = GetBytes("James Bond")
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual(GetBytes("James Bond"), result.ParameterVarBinary);
        }

        [Test]
        public void Execute_ParameterVarChar_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterVarChar = "EntityFramework"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("EntityFramework", result.ParameterVarChar);
        }

        [Test]
        public void Execute_ParameterXml_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUserDefinedTable>()
            {
                new AllTypesUserDefinedTable()
                {
                    ParameterXml = "<EntityFramework />"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("<EntityFramework />", result.ParameterXml);
        }

    }
}