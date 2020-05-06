#if EFCORE_2X
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkExtras.EFCore
{
    public static partial class DatabaseExtensions
    {
        /// <summary>
        /// Executes the specified stored procedure against a database. 
        /// </summary>
        /// <param name="database">The database to execute against.</param>
        /// <param name="storedProcedure">The stored procedure to execute.</param>
        public static void ExecuteStoredProcedure(this DatabaseFacade database, object storedProcedure)
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
				int? commandTimeout = database.GetCommandTimeout();
                if (commandTimeout.HasValue)
                {
                    command.CommandTimeout = commandTimeout.Value;
                }
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
    }
}

#endif