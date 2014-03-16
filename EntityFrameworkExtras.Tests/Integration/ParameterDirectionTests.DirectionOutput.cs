using EntityFrameworkExtras.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    [TestFixture]
    public partial class ParameterDirectionTests
    {
        
        [Test]
        public void Execute_DirectionOutput_NoValueSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionOutput = "ParameterDirectionOutput";

            var result = ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual(null, result.ParameterDirectionOutput);
        }

        [Test]
        public void Execute_DirectionOutput_OutputParameterSet()
        {
            var procedure = new ParameterDirectionStoredProcedure();

            procedure.ParameterDirectionOutput = "ParameterDirectionOutput";

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("DirectionOutputValue", procedure.ParameterDirectionOutput);
        }

        [Test]
        public void Execute_DirectionOutputParameterSizeLessThenValueSet_ValueReturnedShouldBeTrimmed()
        {
            var procedure = new OutputParameterSizeStoredProcedure();

            // procedure.ParameterDirectionOutput This parameters size is set to 10

            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);

            Assert.AreEqual("DirectionO", procedure.ParameterDirectionOutput);
        }
    }
}