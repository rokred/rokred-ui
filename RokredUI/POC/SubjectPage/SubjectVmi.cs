using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.POC.SubjectPage
{
    public class SubjectVmi : IRokredListChildDataSource
    {
       public bool IsNew { get; set; }
        public  bool IsSelected { get; set; }
        public  string Name { get; set; }
        
        public SubjectVmi(string name)
        {
            Name = name;
        }
    }
}