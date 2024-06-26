using GoodsIssueNoteApp.Data;
using GoodsIssueNoteApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class IssueNoteDetailsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IssueNoteDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/IssueNoteDetail
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IssueNoteDetails>>> GetIssueNoteDetails()
    {
        return await _context.IssueNoteDetails.ToListAsync();
    }

    // GET: api/IssueNoteDetail/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IssueNoteDetails>> GetIssueNoteDetails(int id)
    {
        var issueNoteDetail = await _context.IssueNoteDetails.FindAsync(id);

        if (issueNoteDetail == null)
        {
            return NotFound();
        }

        return issueNoteDetail;
    }

    // PUT: api/IssueNotesDetail/5
    [HttpPut("{id}")]
    public async Task<IActionResult> GetIssueNoteDetails(int id, IssueNoteDetails issueNoteDetail)
    {
        if (id != issueNoteDetail.IssueNoteDetailID)
        {
            return BadRequest();
        }

        _context.Entry(issueNoteDetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IssueNoteDetailExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/IssueNotesDetails
    [HttpPost]
    public async Task<ActionResult<IssueNoteDetails>> PostIssueNote(IssueNoteDetails issueNoteDetail)
    {
        _context.IssueNoteDetails.Add(issueNoteDetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIssueNoteDetail", new { id = issueNoteDetail.IssueNoteDetailID }, issueNoteDetail);
    }

    // DELETE: api/IssueNotesDetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssueNoteDetail(int id)
    {
        var issueNoteDetail = await _context.IssueNoteDetails.FindAsync(id);
        if (issueNoteDetail == null)
        {
            return NotFound();
        }

        _context.IssueNoteDetails.Remove(issueNoteDetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IssueNoteDetailExists(int id)
    {
        return _context.IssueNoteDetails.Any(e => e.IssueNoteDetailID == id);
    }
}
