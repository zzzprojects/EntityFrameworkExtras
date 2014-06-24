using System.Data.Entity;
using EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF6.Tests.Integration
{
    [TestFixture]
    public partial class ParameterSizeTests : DatabaseIntegrationTests
    {
        [Test]
        public void Execute_SizeNotSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoredProcedure();
            proc.ParameterSizeNotSet = "12345679";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("12345679", result.ParameterSizeNotSet);
        }

        [Test]
        public void Execute_CorrectSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoredProcedure();
            proc.ParameterSizeSetTo10 = "1234567891";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("1234567891", result.ParameterSizeSetTo10);
        }

        [Test]
        public void Execute_LesserSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoredProcedure();
            proc.ParameterSizeSetTo5 = "12345";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("12345", result.ParameterSizeSetTo5);
        }

        [Test]
        public void Execute_HigherSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoredProcedure();
            proc.ParameterSizeSetTo20 = "12345678911234567891";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoredProcedureReturn>(proc);

            Assert.AreEqual("1234567891", result.ParameterSizeSetTo20);
        }
        
    }


}