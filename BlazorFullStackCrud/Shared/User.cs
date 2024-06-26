using BlazorFullStackCrud.Shared;
using System;
using System.Collections.Generic;

namespace BlazorFullStackCrud.Shared
{
    public partial class User
    {
        public User()
        {
            IssueNotes = new HashSet<IssueNote>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<IssueNote> IssueNotes { get; set; }
    }
}
