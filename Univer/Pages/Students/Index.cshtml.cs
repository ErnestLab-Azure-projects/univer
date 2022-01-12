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
    public class IndexModel : PageModel
    {
        private readonly Univer.Data.ApplicationDbContext _context;

        public IndexModel(Univer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.User).ToListAsync();
        }
    }
}
