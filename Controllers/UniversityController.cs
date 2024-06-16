using Microsoft.AspNetCore.Mvc;
using arusha.Data;
using System.Linq;

namespace arusha.Controllers
{
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchQuery, string searchCriteria)
        {
            IQueryable<arusha.Models.University> universities = _context.University;

            // Применение фильтра по критериям
            if (!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrEmpty(searchCriteria))
            {
                universities = searchCriteria switch
                {
                    "Name" => universities.Where(u => u.Name.Contains(searchQuery)),
                    "FoundedYear" => universities.Where(u => u.FoundedYear.ToString().Contains(searchQuery)),
                    "Location" => universities.Where(u => u.Location.Contains(searchQuery)),
                    "Website" => universities.Where(u => u.Website.Contains(searchQuery)),
                    "AccreditationStatus" => universities.Where(u => u.AccreditationStatus.Contains(searchQuery)),
                    _ => universities, // По умолчанию, если критерий не определен
                };
            }

            // Получение списка университетов после применения фильтра
            var universityList = universities.ToList();
            return View(universityList);
        }
    }
}
