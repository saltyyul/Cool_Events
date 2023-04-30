using Cool_Events.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cool_Events.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserController
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {

            return _context.User != null ?
                        View(await _context.User.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Event'  is null.");
        }

        // GET: UserController/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var @event = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: UserController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Discriminator,FirstName,LastName,UserName,NormalizedUserName," +
            "Email,NormalizedEmail,EmailConfirmed,PasswordHash")] User @user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@user);
        }

        // GET: UserController/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var @user = await _context.User.FindAsync(id);
            if (@user == null)
            {
                return NotFound();
            }
            return View(@user);
        }

        // POST: UserController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("Id,Discriminator,FirstName,LastName,UserName,NormalizedUserName," +
            "Email,NormalizedEmail,EmailConfirmed,PasswordHash")] User @user)
        {
            if (id != @user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(@user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@user);
        }

        // GET: UserController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var @user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@user == null)
            {
                return NotFound();
            }

            return View(@user);
        }

        // POST: UserController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Event'  is null.");
            }
            var @user = await _context.User.FindAsync(id);
            if (@user != null)
            {
                _context.Users.Remove(@user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
