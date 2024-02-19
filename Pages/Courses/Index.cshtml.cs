using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityEFCore.Data;
using System.Reflection;
using ContosoUniversityEFCore.Models.SchoolViewModels;

namespace ContosoUniversityEFCore.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversityEFCore.Data.SchoolContext _context;

        public IndexModel(ContosoUniversityEFCore.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> Courses { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses
                    .Select(p => new CourseViewModel
                    {
                        CourseID = p.CourseID,
                        Title = p.Title,
                        Credits = p.Credits,
                        DepartmentName = p.Department.Name
                    })
                    .ToListAsync();
            }
        }
    }
}
