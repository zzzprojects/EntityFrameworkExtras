using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkExtras.EF6
{
    public static class ObjectContextExtentions
    {
        /// <summary>
        /// Executes the specified stored procedure against a database.
        /// </summary>
        /// <param name="context">The ObjectContext to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        public static void ExecuteStoredProcedure(this ObjectContext context, object storedProcedure)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            context.ExecuteStoreCommand(info.Sql, info.SqlParameters);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);
        }

        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns an enumerable of T representing the data returned.
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="context">The ObjectContext to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <returns></returns>
        public static IEnumerable<T> ExecuteStoredProcedure<T>(this ObjectContext context, object storedProcedure)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            List<T> result = context.ExecuteStoreQuery<T>(info.Sql, info.SqlParameters).ToList();

            SetOutputParameterValues(info.SqlParameters, storedProcedure);

            return result;
        }


        private static PropertyInfo GetMatchingProperty(object storedProcedure, SqlParameter parameter)
        {
            foreach (PropertyInfo propertyInfo in storedProcedure.GetType().GetProperties().Where(p => p.HasAttribute<StoredProcedureParameterAttribute>()))
            {
                var helper = new StoredProcedureParserHelper();

                var name = helper.GetParameterName(propertyInfo);

                if (parameter.ParameterName.Substring(1) == name)
                    return propertyInfo;
            }

            return null;
        }

        private static void SetOutputParameterValues(IEnumerable<SqlParameter> sqlParameters, object storedProcedure)
        {
            foreach (SqlParameter sqlParameter in sqlParameters.Where(p => p.Direction != ParameterDirection.Input))
            {
                PropertyInfo propertyInfo = GetMatchingProperty(storedProcedure, sqlParameter);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(storedProcedure,
                        (sqlParameter.Value == DBNull.Value) ?
                        GetDefault(propertyInfo.PropertyType) :
                        sqlParameter.Value, null);
                }
            }
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}