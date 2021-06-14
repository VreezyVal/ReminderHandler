using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReminderHandler.Data;
using ReminderHandler.Models;

namespace ReminderHandler.Pages.Reminders
{
    public class EditModel : PageModel
    {
        private readonly ReminderHandler.Data.ReminderHandlerContext _context;

        public EditModel(ReminderHandler.Data.ReminderHandlerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reminder).State = EntityState.Modified;

            try
            {
                // _context.Reminder.Update(Reminder);
                Reminder.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderExists(Reminder.ID))
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

        private bool ReminderExists(int id)
        {
            return _context.Reminder.Any(e => e.ID == id);
        }
    }
}
