using GoodsIssueNoteApp.Data;
using GoodsIssueNoteApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class IssueNotesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IssueNotesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/IssueNotes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IssueNotes>>> GetIssueNote()
    {
        return await _context.IssueNotes.ToListAsync();
    }

    // GET: api/IssueNotes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IssueNotes>> GetIssueNote(int id)
    {
        var issueNote = await _context.IssueNotes.FindAsync(id);

        if (issueNote == null)
        {
            return NotFound();
        }

        return issueNote;
    }

    // PUT: api/IssueNotes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIssueNote(int id, IssueNotes issueNote)
    {
        if (id != issueNote.IssueNoteID)
        {
            return BadRequest();
        }

        _context.Entry(issueNote).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IssueNoteExists(id))
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

    // POST: api/IssueNotes
    [HttpPost]
    public async Task<ActionResult<IssueNotes>> PostIssueNote(IssueNotes issueNote)
    {
        _context.IssueNotes.Add(issueNote);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIssueNote", new { id = issueNote.IssueNoteID }, issueNote);
    }

    // DELETE: api/IssueNotes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssueNote(int id)
    {
        var issueNote = await _context.IssueNotes.FindAsync(id);
        if (issueNote == null)
        {
            return NotFound();
        }

        _context.IssueNotes.Remove(issueNote);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IssueNoteExists(int id)
    {
        return _context.IssueNotes.Any(e => e.IssueNoteID == id);
    }
}
