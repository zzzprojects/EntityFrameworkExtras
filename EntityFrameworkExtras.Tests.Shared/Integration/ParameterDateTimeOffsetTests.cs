using System;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class ParameterDateTimeOffsetTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterDateTimeOffset = new DateTime(1983, 11, 10);

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDateTimeOffset = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterDateTimeOffset = new DateTimeOffset(1983, 11, 11, 13, 45, 59, new TimeSpan(0, 2, 10, 0));

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTimeOffset(1983, 11, 11, 13, 45, 59, new TimeSpan(0, 2, 10, 0)), result.ParameterDateTimeOffset);
        }

    }
}