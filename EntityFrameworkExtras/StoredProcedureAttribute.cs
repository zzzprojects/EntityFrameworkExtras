using System;

namespace EntityFrameworkExtras
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class StoredProcedureAttribute : Attribute
	{
		public StoredProcedureAttribute(string name)
		{
			if (String.IsNullOrEmpty(name))
				throw new ArgumentException("Cannot be null or empty.", "name");

			Name = name;
		}

		public string Name { get; set; }
	}
}
