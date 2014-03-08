using System;
using System.Collections.Generic;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class UserDefinedParameterTests : DatabaseIntegrationTests
    {

        [Test]
        public void Execute_ParameterNvarChar_ReturnCorrectValue()
        {
            var proc = new UserDefinedTableStoredProcedure();

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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
            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
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

            proc.UserDefinedTableParameter = new List<AllTypesUDT>()
            {
                new AllTypesUDT()
                {
                    ParameterXml = "<EntityFramework />"
                }
            };

            var result = ExecuteStoredProcedureSingle<UserDefinedTableStoredProcedureReturn>(proc);

            Assert.AreEqual("<EntityFramework />", result.ParameterXml);
        }


        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}