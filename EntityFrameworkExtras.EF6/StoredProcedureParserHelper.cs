using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace EntityFrameworkExtras.EF6
{
    internal class StoredProcedureParserHelper
    {
        public string GetParameterName(PropertyInfo propertyInfo)
        {
            var rValue = propertyInfo.Name;

            // grab the name of the parameter from the attribute, if it's defined.
            var attribute = Attributes.GetAttribute<StoredProcedureParameterAttribute>(propertyInfo);
            if (attribute != null && !string.IsNullOrEmpty(attribute.ParameterName))
                rValue = attribute.ParameterName;

            return rValue;
        }

        public string GetUserDefinedTableType(PropertyInfo propertyInfo)
        {
            Type collectionType = GetCollectionType(propertyInfo.PropertyType);
            var attribute = Attributes.GetAttribute<UserDefinedTableTypeAttribute>(collectionType);

            if (attribute == null)
                throw new InvalidOperationException(
                    String.Format("{0} has not been decorated with UserDefinedTableTypeAttribute.",
                                  propertyInfo.PropertyType));

            return attribute.Name;
        }

        public Type GetCollectionType(Type type)
        {
            if (type.IsGenericType)
            {
                foreach (Type interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.GetGenericTypeDefinition() == typeof (IList<>))
                    {
                        return interfaceType.GetGenericArguments()[0];
                    }
                }
            }

            return null;
             
        }

        public object GetUserDefinedTableValue(PropertyInfo propertyInfo, object storedProcedure)
        {
            Type enumerableType = GetCollectionType(propertyInfo.PropertyType);
            object propertyValue = propertyInfo.GetValue(storedProcedure, null);

            var generator = new UserDefinedTableGenerator(enumerableType, propertyValue);

            DataTable table = generator.GenerateTable();

            return table;
        }

        public bool IsUserDefinedTableParameter(PropertyInfo propertyInfo)
        {
            Type collectionType = GetCollectionType(propertyInfo.PropertyType);

            return collectionType != null;
        }

        public bool ParameterIsMandatory(StoredProcedureParameterOptions options)
        {
            return (options & StoredProcedureParameterOptions.Mandatory) ==
                   StoredProcedureParameterOptions.Mandatory;
        }
    }
}