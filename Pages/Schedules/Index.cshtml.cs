
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using EventPlanner.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventPlanner.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly EventPlanner.Data.EventPlannerContext _context;

        public IndexModel(EventPlanner.Data.EventPlannerContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; } = default!;

        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? ServiceNames { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ServicesName { get; set; }

        public string NameSort { get; set; }
        public string LocationSort { get; set; }
        public string DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            LocationSort = sortOrder == "LocAsc" ? "LocDesc" : "LocAsc";
            DateSort = sortOrder == "DateAsc" ? "DateDesc" : "DateAsc";

            var schedService = from r in _context.Schedule
                                  select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                schedService = schedService.Where(r => r.ServiceName.Contains(SearchString)
                            || r.Location.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "NameDesc":
                    schedService = schedService.OrderByDescending(r => r.ServiceName);
                    break;
                case "LocDesc":
                    schedService = schedService.OrderByDescending(r => r.Location);
                    break;
                case "LocAsc":
                    schedService = schedService.OrderBy(r => r.Location);
                    break;
                case "DateDesc":
                    schedService = schedService.OrderBy(r => r.ScheduleDate);
                    break;
                case "DateAsc":
                    schedService = schedService.OrderBy(r => r.ScheduleDate);
                    break;

                default:
                    schedService = schedService.OrderBy(r => r.ServiceName);
                    break;
            }

            Schedule = await schedService.ToListAsync();
        }
    }
}

