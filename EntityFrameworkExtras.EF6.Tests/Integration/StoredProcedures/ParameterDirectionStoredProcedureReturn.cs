using System;

namespace EntityFrameworkExtras.EF6.Tests.Integration.StoredProcedures
{
    public class ParameterDirectionStoredProcedureReturn
    {
        public String ParameterDirectionDefault { get; set; }

        public String ParameterDirectionInput { get; set; }

        public String ParameterDirectionInputOutput { get; set; }

        public String ParameterDirectionOutput { get; set; }

        public String ParameterDirectionReturnValue { get; set; }

    }
}