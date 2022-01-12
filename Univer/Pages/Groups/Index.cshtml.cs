using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Univer.Data;
using Univer.Models;

namespace Univer.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly Univer.Data.ApplicationDbContext _context;

        public IndexModel(Univer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Group> Group { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Group = await _context.Groups.ToListAsync();
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
