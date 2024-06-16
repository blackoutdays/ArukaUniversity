using System.Linq;
using Microsoft.AspNetCore.Mvc;
using arusha.Data;
using arusha.Models;
using arusha.ViewModels;

namespace arusha.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(StudentViewModel model)
        {
            var students = _context.Student.AsQueryable();

            if (model.SelectedGender.HasValue)
            {
                students = students.AsEnumerable().Where(s => s.Gender.ToString() == model.SelectedGender.ToString()).AsQueryable();
            }

            model.Students = students.ToList();

            return View(model);
        }


    }
}
