using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.POC.OpinionPage
{
    public class OpinionVmi : IRokredListChildDataSource
    {
        public OpinionVmi(string title, string body = null)
        {
            Title = title;
            Body = body;
        }

        public bool IsNew { get; set; }
        public bool IsSelected { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
    }
}