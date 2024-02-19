using ContosoUniversityEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityEFCore.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversityEFCore.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversityEFCore.Data.SchoolContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }
    }
}
