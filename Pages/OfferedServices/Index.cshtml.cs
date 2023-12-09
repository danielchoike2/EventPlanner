using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace EventPlanner.Pages.OfferedServices
{
    public class IndexModel : PageModel
    {
        private readonly EventPlanner.Data.EventPlannerContext _context;

        public IndexModel(EventPlanner.Data.EventPlannerContext context)
        {
            _context = context;
        }

        public IList<OfferedService> OfferedService { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? ServiceNames { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ServiceName { get; set; }
        public string NameSort { get; set; }
        public string RateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            RateSort = sortOrder == "RateAsc" ? "RateDesc" : "RateAsc";

            var offeredServices = from r in _context.OfferedService
                            select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                offeredServices = offeredServices.Where(r => r.Name.Contains(SearchString)
                            || r.Rate.ToString().Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "NameDesc":
                    offeredServices = offeredServices.OrderByDescending(r => r.Name);
                    break;
                case "RateDesc":
                    offeredServices = offeredServices.OrderByDescending(r => r.Rate);
                    break;
                case "RateAsc":
                    offeredServices = offeredServices.OrderBy(r => r.Rate);
                    break;

                default:
                    offeredServices = offeredServices.OrderBy(r => r.Name);
                    break;
            }

            OfferedService = await offeredServices.ToListAsync();
        }
    }
}

