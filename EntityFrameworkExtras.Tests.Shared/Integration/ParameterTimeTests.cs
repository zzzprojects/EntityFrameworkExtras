using System;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class ParameterTimeTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterTime = new TimeSpan(0, 11, 6, 10, 44);

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterTime = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterTime = new TimeSpan(0, 4, 13, 10, 44);

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(new TimeSpan(0, 4, 13, 10, 44), result.ParameterTime);
        }
      
    }
}