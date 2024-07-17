using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transaction.Models;

namespace Transaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionDBContext _context;
        public TransactionController(TransactionDBContext context)
        {
            _context = context;
        }

        [HttpGet("{agreement_number}")]
        public async Task<ActionResult<TransactionModel>> GetProduct(string id)
        {
            var tr = await _context.tr_bpkb.FindAsync(id);

            if (tr == null)
            {
                return NotFound();
            }

            return tr;
        }

        [HttpPost("Save")]
        public async Task<ActionResult<TransactionModel>> PostProduct(TransactionModel product)
        {
            _context.tr_bpkb.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.agreement_number }, product);
        }
    }
}
