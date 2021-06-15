using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReminderHandler.Data;
using ReminderHandler.Models;

namespace ReminderHandler.Pages.Reminders
{
    public class CreateModel : PageModel
    {
        private readonly ReminderHandler.Data.ReminderHandlerContext _context;

        public CreateModel(ReminderHandler.Data.ReminderHandlerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reminder Reminder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reminder.Add(Reminder);
            //_context.Reminder.Update(Reminder.CreationDate);
            Reminder.CreationDate = DateTime.Now;
            Reminder.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
