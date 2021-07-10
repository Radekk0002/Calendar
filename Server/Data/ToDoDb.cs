using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data
{
    public class ToDoDb : ToDo
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; }
    }
}
