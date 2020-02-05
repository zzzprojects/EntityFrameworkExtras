using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class ParameterBitTests : DatabaseIntegrationTests
    {
        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterBit = true;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterBit = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterBit = true;
            
            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(true, result.ParameterBit);
        }
    }
}