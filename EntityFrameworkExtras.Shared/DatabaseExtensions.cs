using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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