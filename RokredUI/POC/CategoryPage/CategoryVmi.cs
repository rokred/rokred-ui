using System.Dynamic;
using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.POC.CategoryPage
{
    public class CategoryVmi : IRokredListChildDataSource
    {
        public bool IsNew { get; set; }
        
        public bool IsSelected { get; set; }
        
        public string Name { get; }

        public CategoryVmi(string name)
        {
            Name = name;
        }
    }
}