using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Day
    {
        public readonly int day;
        public readonly DateTime date;
        List<ToDo> toDos;

        public Day(DateTime date, List<ToDo> toDos)
        {
            this.date = date;
            this.day = date.Day;
            this.toDos = toDos;
        }

        public int ToDosCount => toDos.Count;

        public ToDo this[int i]
        {
            get { return toDos[i]; }
        }

        public void AddToDo(ToDo todo)
        {
            toDos.Add(todo);
        }

        public void RemoveToDo(ToDo todo)
        {
            toDos.Remove(todo);
        }
    }
}
