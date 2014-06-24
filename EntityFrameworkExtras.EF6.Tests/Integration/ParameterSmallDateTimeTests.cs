using System;
using EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF6.Tests.Integration
{
    [TestFixture]
    public class ParameterSmallDateTimeTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterSmallDateTime = new DateTime(1983, 11, 10);

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterSmallDateTime = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterSmallDateTime = new DateTime(1983, 11, 10);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10), result.ParameterSmallDateTime);
        }

   
        [Test]
        public void Parameter_Execute_MinutesRoundedDown()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterSmallDateTime = new DateTime(1983, 11, 10, 16, 35, 29);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10, 16, 35 /* rounded as seconds passed < 30 */, 0), result.ParameterSmallDateTime);
        }

        [Test]
        public void Parameter_Execute_MinutesRoundedUp()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterSmallDateTime = new DateTime(1983, 11, 10, 16, 35, 30);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new DateTime(1983, 11, 10, 16, 36 /* rounded up as seconds passed => 30 */, 0), result.ParameterSmallDateTime);
        }
    }
}