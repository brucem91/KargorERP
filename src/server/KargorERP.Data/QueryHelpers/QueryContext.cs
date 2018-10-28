using System;
using System.Collections.Generic;

namespace KargorERP.Data.QueryHelpers
{
    public class QueryContext
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string SearchTerms { get; set; }
        public List<QueryContextWhere> Where { get; set; }
        public List<QueryContextOrderBy> OrderBy { get; set; }
    }

    public class QueryContextWhere
    {
        public string key { get; set; }
        public string op { get; set; }
        public string val { get; set; }
        public List<QueryContextWhere> or { get; set; }
    }

    public class QueryContextOrderBy
    {
        public string key { get; set; }
        public bool? desc { get; set; }
    }
}