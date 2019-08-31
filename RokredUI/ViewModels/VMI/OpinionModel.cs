using System;

namespace RokredUI.ViewModels.VMI
{
    public class OpinionModel
    {
        public Guid Id { get; set; }

        public SubjectModel Subject { get; set; }

        public string Opinion { get; set; }

        public Guid? OpinionThreadId { get; set; }

        public int? PositionInThread { get; set; }
    }
}