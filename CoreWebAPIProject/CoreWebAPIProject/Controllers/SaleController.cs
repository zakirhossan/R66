using CoreWebAPIProject.DataContext;
using CoreWebAPIProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly AppDBContext _context;
        public SaleController(AppDBContext context)
        {
            _context = context;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sale = await _context.saleMasters.Include(s => s.SaleDetails).ToListAsync();
            return Ok(sale);
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sale = await _context.saleMasters.Include(s => s.SaleDetails).FirstOrDefaultAsync(s => s.Id == id);
            if(sale== null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        // POST api/<SaleController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create( SaleMaster sm)
        {
            _context.Add(sm);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),new {id=sm.Id },sm) ;
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
