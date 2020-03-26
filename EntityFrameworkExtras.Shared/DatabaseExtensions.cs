using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
#if EF4 || EF5 || EF6
using System.Data.Entity;
using System.Data.SqlClient;
#elif EFCORE_2X
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
#elif EFCORE
using System.Threading;
using System.Threading.Tasks;
using System.Data.Common; 
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
#endif


#if NET45 
using System.Threading.Tasks;
using System.Threading;
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
    public static partial class DatabaseExtensions
    {
        /// <summary>
        /// Executes the specified stored procedure against a database. 
        /// </summary>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
#if EFCORE && !EFCORE_2X
        public static void ExecuteStoredProcedure(this DatabaseFacade database, object storedProcedure)
         {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            database.ExecuteSqlRawAsync(info.Sql, info.SqlParameters);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);
        }
#else
#if EFCORE_2X
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
#endif

#if EFCORE && !EFCORE_2X
        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns an enumerable of T representing the data returned.
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task ExecuteStoredProcedureAsync(this DatabaseFacade database, object storedProcedure, CancellationToken cancellationToken = default)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            var listParam = info.SqlParameters != null && info.SqlParameters.Length > 0
	            ? info.SqlParameters.ToList()
	            : null;

            var task = await database.ExecuteSqlRawAsync(info.Sql, listParam, cancellationToken).ConfigureAwait(false);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);
        }
#endif

#if NET45
        /// <summary>
        /// Executes the specified stored procedure against a database
        /// and returns an enumerable of T representing the data returned.
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task ExecuteStoredProcedureAsync(this Database database, object storedProcedure, CancellationToken cancellationToken  = default)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");

            var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            var task = await database.ExecuteSqlCommandAsync(info.Sql, cancellationToken, info.SqlParameters).ConfigureAwait(false);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);
        }
#endif

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
#if !EFCORE_2X
     
        /// <summary>
        /// Executes the specified stored procedure against a database asyncrounously
        /// and returns an enumerable of T representing the data returned.
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(this DatabaseFacade database, object storedProcedure, CancellationToken cancellationToken = default)
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

		        using (var resultReader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false))
		        {
			        T obj = default(T);

			        while (await resultReader.ReadAsync(cancellationToken).ConfigureAwait(false))
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
#endif

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

        /// <summary>
        /// Executes the specified stored procedure against a database asynchronously
        /// and returns the first or default value
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<T> ExecuteStoredProcedureFirstOrDefaultAsync<T>(this Database database, object storedProcedure, CancellationToken cancellationToken = default)
        {
            var executed = await database.ExecuteStoredProcedureAsync<T>(storedProcedure, cancellationToken).ConfigureAwait(false);

            return executed.FirstOrDefault();
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

#if NET45

        /// <summary>
        /// Executes the specified stored procedure against a database asyncrhousnouly
        /// and returns the first or default value
        /// </summary>
        /// <typeparam name="T">Type of the data returned from the stored procedure.</typeparam>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(this Database database, object storedProcedure, CancellationToken cancellationToken = default)
        {
            if (storedProcedure == null)
                throw new ArgumentNullException("storedProcedure");
          var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

            // TODO: need resolution for info.SqlParameters when a paramater have direction output.
            var result = await database.SqlQuery<T>(info.Sql, info.SqlParameters).ToListAsync(cancellationToken).ConfigureAwait(false);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);

            return result;
        }
#endif

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