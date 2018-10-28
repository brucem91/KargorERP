using System;
using System.Reflection;

namespace KargorERP.Data.QueryHelpers
{
    public class ColumnProperty
    {
        public string ColumnName { get; set; }
        public Type ColumnType { get; set; }
        public bool IsPrimaryKey { get; set; }
    }
}