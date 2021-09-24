using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiMylistTodo.Modelels.Entities
{
   public  class Categoria
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public TodoList ListCategory { get; set; }
    }
}
