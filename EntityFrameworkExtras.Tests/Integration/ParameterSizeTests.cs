using System.Data;
using System.Data.Entity;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class ParameterSizeTests : DatabaseIntegrationTests
    {
        [Test]
        public void Execute_SizeNotSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoreProcedure();
            proc.ParameterSizeNotSet = "12345679";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoreProcedureReturn>(proc);

            Assert.AreEqual("12345679", result.ParameterSizeNotSet);
        }

        [Test]
        public void Execute_CorrectSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoreProcedure();
            proc.ParameterSizeSetTo10 = "1234567891";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoreProcedureReturn>(proc);

            Assert.AreEqual("1234567891", result.ParameterSizeSetTo10);
        }

        [Test]
        public void Execute_LesserSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoreProcedure();
            proc.ParameterSizeSetTo5 = "12345";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoreProcedureReturn>(proc);

            Assert.AreEqual("12345", result.ParameterSizeSetTo5);
        }

        [Test]
        public void Execute_HigherSizeSet_CorrectValueReturned()
        {
            var proc = new ParameterSizeStoreProcedure();
            proc.ParameterSizeSetTo20 = "12345678911234567891";

            var result = ExecuteStoredProcedureSingle<ParameterSizeStoreProcedureReturn>(proc);

            Assert.AreEqual("1234567891", result.ParameterSizeSetTo20);
        }
        
    }

    [StoredProcedure("ParameterSizeStoreProcedure")]
    public class ParameterSizeStoreProcedure
    {
        [StoredProcedureParameter(SqlDbType.NVarChar)]
        public string ParameterSizeNotSet { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 5)]
        public string ParameterSizeSetTo5 { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 10)]
        public string ParameterSizeSetTo10 { get; set; }

        [StoredProcedureParameter(SqlDbType.NVarChar, Size = 20)]
        public string ParameterSizeSetTo20 { get; set; }

    }

    public class ParameterSizeStoreProcedureReturn
    {
        public string ParameterSizeNotSet { get; set; }
        public string ParameterSizeSetTo5 { get; set; }
        public string ParameterSizeSetTo10 { get; set; }
        public string ParameterSizeSetTo20 { get; set; }
    }
}