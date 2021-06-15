using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReminderHandler.Data;
using ReminderHandler.Models;

namespace ReminderHandler.Pages.Reminders
{
    public class IndexModel : PageModel
    {
        private readonly ReminderHandler.Data.ReminderHandlerContext _context;

        public IndexModel(ReminderHandler.Data.ReminderHandlerContext context)
        {
            _context = context;
        }

        public IList<Reminder> Reminder { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } 
        public string FavoriteSort { get; set; }       
        public async Task OnGetAsync(bool? favorite)
        {
            var reminders = from m in _context.Reminder
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                reminders = reminders.Where(s => s.Title.ToUpper().Contains(SearchString)) ;
                
            }
            //if (Reminder.favorite != null)
            //{

            //}
            //FavoriteSort = String.IsNullOrEmpty(SortOrder) ? "" : "name_desc";

            Reminder = await reminders
            
                .OrderByDescending(i => i.Favorite)
                .ThenBy(i => i.Title)
            
                .ToListAsync();

        }
    }
}
