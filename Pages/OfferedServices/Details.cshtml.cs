using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.OfferedServices
{
    public class DetailsModel : PageModel
    {
        private readonly EventPlanner.Data.EventPlannerContext _context;

        public DetailsModel(EventPlanner.Data.EventPlannerContext context)
        {
            _context = context;
        }

        public OfferedService OfferedService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offeredservice = await _context.OfferedService.FirstOrDefaultAsync(m => m.ID == id);
            if (offeredservice == null)
            {
                return NotFound();
            }
            else
            {
                OfferedService = offeredservice;
            }
            return Page();
        }
    }
}
