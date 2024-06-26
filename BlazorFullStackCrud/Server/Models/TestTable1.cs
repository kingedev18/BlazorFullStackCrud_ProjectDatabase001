using System;
using System.Collections.Generic;

namespace BlazorFullStackCrud.Server.Models
{
    public partial class TestTable1
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string Description { get; set; } = null!;
        public string? Usertype { get; set; }
    }
}
