using System.Reflection;

namespace EntityFrameworkExtras.EF7
{
    internal class ColumnInformation
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public PropertyInfo Property { get; set; }
    }
}