using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiMylistTodo.Modelels.Entities

{
   public sealed class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

       
        public DbSet<TodoList> MyList { get; set; }
        public DbSet<Categoria> MyCategories { get; set; }
    }
}
