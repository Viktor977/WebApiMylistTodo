using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMylistTodo.Modelels.Entities;

namespace WebApiMylistTodo.Models
{
    public class CreateRequestMylistTodoModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string Mark { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }
    }
}
