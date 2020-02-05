#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#endif

namespace EntityFrameworkExtras.Tests.Integration.StoredProcedures
{
    [StoredProcedure("NoneExistingStoredProcedure")]
    public class NoneExistingStoredProcedure { }
}