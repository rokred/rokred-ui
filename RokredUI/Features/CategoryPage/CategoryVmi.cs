using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.Features.CategoryPage
{
    public class CategoryVmi : IRokredListChildDataSource
    {
        public  int Id { get; set; }
        public int ParentId { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool IsSelected { get; set; }
        
        public string Name { get; }

        public CategoryVmi(int id, string name)
        {
            Name = name;
            
            Id = id;
        }
        
        public CategoryVmi(int id, int parentId, string name)
        {
            Name = name;
            
            Id = id;
            ParentId = parentId;
        }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }
}