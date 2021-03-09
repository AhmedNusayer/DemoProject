using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Models;

namespace DemoProject.Controllers
{

    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> Index()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> UserInfo(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}
