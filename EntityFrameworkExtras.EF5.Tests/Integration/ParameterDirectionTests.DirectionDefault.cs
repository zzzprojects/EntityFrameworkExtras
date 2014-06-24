using EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF5.Tests.Integration
{
    [TestFixture]
    public partial class ParameterDirectionTests : DatabaseIntegrationTests
    {

        [Test]
        public void Execute_DirectionDefault_CorrectValueSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionDefault = "ParameterDirectionDefault";

            var result = ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("ParameterDirectionDefault", result.ParameterDirectionDefault);
        }

        [Test]
        public void Execute_DirectionDefault_NoOutputParameterSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionDefault = "ParameterDirectionDefault";

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("ParameterDirectionDefault", procedure.ParameterDirectionDefault);
        }
    
    }

}