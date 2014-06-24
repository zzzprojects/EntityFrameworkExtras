using System;
using EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF5.Tests.Integration
{
    [TestFixture]
    public class ParameterDateTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterDate = new DateTime(1983, 11, 10);

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDate = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDate = new DateTime(1983, 11, 10);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10), result.ParameterDate);
        }

        [Test]
        public void Parameter_Execute_NoTimeSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDate = new DateTime(1983, 11, 10, 16, 30, 15);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10, 0, 0, 0), result.ParameterDate);
        }
    }
}