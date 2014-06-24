using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF5.Tests.Integration
{
    [TestFixture]
    public partial class ParameterSizeTests
    {
        [Test]
        public void Execute_ParameterNvarcharNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("ParameterNvarcharValue", proc.ParameterNvarChar);
        }

        [Test]
        public void Execute_ParameterBigIntNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(111222333444, proc.ParameterBigInt);
        }

        [Test]
        public void Execute_ParameterBinaryNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            var expectedBinary = GetBytes("michael rodda");

            Assert.AreEqual(expectedBinary, proc.ParameterBinary);
        }

        [Test]
        public void Execute_ParameterBitNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);
            
            Assert.AreEqual(true, proc.ParameterBit);
        }

        [Test]
        public void Execute_ParameterCharNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("abcdefghij", proc.ParameterChar);
        }

        [Test]
        public void Execute_ParameterDateNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(2014, 6, 3), proc.ParameterDate);
        }

        [Test]
        public void Execute_ParameterDateTimeNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(1990, 12, 4, 6, 44, 4), proc.ParameterDateTime);
        }

        [Test]
        public void Execute_ParameterDateTime2NoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(1968, 10, 23, 12, 45, 37, 123), proc.ParameterDateTime2);
        }

        [Test]
        public void Execute_ParameterDateTimeOffsetNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTimeOffset(2007, 05, 08, 12, 35, 29, 123, new TimeSpan(0, 12, 15, 0)), proc.ParameterDateTimeOffset);
        }

        [Test]
        public void Execute_ParameterDecimalNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(555m, proc.ParameterDecimal);
        }

        [Test]
        public void Execute_ParameterFloatNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(897m, proc.ParameterFloat);
        }


        [Test]
        public void Execute_ParameterIntNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(25, proc.ParameterInt);
        }

        [Test]
        public void Execute_ParameterMoneyNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(1300, proc.ParameterMoney);
        }
        
        [Test]
        public void Execute_ParameterNCharNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("Cat", proc.ParameterNChar);
        }


        [Test]
        public void Execute_ParameterRealNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(6649, proc.ParameterReal);
        }

        [Test]
        public void Execute_ParameterSmallDateTimeNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new DateTime(1995, 03, 15, 12, 1, 0), proc.ParameterSmallDateTime);
        }


        [Test]
        public void Execute_ParameterSmallIntNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(9, proc.ParameterSmallInt);
        }

        [Test]
        public void Execute_ParameterSmallMoneyNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(200, proc.ParameterSmallMoney);
        }


        [Test]
        public void Execute_ParameterTimeNoSizeSet_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(new TimeSpan(0, 13, 3, 2), proc.ParameterTime);
        }

        [Test]
        public void Execute_ParameterTinyInt_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(12, proc.ParameterTinyInt);
        }


        [Test]
        public void Execute_ParameterUniqueIdentifier_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);
        
            Assert.AreEqual(new Guid("692623c2-a71e-453f-98c6-432c67835ba4"), proc.ParameterUniqueIdentifier);
        }

        
        [Test]
        public void Execute_ParameterVarBinary_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual(GetBytes("mike rodda"), proc.ParameterVarBinary);
        }



        [Test]
        public void Execute_ParameterVarChar_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("Once upon a time", proc.ParameterVarChar);
        }


        [Test]
        public void Execute_ParameterXml_CorrectValueReturned()
        {
            var proc = new AllTypesParameterOutputStoredProcedure();

            ExecuteStoredProcedure<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("<Some><Xml /></Some>", proc.ParameterXml);
        }
        



    }
}
