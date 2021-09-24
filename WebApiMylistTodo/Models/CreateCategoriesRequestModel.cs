using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMylistTodo.Modelels.Entities;

namespace WebApiMylistTodo.Models
{
    public class CreateCategoriesRequestModel
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public TodoList ListCategory { get; set; }
    }
}
