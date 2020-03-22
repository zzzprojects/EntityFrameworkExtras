using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

#if EF4 || EF5 || EF6
using System.Data.Entity;
using System.Data.SqlClient;
#elif EFCORE_2X
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
#elif EFCORE
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
#endif

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
namespace EntityFrameworkExtras.EF6
#elif EFCORE
namespace EntityFrameworkExtras.EFCore
#endif
{
    /// <summary>
    /// Extension methods for the Entity Framework Database class.
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Executes the specified stored procedure against a database. 
        /// </summary>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
#if EFCORE
        public static void ExecuteStoredProcedure(this DatabaseFacade database, object storedProcedure)
#else
        public static void ExecuteStoredProcedure(this Database database, object storedProcedure)
#endif
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            database.ExecuteSqlCommand(info.Sql, info.SqlParameters);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);
        }

        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns an enumerable of T representing the data returned.
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <returns></returns>
#if EFCORE
        public static IEnumerable<T> ExecuteStoredProcedure<T>(this DatabaseFacade database, object storedProcedure)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");


            List<T> result = new List<T>();
            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);


            // from : https://github.com/Fodsuk/EntityFrameworkExtras/pull/23/commits/dce354304aa9a95750f7d2559d1b002444ac46f7
            using (var command = database.GetDbConnection().CreateCommand())
            {
	            command.CommandText = info.Sql;
	            command.CommandType = CommandType.Text;
	            command.Parameters.AddRange(info.SqlParameters);
				command.Transaction = database.CurrentTransaction?.GetDbTransaction();
	            database.OpenConnection();

	            using (var resultReader = command.ExecuteReader())
	            {
		            T obj = default(T);

		            while (resultReader.Read())
		            {
			            obj = Activator.CreateInstance<T>();
			            foreach (PropertyInfo prop in obj.GetType().GetProperties())
			            {
				            var val = GetValue(resultReader, prop.Name);
				            if (!object.Equals(val, DBNull.Value))
				            {
					            prop.SetValue(obj, val, null);
				            }
			            }

			            result.Add(obj);
		            }
	            }

            } 

            SetOutputParameterValues(info.SqlParameters, storedProcedure);

            return result;
        }

        // from : https://github.com/Fodsuk/EntityFrameworkExtras/pull/23/commits/dce354304aa9a95750f7d2559d1b002444ac46f7
        private static object GetValue(this DbDataReader reader, string name)
        {
	        object val = DBNull.Value;

	        try
	        {
		        val = reader[name];
	        }
	        catch (Exception) { }
	        return val;
        }

        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns the first or default value
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <returns></returns>
        public static T ExecuteStoredProcedureFirstOrDefault<T>(this DatabaseFacade database, object storedProcedure)
        {
            return database.ExecuteStoredProcedure<T>(storedProcedure).FirstOrDefault();
        }
#else
        public static IEnumerable<T> ExecuteStoredProcedure<T>(this Database database, object storedProcedure)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            // TODO: need resolution for info.SqlParameters when a paramater have direction output.
            List<T> result = database.SqlQuery<T>(info.Sql, info.SqlParameters).ToList();

            SetOutputParameterValues(info.SqlParameters, storedProcedure);

            return result;
        }

        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns the first or default value
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <returns></returns>
        public static T ExecuteStoredProcedureFirstOrDefault<T>(this Database database, object storedProcedure)
        {
            return database.ExecuteStoredProcedure<T>(storedProcedure).FirstOrDefault();
        }
#endif  

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