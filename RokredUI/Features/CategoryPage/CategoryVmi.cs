using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.Features.CategoryPage
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

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }
}