using System;

namespace EntityFrameworkExtras.EF6
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