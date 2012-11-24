using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkExtras
{
    internal class StoredProcedureParser
    {
        private static readonly StoredProcedureParserHelper _helper = new StoredProcedureParserHelper();
        
        public static StoredProcedureInfo BuildStoredProcedureInfo(object storedProcedure)
        {
            var storedProcedureName = GetStoreProcedureName(storedProcedure);

            var parameterInfo = BuildStoredProcedureParameterInfo(storedProcedure);

            string sql = BuildSql(storedProcedureName, parameterInfo);

            var info = new StoredProcedureInfo(storedProcedureName)
                {
                    Sql = sql,
                    ParameterInfos = parameterInfo,
                };

            info.SqlParameters = BuildSqlParameters(storedProcedure, info);

            return info;
            
        }

        public static string GetStoreProcedureName(object storedProcedure)
        {
            var attribute = Attributes.GetAttribute<StoredProcedureAttribute>(storedProcedure.GetType());

            if (attribute == null)
                throw new InvalidOperationException(String.Format(
                    "{0} is not decorated with StoredProcedureAttribute.", storedProcedure.GetType()));

            return attribute.Name;
        }

        public static Collection<StoredProcedureParameterInfo> BuildStoredProcedureParameterInfo(object storedProcedure)
        {
            var parameters = new Collection<StoredProcedureParameterInfo>();

            foreach (PropertyInfo propertyInfo in storedProcedure.GetType().GetProperties())
            {
                var attribute = Attributes.GetAttribute<StoredProcedureParameterAttribute>(propertyInfo);

                if (attribute != null)
                {
                    var parameterName = _helper.GetParameterName(propertyInfo);

                    var isUserDefinedTableParameter = _helper.IsUserDefinedTableParameter(propertyInfo);
                    var isMandatory = _helper.ParameterIsMandatory(attribute.Options);

                    parameters.Add(new StoredProcedureParameterInfo
                        {
                            Name = parameterName,
                            IsUserDefinedTable = isUserDefinedTableParameter,
                            IsMandatory = isMandatory,
                            SqlDataType = attribute.DataType,
                            PropertyInfo = propertyInfo,
                            Direction = attribute.Direction                           
                        });
                }
            }

            return parameters;
        }

        private static string BuildSql(string storedProcedureName, IEnumerable<StoredProcedureParameterInfo> parameterInfos)
        {
            var execSql = String.Format("EXEC {0} ", storedProcedureName);
            var parameterSql = String.Join(",", parameterInfos.Select(pi => String.Format("@{0} = @{0} {1}", pi.Name, pi.Direction == ParameterDirection.Input ? String.Empty : "out")));

            return execSql + parameterSql;
        }

        private static SqlParameter[] BuildSqlParameters(object storedProcedure, StoredProcedureInfo info)
        {
            var sqlParams = new List<SqlParameter>();

            foreach (var p in info.ParameterInfos)
            {
                var propertyValue = p.PropertyInfo.GetValue(storedProcedure, null);

                var value = p.IsUserDefinedTable
                                         ? _helper.GetUserDefinedTableValue(p.PropertyInfo, storedProcedure)
                                         : propertyValue;

                SqlParameter sqlParameter = GenerateSqlParameter(p.Name,
                                                                 value,
                                                                 p.IsMandatory,
                                                                 p.IsUserDefinedTable,
                                                                 p.IsUserDefinedTable ?
                                                                                    _helper.GetUserDefinedTableType(p.PropertyInfo) : null,
                                                                p.SqlDataType,
                                                                p.Direction);

                sqlParams.Add(sqlParameter);
            }

            return sqlParams.ToArray();
        }

        private static SqlParameter GenerateSqlParameter(string parameterName, object paramValue, bool mandatory,
                                           bool isUserDefinedTableParameter, string udtType, SqlDbType dataType, ParameterDirection direction)
        {
            var sqlParameter = new SqlParameter("@" + parameterName, paramValue ?? DBNull.Value)
            {
                Direction = direction,
                IsNullable = !mandatory
            };

            if (isUserDefinedTableParameter)
                sqlParameter.TypeName = udtType;
            else
                sqlParameter.SqlDbType = dataType;

            return sqlParameter;
        }



    }
}