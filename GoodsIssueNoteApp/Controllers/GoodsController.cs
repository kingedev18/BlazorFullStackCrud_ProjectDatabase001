using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsIssueNoteApp.Data;
using GoodsIssueNoteApp;

namespace GoodsIssueNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public async Task<ActionResult<List<Goods>>> GetSuperGoods()
        {
            var goods = await _context.Goods.ToListAsync();
            return Ok(goods);
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goods>> GetSingleGood(int id)
        {
            var good = await _context.Goods
                .FirstOrDefaultAsync(h => h.GoodID == id);
            if (good == null)
            {
                return NotFound("No available goods. :/");
            }
            return Ok(good);
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Goods>>> UpdateGood(Goods good, int id)
        {
            var dbGood = await _context.Goods
                .FirstOrDefaultAsync(sh => sh.GoodID == id);
            if (dbGood == null)
                return NotFound("No available goods. :/");

            dbGood.Name = good.Name;
            dbGood.Description = good.Description;
            dbGood.QuantityOfStock = good.QuantityOfStock;

            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        // POST: api/Goods
        [HttpPost]
        public async Task<ActionResult<List<Goods>>> CreateGood(Goods good)
        {
            //hero.Comic = null;
            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Goods>>> DeleteGood(int id)
        {
            var dbGood = await _context.Goods
                //.Include(sh => sh.Comic)
                .FirstOrDefaultAsync(sh => sh.GoodID == id);
            if (dbGood == null)
                return NotFound("No Goods:/");

            _context.Goods.Remove(dbGood);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        private async Task<List<Goods>> GetDbGoods()
        {
            return await _context.Goods.ToListAsync();
        }
    }
}