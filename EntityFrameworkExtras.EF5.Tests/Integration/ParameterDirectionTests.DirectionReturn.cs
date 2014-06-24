using EntityFrameworkExtras.EF5.Tests.Integration.StoredProcedures;
using NUnit.Framework;

namespace EntityFrameworkExtras.EF5.Tests.Integration
{
    [TestFixture]
    public partial class ParameterDirectionTests
    {
        
        //Need to fix code for ReturnValue to work (use Direction.Output for now)
        
//        [Test]
//        public void Execute_DirectionReturn_CorrectValueSet()
//        {
//            var procedure = new ParameterDirectionStoredProcedure();
//
//            procedure.ParameterDirectionReturnValue = "ParameterDirectionReturnValue";
//
//            var result = ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);
//
//            Assert.AreEqual("ParameterDirectionReturnValue", result.ParameterDirectionReturnValue);
//        }
//
//        [Test]
//        public void Execute_DirectionReturn_OutputParameterSet()
//        {
//            var procedure = new ParameterDirectionStoredProcedure();
//
//            procedure.ParameterDirectionReturnValue = "ParameterDirectionReturnValue";
//
//            ExecuteStoredProcedureSingle<ParameterDirectionStoredProcedureReturn>(procedure);
//
//            Assert.AreEqual("DirectionReturnValue", procedure.ParameterDirectionReturnValue);
//        }
    }
}