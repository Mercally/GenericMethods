using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities.Notations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string TableName)
        {
            this.TableName = TableName;
        }

        private TableAttribute() { }

        public string TableName { get; set; }
    }
}
