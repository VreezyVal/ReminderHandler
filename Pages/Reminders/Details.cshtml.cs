using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReminderHandler.Data;
using ReminderHandler.Models;

namespace ReminderHandler.Pages.Reminders
{
    public class DetailsModel : PageModel
    {
        private readonly ReminderHandler.Data.ReminderHandlerContext _context;

        public DetailsModel(ReminderHandler.Data.ReminderHandlerContext context)
        {
            _context = context;
        }

        public Reminder Reminder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reminder = await _context.Reminder.FirstOrDefaultAsync(m => m.ID == id);

            if (Reminder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
