using System;
using System.Collections.Generic;

namespace BlazorFullStackCrud.Shared
{
    public partial class IssueNote
    {
        public IssueNote()
        {
            IssueNoteDetails = new HashSet<IssueNoteDetail>();
        }

        public int IssueNoteId { get; set; }
        public int? UserId { get; set; }
        public DateTime IssueDate { get; set; }
        public string? Remarks { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<IssueNoteDetail> IssueNoteDetails { get; set; }
    }
}
