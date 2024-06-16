using Microsoft.AspNetCore.Mvc;
using arusha.Data;
using arusha.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace arusha.Controllers
{
    public class ProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Program
        public async Task<IActionResult> Index()
        {
            var programs = await _context.ProgramUni.ToListAsync();
            return View(programs);
        }

        // GET: Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.ProgramUni.FirstOrDefaultAsync(m => m.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,AcademicDepartmentId,Name,StartDate,EndDate,Description")] ProgramUni programModel)
        {
            if (ModelState.IsValid)
            {
                var existingUniversity = await _context.University.FindAsync(programModel.UniversityId);
                if (existingUniversity == null)
                {
                    ModelState.AddModelError("UniversityId", "The selected university does not exist.");
                    return View(programModel);
                }

                _context.Add(programModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programModel);
        }

        // GET: Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.ProgramUni.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return View(program);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,UniversityId,AcademicDepartmentId,Name,StartDate,EndDate,Description")] ProgramUni programModel)
        {
            if (id != programModel.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramExists(programModel.ProgramId))
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
            return View(programModel);
        }

        // GET: Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.ProgramUni.FirstOrDefaultAsync(m => m.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program = await _context.ProgramUni.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.ProgramUni.Remove(program);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramExists(int id)
        {
            return _context.ProgramUni.Any(e => e.ProgramId == id);
        }
    }
}
