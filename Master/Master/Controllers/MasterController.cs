using Master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Master.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly MasterDBContext _context;
        public MasterController(MasterDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetByUserId/{user_id}")]
        public async Task<ActionResult<ms_user>> GetUser(long user_id)
        {
            var user = await _context.ms_user.FindAsync(user_id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<ms_user>>> GetUsers()
        {
            var user = await _context.ms_user.ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetByUsername/{username}/{password}")]
        public async Task<ActionResult<ms_user>> GetUserByUsername(string username, string password)
        {
            var user = await _context.ms_user.FirstOrDefaultAsync(p => p.user_name == username && p.password == password && p.is_active == true); 

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetAllLocation")]
        public async Task<ActionResult<IEnumerable<ms_user>>> GetLocations()
        {
            var user = await _context.ms_user.ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
