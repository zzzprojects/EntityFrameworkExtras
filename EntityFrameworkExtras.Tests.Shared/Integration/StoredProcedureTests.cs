using System;
using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public class StoredProcedureTests : DatabaseIntegrationTests
    {
        [Test]
        public void ExecuteStoredProcedure_NoParameters_NoErrors()
        {
            var procedure = new NoParametersStoredProcedure();

            Assert.DoesNotThrow(() => ExecuteStoredProcedure(procedure));
        }

        [Test]
        public void ExecuteStoredProcedure_NoneExistingProcedure_CorrectException()
        {
            var procedure = new NoneExistingStoredProcedure();

            Assert.Throws<System.Data.SqlClient.SqlException>(() => ExecuteStoredProcedure(procedure), "Could not find stored procedure 'NoneExistingStoredProcedure'.");
        }

        [Test]
        public void ExecuteStoredProcedure_NoneExistingProcedure_CorrectExceptionMessage()
        {
            try
            {
                var procedure = new NoneExistingStoredProcedure();

                ExecuteStoredProcedure(procedure);
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                Assert.AreEqual("Could not find stored procedure 'NoneExistingStoredProcedure'.", exception.Message);
            }
        }


        [Test]
        public void ExecuteStoredProcedure_WithNull_CorrectException()
        {
            Assert.Throws<ArgumentNullException>(() => ExecuteStoredProcedure(null), "storedProceduree");
        }

        [Test]
        public void ExecuteStoredProcedure_WithNull_CorrectExceptionMessage()
        {
            try
            {
                ExecuteStoredProcedure(null);
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("Value cannot be null.\r\nParameter name: storedProcedure", exception.Message);
            }
        }

    }
}