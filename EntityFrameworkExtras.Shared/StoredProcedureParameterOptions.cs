using System;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#endif
{
    [Flags]
    public enum StoredProcedureParameterOptions
    {
        Mandatory = 1
    }
}