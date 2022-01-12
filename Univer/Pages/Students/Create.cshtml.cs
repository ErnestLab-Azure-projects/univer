using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Univer.Data;
using Univer.Models;

namespace Univer.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Univer.Data.ApplicationDbContext _context;

        public CreateModel(Univer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyId");
        ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
        ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
