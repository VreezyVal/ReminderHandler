using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReminderHandler.Models
{
    public class Reminder
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        public bool Favorite { get; set; }
    }
}
