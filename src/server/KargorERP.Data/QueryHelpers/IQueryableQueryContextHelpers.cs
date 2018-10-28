using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace KargorERP.Data.QueryHelpers
{
    public static class IQueryableQueryContextHelpers
    {
        public static IQueryable<T> WithQueryContext<T>(this IQueryable<T> query, QueryContext queryContext)
        {
            return query.WithQueryContextSearch(queryContext.SearchTerms)
                        .WithQueryContextWhere(queryContext.Where)
                        .WithQueryContextOrderBy(queryContext.OrderBy);
        }

        public static IQueryable<T> WithQueryContextSearch<T>(this IQueryable<T> query, string searchTerms)
        {
            if (string.IsNullOrEmpty(searchTerms) == true) return query;

            return query;
        }

        public static IQueryable<T> WithQueryContextWhere<T>(this IQueryable<T> query, List<QueryContextWhere> whereContext, int currentLevel = 0)
        {
            if (whereContext == null || currentLevel > 250) return query;

            return query;
        }

        public static IQueryable<T> WithQueryContextOrderBy<T>(this IQueryable<T> query, List<QueryContextOrderBy> orderContext)
        {
            if (orderContext == null || (orderContext ?? new List<QueryContextOrderBy>()).Count == 0) return query;

            // if (orderContext[0].desc ?? false == false) query = query.OrderBy(x => EF.Property(x, orderContext[0].key));
            // else query = query.OrderByDescending(x => EF.Property(x, ))

            return query;
        }

        private static IQueryable<T> OrderByPropertyType<T>(this IQueryable<T> query, string column, bool desc, bool thenOrderBy = false)
        {
            var props = typeof(T).GetColumnPropertiesForQueryContext();

            for(var i=0; i < props.Count; i++)
            {
                if (props[i].ColumnName.ToUpper().Trim() == column.ToUpper().Trim())
                {
                    if (props[i].ColumnType == typeof(Guid))
                    {

                    }

                    if (props[i].ColumnType == typeof(string))
                    {

                    }  
                }
            }

            return query;
        }

        public static IQueryable<T> WithQueryContextSkipAndTake<T>(this IQueryable<T> query, int skip, int take)
        {
            return query.Skip(skip).Take(take);
        }

        public static List<ColumnProperty> GetColumnPropertiesForQueryContext(this Type type)
        {
            var props = new List<ColumnProperty>();

            foreach (var x in type.GetProperties().Where(x => x.CanRead == true && x.CanWrite == true))
            {
                var prop = new ColumnProperty()
                {
                    ColumnName = x.Name,
                    ColumnType = x.PropertyType,
                    IsPrimaryKey = Attribute.IsDefined(x, typeof(KeyAttribute))
                };

                props.Add(prop);
            }

            return props;
        }
    }
}