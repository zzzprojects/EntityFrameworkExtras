using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkExtras.EF5
{
    public class UserDefinedTableGenerator
    {
        private readonly Type _type;
        private readonly object _value;

        public UserDefinedTableGenerator(Type type, object value)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (value == null)
                throw new ArgumentNullException("value");

            _type = type;
            _value = value;
        }

        
        public DataTable GenerateTable()
        {
            var dt = new DataTable();

            List<ColumnInformation> columns = GetColumnInformation();

            AddColumns(columns, dt);
            AddRows(columns, dt);

            return dt;
        }

        internal void AddColumns(List<ColumnInformation> columns, DataTable dt)
        {
            foreach (ColumnInformation column in columns)
            {
                Type type = column.Property.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    type = type.GetGenericArguments()[0];
                }
                
                dt.Columns.Add(column.Name, type);
            }
        }

        internal void AddRows(List<ColumnInformation> columns, DataTable dt)
        {
            foreach (object o in (IEnumerable)_value)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                foreach (ColumnInformation column in columns)
                {
                    object value = column.Property.GetValue(o, null);
                    row.SetField(column.Name, value);
                }
            }
        }

        private List<ColumnInformation> GetColumnInformation()
        {
            var columns = new List<ColumnInformation>();

            foreach (PropertyInfo propertyInfo in _type.GetProperties())
            {
                var attribute = Attributes.GetAttribute<UserDefinedTableTypeColumnAttribute>(propertyInfo);

                if (attribute != null)
                {
                    var column = new ColumnInformation();
                    column.Name = attribute.Name ?? propertyInfo.Name;
                    column.Property = propertyInfo;
                    column.Order = attribute.Order;

                    columns.Add(column);
                }
            }

            return columns.OrderBy(info => info.Order).ToList();

        }
    }
}