using System;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;

namespace RokredUI.Features.OpinionPage
{
    public class OpinionVmi : IRokredListChildDataSource
    {
        public OpinionVmi(bool isDirty)
        {
            IsDirty = isDirty;
        }
        
        public OpinionVmi(string title, string body = "")
        {
            Title = title;
            Body = body;
        }
        
        public OpinionVmi()
        {
            Title = "";
            Body = "";
        }

        public bool IsDirty { get; set; }
        public bool IsNew { get; set; }
        public bool IsSelected { get; set; }
        
        [Reactive] public string Title { get; set; }
        
        [Reactive] public string Body { get; set; }

        public bool EmptyTitle => string.IsNullOrWhiteSpace(Title);
        public bool HasTitle => !string.IsNullOrWhiteSpace(Title);
        public bool EmptyBody => string.IsNullOrWhiteSpace(Body);
    }
}