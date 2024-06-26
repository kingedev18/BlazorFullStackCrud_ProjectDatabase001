using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsIssueNoteApp
{
    public class IssueNoteDetails
    {
        public int IssueNoteDetailID { get; set; }
        public int IssueNoteID { get; set; }
        public int GoodID { get; set; }
        public int QuantityIssued { get; set; }
    }
}
