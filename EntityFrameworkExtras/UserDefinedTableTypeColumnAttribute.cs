using System;

namespace EntityFrameworkExtras
{
    public class UserDefinedTableTypeColumnAttribute : Attribute
    {
        public UserDefinedTableTypeColumnAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; set; }
    }
}