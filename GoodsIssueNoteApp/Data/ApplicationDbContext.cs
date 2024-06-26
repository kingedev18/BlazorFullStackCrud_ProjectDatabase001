using Microsoft.EntityFrameworkCore;

namespace GoodsIssueNoteApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<IssueNoteDetails> IssueNoteDetails { get; set; }
        public DbSet<IssueNotes> IssueNotes { get; set; }
        public DbSet<Users> Users { get; set; }
    }

}
