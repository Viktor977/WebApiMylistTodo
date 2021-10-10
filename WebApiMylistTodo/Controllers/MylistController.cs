using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMylistTodo.Modelels.Entities;
using WebApiMylistTodo.Models;

namespace WebApiMylistTodo.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class MylistController : ControllerBase
    {

        private readonly DataBase _db;
        public MylistController(DataBase db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllList()
        {
            var allList = _db.MyList.OrderBy(t => t.Id);
            return new JsonResult(allList);
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetListToDoById(int ID)
        {
            var newlist = _db.MyList.FirstOrDefault(Ø => Ø.Id == ID);
            if (newlist is null) return BadRequest(new { errorText = "Invalid list todo" });
            return new JsonResult(newlist);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Reg([FromBody] CreateRequestMylistTodoModel model)
        {

            var newTodolist = new TodoList()
            {
                Priority = model.Priority,
                Text = model.Text,
                Deadline = model.Deadline,
                IsDone = model.IsDone,
                Mark = model.Mark
            };
            _db.MyList.Add(newTodolist);
            _db.SaveChanges();
            return Ok("Saved");
        }

        [HttpPost]
        [ Route("delete")]
        public IActionResult Del(int ID)
        {
            var dellist = _db.MyList.FirstOrDefault(Ø => Ø.Id == ID);
            if (dellist is null) return BadRequest($"not found list with Id={ID}"); 
            _db.MyList.Remove(dellist);
            _db.SaveChanges();
            return Ok("Saved");
        }
    }
}
