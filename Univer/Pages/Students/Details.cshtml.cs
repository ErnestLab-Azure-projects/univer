using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Univer.Data;
using Univer.Models;

namespace Univer.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Univer.Data.ApplicationDbContext _context;

        public DetailsModel(Univer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.User).FirstOrDefaultAsync(m => m.StudentId == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
