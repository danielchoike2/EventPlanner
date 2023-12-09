using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner.Pages.OfferedServices
{
    public class EditModel : PageModel
    {
        private readonly EventPlanner.Data.EventPlannerContext _context;

        public EditModel(EventPlanner.Data.EventPlannerContext context)
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

            var offeredservice =  await _context.OfferedService.FirstOrDefaultAsync(m => m.ID == id);
            if (offeredservice == null)
            {
                return NotFound();
            }
            OfferedService = offeredservice;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OfferedService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferedServiceExists(OfferedService.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfferedServiceExists(int id)
        {
            return _context.OfferedService.Any(e => e.ID == id);
        }
    }
}
