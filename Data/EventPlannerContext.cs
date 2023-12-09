using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventPlanner.Models;

namespace EventPlanner.Data
{
    public class EventPlannerContext : DbContext
    {
        public EventPlannerContext (DbContextOptions<EventPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<EventPlanner.Models.OfferedService> OfferedService { get; set; } = default!;

        public DbSet<EventPlanner.Models.Schedule> Schedule { get; set; } = default!;
    }
}
