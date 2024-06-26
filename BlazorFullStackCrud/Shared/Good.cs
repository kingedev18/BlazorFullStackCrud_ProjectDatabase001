using System;
using System.Collections.Generic;

namespace BlazorFullStackCrud.Shared
{
    public partial class Good
    {
        public Good()
        {
            IssueNoteDetails = new HashSet<IssueNoteDetail>();
        }

        public int GoodId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ICollection<IssueNoteDetail> IssueNoteDetails { get; set; }
    }
}
