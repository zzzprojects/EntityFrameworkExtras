using System;

namespace EntityFrameworkExtras.EF6
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