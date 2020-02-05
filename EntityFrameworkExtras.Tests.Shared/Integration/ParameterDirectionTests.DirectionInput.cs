using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public partial class ParameterDirectionTests
    {
        
        [Test]
        public void Execute_DirectionInput_CorrectValueSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionInput = "ParameterDirectionInput";

            var result = ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("ParameterDirectionInput", result.ParameterDirectionInput);
        }

        [Test]
        public void Execute_DirectionInput_NoOutputParameterSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionInput = "ParameterDirectionInput";

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("ParameterDirectionInput", procedure.ParameterDirectionInput);
        }

    }
}