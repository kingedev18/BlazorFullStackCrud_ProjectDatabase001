using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsIssueNoteApp
{
    public class IssueNotes
    {
        public int IssueNoteID { get; set; }
        public int UserID { get; set; }
        public DateTime IssueDate { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
