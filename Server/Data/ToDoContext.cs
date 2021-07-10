using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class ToDoContext : DbContext
    {

        public ToDoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ToDoDb> ToDos { get; set; }
    }
}
