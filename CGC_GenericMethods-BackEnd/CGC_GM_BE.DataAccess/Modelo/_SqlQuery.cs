using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class SQLQuery
    {
        public SQLQuery(string RawQuery, List<SqlParameter> Parameters = null)
        {
            this.RawQuery = RawQuery;
            this.Parameters = Parameters ?? new List<SqlParameter>();
        }

        public SQLQuery() { }

        public string RawQuery { get; set; }
        public List<SqlParameter> Parameters { get; set; }
    }
}
