#if EF4 || EF5 || EF6
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

#if EF4
namespace EntityFrameworkExtras
#elif EF5
namespace EntityFrameworkExtras.EF5
#elif EF6
using System.Threading;
using System.Threading.Tasks;
namespace EntityFrameworkExtras.EF6
#endif
{
	public static partial class DatabaseExtensions
    {
	    /// <summary>
	    /// Executes the specified stored procedure against a database. 
	    /// </summary>
	    /// <param name="database">The database to execute against.</param>
	    /// <param name="storedProcedure">The stored procedure to execute.</param>
	    public static void ExecuteStoredProcedure(this Database database, object storedProcedure)
	    {
		    if (storedProcedure == null)
			    throw new ArgumentNullException("storedProcedure");

		    var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

		    database.ExecuteSqlCommand(info.Sql, info.SqlParameters);

		    SetOutputParameterValues(info.SqlParameters, storedProcedure);
		}

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
		public static async Task ExecuteStoredProcedureAsync(this Database database, object storedProcedure, CancellationToken cancellationToken = default)
	    {
		    if (storedProcedure == null)
			    throw new ArgumentNullException("storedProcedure");

		    var info = StoredProcedureParser.BuildStoredProcedureInfo(storedProcedure);

		    var task = await database.ExecuteSqlCommandAsync(info.Sql, cancellationToken, info.SqlParameters).ConfigureAwait(false);

		    SetOutputParameterValues(info.SqlParameters, storedProcedure);
	    }
		
		// <summary>
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

            var result = await database.SqlQuery<T>(info.Sql, info.SqlParameters).ToListAsync(cancellationToken).ConfigureAwait(false);

            SetOutputParameterValues(info.SqlParameters, storedProcedure);

            return result;
        }
#endif
    }
}
#endif