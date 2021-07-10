using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Server.Data
{
    public class ToDoService
    {
        private readonly ToDoContext context;
        private IHttpContextAccessor contextAccessor;


        public ToDoService(ToDoContext context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.contextAccessor = contextAccessor;
        }
        public (bool,int) PostToDo(ToDo todo)
        {
            int max = -1;
            try
            {
                var email = contextAccessor.HttpContext.User.Identity.Name;
                var todos = context.ToDos.Where(todo => todo.Email == email);

                max = todos.DefaultIfEmpty().Max(todo => todo == null ? -1 : todo.UserToDoId);
                ToDoDb tododb = new ToDoDb();
                tododb.Text = todo.Text;
                tododb.Start = todo.Start;
                tododb.End = todo.End;
                tododb.UserToDoId = max + 1;
                tododb.Email = email;

                context.Add(tododb);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return (false, max);
            }

                return (true, max + 1);
        }

        public bool UpdateToDo(ToDo todo, int id)
        {
            try
            {
                var entity = context.ToDos.FirstOrDefault(item => item.Email == contextAccessor.HttpContext.User.Identity.Name && item.UserToDoId == id);

                if (entity != null)
                {
                    entity.Start = todo.Start;
                    entity.End = todo.End;
                    entity.Text = todo.Text;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteToDo(int id)
        {
            try
            {
                var entity = context.ToDos.FirstOrDefault(item => item.Email == contextAccessor.HttpContext.User.Identity.Name && item.UserToDoId == id);

                if(entity != null)
                {
                    context.Remove(entity);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
