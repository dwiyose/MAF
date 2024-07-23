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

        [HttpGet("GetByAggrementNumber")]
        public async Task<ActionResult<TransactionModel>> GetProduct(string aggrement_number)
        {
            var tr = await _context.tr_bpkb.FindAsync(aggrement_number);

            if (tr == null)
            {
                return NotFound();
            }

            return tr;
        }
        [HttpGet("GetAllTransaction")]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetUsers()
        {
            var user = await _context.tr_bpkb.ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("Save")]
        public async Task<ActionResult<TransactionModel>> PostProduct(TransactionModel product)
        {
            _context.tr_bpkb.Add(product);
            await _context.SaveChangesAsync();
            //TransactionModel trans = GetProduct(product.agreement_number);
            return product;
        }
    }
}
