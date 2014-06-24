using EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF6.Tests.Integration
{
    [TestFixture]
    public class ParameterNCharTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterNChar = "Michael";

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterNChar = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterNChar = "Michael";

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual("Michael   " /* NCHAR(10) */, result.ParameterNChar);
        }
    }
}