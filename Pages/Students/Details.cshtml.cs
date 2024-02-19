using ContosoUniversityEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityEFCore.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversityEFCore.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversityEFCore.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
