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
    /// <summary>
    /// This controller changes data
    /// </summary>
    [ApiController]
    [Route("api[controller]")]
    public class CategoryController:ControllerBase
    {
       
        private readonly DataBase _db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">DataBase "MyListToDo" in this progect</param>
        public CategoryController( DataBase db)
        {
            _db = db;         
        }
        /// <summary>
        /// method Get
        /// </summary>
        /// <returns>returns all list categories</returns>
        [HttpGet]
        [Route("getAllCategories")]
        public IActionResult GetAllCategories()
        {
            var allCategories = _db.MyCategories.OrderBy(t => t.Id);
            if (allCategories is null) return BadRequest("Dont foud categories");
            return new JsonResult(allCategories);
        }
        [HttpGet]
        [Route("categoriaId")]
        public IActionResult GetNews(int ID)
        {
            var newlistcategory = _db.MyCategories.FirstOrDefault(t => t.ListCategory.Id == ID);
            if (newlistcategory is null) return BadRequest(new { errorText = "Invalid  id list of category" });
            return new JsonResult(newlistcategory);
        }

        [HttpPost]
        [Route("createCategoria")]
        public IActionResult Reg([FromBody] CreateCategoriesRequestModel model)
        {
             
            var list = _db.MyList.FirstOrDefault(t => t.Id == model.ListCategory.Id);
           
            var newCategory = new Categoria()
            {            
                NameCategory = model.NameCategory,
                ListCategory =list
            };

            _db.MyCategories.Add(newCategory);
            _db.SaveChanges();
            return Ok("Saved");
        }

        [HttpPost]
        [Route("deleteByIdCategory")]
        public IActionResult DelById(int Id)
        {
            var cotegoria = _db.MyCategories.FirstOrDefault(t => t.Id == Id);
            if (cotegoria is null) return BadRequest("Categoria is not exist");
            _db.MyCategories.Remove(cotegoria);
            _db.SaveChanges();
            return Ok("Saved");

        }
    }
}
