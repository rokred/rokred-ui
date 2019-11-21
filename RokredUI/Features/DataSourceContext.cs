using System.Collections.Generic;
using System.Linq;
using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.Features
{
    public class DataSourceContext
    {
        public IList<IRokredListChildDataSource> ContextItems { get; set; }

        public string LastContextItem => ContextItems.Any() ? ContextItems.Last().ToString() : "SELECT A CATEGORY";

        public DataSourceContext()
        {
            ContextItems = new List<IRokredListChildDataSource>();
        }
    }
}