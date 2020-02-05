using System;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class ParameteUniqueIdentifierTests : DatabaseIntegrationTests
    {

        [Test]
        public void Parameter_Execute_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();

            procedure.ParameterUniqueIdentifier​​ = new Guid();

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_ExecuteAsNull_NoErrors()
        {
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterUniqueIdentifier = null;

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void Parameter_Execute_CorrectValueSet()
        {
            Guid guid = Guid.NewGuid();
            var procedure = new AllTypesStoredProcedure();
            procedure.ParameterUniqueIdentifier = guid;

            var result = ExecuteStoredProcedureSingle<AllTypesStoredProcedureReturn>(procedure);

            Assert.AreEqual(guid, result.ParameterUniqueIdentifier);
        }
    }
}