using System;
using EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF6.Tests.Integration
{
    [TestFixture]
    public class ParameterDateTimeTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterDateTime = new DateTime(1983, 11, 10);

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDateTime = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDateTime = new DateTime(1983, 11, 10);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10), result.ParameterDateTime);
        }

        [Test]
        public void Parameter_Execute_TimeSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDateTime = new DateTime(1983, 11, 10, 16, 30, 15);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10, 16, 30, 15), result.ParameterDateTime);
        }
    }
}