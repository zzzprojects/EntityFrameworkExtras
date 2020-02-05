using System;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#endif
{
    public class UserDefinedTableTypeColumnAttribute : Attribute
    {
        public UserDefinedTableTypeColumnAttribute(int order)
        {
            Order = order;
        }

        public UserDefinedTableTypeColumnAttribute(int order, string name)
        {
            Order = order;
            Name = name;
        }

        public int Order { get; set; }

        public string Name { get; set; }
    }
}