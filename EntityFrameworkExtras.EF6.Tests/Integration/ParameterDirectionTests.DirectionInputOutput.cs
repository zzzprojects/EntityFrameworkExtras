using EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF6.Tests.Integration
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

        [Test]
        public void Execute_DirectionInputOutputParameterSizeLessThenValueSet_ValueReturnedShouldBeTrimmed()
        {
            var procedure = new OutputParameterSizeSetStoredProcedure();

            // procedure.ParameterDirectionInputOutput - This parameters size is set to 10

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("DirectionI", procedure.ParameterDirectionInputOutput);
        }

        [Test]
        public void Execute_DirectionInputOutputParameterSizeNotSet_DefaultsToMaximumSize()
        {
            var procedure = new OutputParameterSizeNotSetStoredProcedure();

            // procedure.ParameterDirectionInputOutput - No size set

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("DirectionInputOutputValue", procedure.ParameterDirectionInputOutput);
        }
    }
}