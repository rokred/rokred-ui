using System;

namespace RokredUI.Backend
{
    public class OpinionModel
    {
        public string Subject { get; set; }
        public string Opinion { get; set; }

        public OpinionModel()
        {
            Subject = string.Empty;
            Opinion = string.Empty;
        }

        public OpinionModel(string subject, string opinion)
        {
            Subject = subject;
            Opinion = opinion;
        }
    }
}