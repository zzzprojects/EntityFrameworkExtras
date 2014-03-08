using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public partial class ParameterDirectionTests
    {
        
        [Test]
        public void Execute_DirectionInputOutput_CorrectValueSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionInputOutput = "ParameterDirectionInputOutput";

            var result = ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("ParameterDirectionInputOutput", result.ParameterDirectionInputOutput);
        }

        [Test]
        public void Execute_DirectionInputOutput_OutputParameterSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionInputOutput = "ParameterDirectionInput";

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("DirectionInputOutputValue", procedure.ParameterDirectionInputOutput);
        }
    }
}