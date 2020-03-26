#if EF4 || EF5 || EF6

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#endif
{
    public static partial class DatabaseExtensions
    {
    }
}
#endif