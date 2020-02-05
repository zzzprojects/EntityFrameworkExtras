using System;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#elif EFCORE
namespace EntityFrameworkExtras.EFCore
#endif
{
    public class UserDefinedTableTypeAttribute : Attribute
    {
        public UserDefinedTableTypeAttribute(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Cannot be null or empty.", "name");

            Name = name;
        }

        public string Name { get; set; }
    }
}