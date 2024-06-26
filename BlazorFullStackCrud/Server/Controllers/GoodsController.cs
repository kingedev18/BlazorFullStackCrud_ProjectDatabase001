using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFullStackCrud.Server.Data;

namespace BlazorFullStackCrud.Server.Controllers
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
        public async Task<ActionResult<List<Good>>> GetGoods()
        {
            var goods = await _context.Goods.ToListAsync();
            return Ok(goods);
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Good>> GetSingleGood(int id)
        {
            var good = await _context.Goods
                .FirstOrDefaultAsync(h => h.GoodId == id);
            if (good == null)
            {
                return NotFound("No available goods. :/");
            }
            return Ok(good);
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Good>>> UpdateGood(Good good, int id)
        {
            var dbGood = await _context.Goods
                .FirstOrDefaultAsync(sh => sh.GoodId == id);
            if (dbGood == null)
                return NotFound("No available goods. :/");

            dbGood.Name = good.Name;
            dbGood.Description = good.Description;
            dbGood.QuantityInStock = good.QuantityInStock;

            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        // POST: api/Goods
        [HttpPost]
        public async Task<ActionResult<List<Good>>> CreateGood(Good good)
        {
            //hero.Comic = null;
            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Good>>> DeleteGood(int id)
        {
            var dbGood = await _context.Goods
                //.Include(sh => sh.Comic)
                .FirstOrDefaultAsync(sh => sh.GoodId == id);
            if (dbGood == null)
                return NotFound("No Goods:/");

            _context.Goods.Remove(dbGood);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGoods());
        }

        private async Task<List<Good>> GetDbGoods()
        {
            return await _context.Goods.ToListAsync();
        }
    }
}