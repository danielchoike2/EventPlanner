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
    public class DeleteModel : PageModel
    {
        private readonly EventPlanner.Data.EventPlannerContext _context;

        public DeleteModel(EventPlanner.Data.EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offeredservice = await _context.OfferedService.FindAsync(id);
            if (offeredservice != null)
            {
                OfferedService = offeredservice;
                _context.OfferedService.Remove(OfferedService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
