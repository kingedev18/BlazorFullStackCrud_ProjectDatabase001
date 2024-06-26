using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsIssueNoteApp
{
    public class Goods
    {
        public int GoodID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityOfStock { get; set; }
    }
}
