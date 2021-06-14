using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReminderHandler.Models;

namespace ReminderHandler.Data
{
    public class ReminderHandlerContext : DbContext
    {
        public ReminderHandlerContext (DbContextOptions<ReminderHandlerContext> options)
            : base(options)
        {
        }

        public DbSet<ReminderHandler.Models.Reminder> Reminder { get; set; }
    }
}
