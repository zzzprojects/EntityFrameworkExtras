using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkExtras
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

            List<string> columns = GetColumns().ToList();

            AddColumns(columns, dt);
            AddRows(columns, dt);

            return dt;
        }

        private void AddColumns(IEnumerable<string> columns, DataTable dt)
        {
            foreach (string columnName in columns)
            {
                dt.Columns.Add(columnName);
            }
        }

        private void AddRows(List<string> columns, DataTable dt)
        {
            foreach (object o in (IEnumerable)_value)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);

                foreach (string column in columns)
                {
                    object value = _type.GetProperty(column).GetValue(o, null);
                    row.SetField(column, value);
                }
            }
        }

        private IEnumerable<string> GetColumns()
        {
            var columns = new Dictionary<int, string>();

            foreach (PropertyInfo propertyInfo in _type.GetProperties())
            {
                var attribute = Attributes.GetAttribute<UserDefinedTableTypeColumnAttribute>(propertyInfo);

                if (attribute != null)
                    columns.Add(attribute.Order, propertyInfo.Name);
            }

            var sortedColumns = columns.OrderBy(kvp => kvp.Key);

            return sortedColumns.Select(kvp => kvp.Value);
        }
    }
}