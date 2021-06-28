using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public static class DapperExtensions
    {
        public static Task<int> InsertAsync<T>(this IDbConnection connection, T entityToInsert, bool enumAsString = false, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
        {
            return enumAsString ? InsertWithEnumAsStringAsync(connection, entityToInsert) : SqlMapperExtensions.InsertAsync(connection, entityToInsert, transaction, commandTimeout, sqlAdapter);
        }

        private static Task<int> InsertWithEnumAsStringAsync<T>(this IDbConnection connection, T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var propertyValuesMap = new Dictionary<string, object>();

            var columns = new StringBuilder();
            var values = new StringBuilder();
            var tableName = ((TableAttribute)entityToInsert.GetType().GetCustomAttribute(typeof(TableAttribute)))?.Name;
            var relevantProperties = entityToInsert.GetType().GetProperties().Where(x =>
                !Attribute.IsDefined(x, typeof(ComputedAttribute)) && HasNoWriteFalseAttribute(x)).ToList();

            for (var i = 0; i < relevantProperties.Count; i++)
            {
                object val;
                var propertyInfo = relevantProperties[i];

                if (propertyInfo.PropertyType.IsEnum)
                {
                    var isStringEnum =
                        propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false).FirstOrDefault() is ColumnAttribute
                            columnAttribute
                        && columnAttribute.TypeName.Contains("varchar");

                    val = isStringEnum
                        ? Enum.GetName(propertyInfo.PropertyType, propertyInfo.GetValue(entityToInsert) ?? "VALUE")
                        : propertyInfo.GetValue(entityToInsert);
                }
                else
                {
                    val = propertyInfo.GetValue(entityToInsert);
                }

                propertyValuesMap.Add(propertyInfo.Name, val);
                var propName = i == relevantProperties.Count - 1 ? $"{propertyInfo.Name}" : $"{propertyInfo.Name},";
                columns.Append(propName);
                values.Append($"@{propName}");
            }

            return connection.ExecuteAsync($"Insert Into {tableName} ({columns}) values ({values})", propertyValuesMap, transaction, commandTimeout);
        }

        private static bool HasNoWriteFalseAttribute(ICustomAttributeProvider propertyInfo)
        {
            var writeAttribute = propertyInfo.GetCustomAttributes(typeof(WriteAttribute), false).FirstOrDefault() as WriteAttribute;
            return writeAttribute == null || writeAttribute.Write;
        }
    }
}
