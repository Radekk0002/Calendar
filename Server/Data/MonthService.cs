using Microsoft.AspNetCore.Http;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class MonthService
    {
        private readonly ToDoContext context;
        private IHttpContextAccessor contextAccessor;

        public MonthService(ToDoContext context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.contextAccessor = contextAccessor;
        }

        public (Month,int) GetMonth(DateTime date)
        {
            string userEmail = contextAccessor.HttpContext.User.Identity.Name;

            IEnumerable<ToDoDb> todos = context.ToDos.Where(todo => todo.Email == userEmail
            && todo.Start.Year == date.Year && todo.Start.Month == date.Month);

            Month month = new Month(date);

            int maxID = context.ToDos
                .Where(todo => todo.Email == userEmail)
                .Select(todo => todo.UserToDoId)
                .DefaultIfEmpty()
                .Max();

            foreach (var item in todos)
            {
                month[item.Start.Day - 1].AddToDo(item);

            }

            return (month,maxID);
        }
    }
}
