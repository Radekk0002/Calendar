using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class ToDo
    {
        public int UserToDoId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Text is too long (max 50 characters)")]
        public string Text { get; set; }

        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }

/*        string text;
        DateTime start;
        DateTime end;

        public ToDo(string text, DateTime start, DateTime end)
        {
            this.text = text;
            this.start = start;
            this.end = end;
        }

        public string GetText => text;
        public DateTime GetStart => start;
        public DateTime GetEnd => end;*/
    }
}
