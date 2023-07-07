using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportShopAPI.Models;

namespace SportShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductsController : ControllerBase
    {
        private readonly SportShopContext _context;

        public TypeProductsController(SportShopContext context)
        {
            _context = context;
        }

        // GET: api/TypeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProduct>>> GetTypeProducts()
        {
            return await _context.TypeProducts.ToListAsync();
        }

        // GET: api/TypeProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeProduct>> GetTypeProduct(int id)
        {
            var typeProduct = await _context.TypeProducts.FindAsync(id);

            if (typeProduct == null)
            {
                return NotFound();
            }

            return typeProduct;
        }

        // PUT: api/TypeProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeProduct(int id, TypeProduct typeProduct)
        {
            if (id != typeProduct.IdTypeProduct)
            {
                return BadRequest();
            }

            _context.Entry(typeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeProductExists(id))
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

        // POST: api/TypeProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeProduct>> PostTypeProduct(TypeProduct typeProduct)
        {
            _context.TypeProducts.Add(typeProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeProduct", new { id = typeProduct.IdTypeProduct }, typeProduct);
        }

        // DELETE: api/TypeProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeProduct(int id)
        {
            var typeProduct = await _context.TypeProducts.FindAsync(id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            _context.TypeProducts.Remove(typeProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeProductExists(int id)
        {
            return _context.TypeProducts.Any(e => e.IdTypeProduct == id);
        }
    }
}
