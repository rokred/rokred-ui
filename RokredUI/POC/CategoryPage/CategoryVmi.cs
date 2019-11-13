using System.Dynamic;

namespace RokredUI.POC.CategoryPage
{
    public class CategoryVmi
    {
        public bool IsNew { get; set; }
        public string Name { get; }

        public CategoryVmi(string name)
        {
            IsNew = true;
            Name = name;
        }
    }
}