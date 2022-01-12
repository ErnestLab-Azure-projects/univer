﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Univer.Data;
using Univer.Models;

namespace Univer.Pages.Faculties
{
    public class DetailsModel : PageModel
    {
        private readonly Univer.Data.ApplicationDbContext _context;

        public DetailsModel(Univer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Faculty = await _context.Faculties.FirstOrDefaultAsync(m => m.FacultyId == id);

            if (Faculty == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
