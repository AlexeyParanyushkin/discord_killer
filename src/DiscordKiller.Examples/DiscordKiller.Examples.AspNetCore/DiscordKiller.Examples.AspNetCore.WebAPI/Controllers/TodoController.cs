using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DiscordKiller.Examples.AspNetCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private ApplicationDBContext _applicationDbContext;
        public TodoController(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



        [HttpGet]
        public List<TodoItem> GetAll()
        {
            return _applicationDbContext.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == id);

            if (todoItem == null)
            {
                return NotFound($"Todo item with id {id} not found");
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public IActionResult Create(TodoItemCreateModel todoItemCreateModel)
        {
            var newTodoItem = new TodoItem
            {

                Date = todoItemCreateModel.Date,
                Title = todoItemCreateModel.Title,
                Completed = todoItemCreateModel.Completed
            };


            _applicationDbContext.TodoItems.Add(newTodoItem);
            _applicationDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newTodoItem.Id }, newTodoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItemCreateModel updatedTodoItem)
        {
            var existingTodoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == id);

            if (existingTodoItem == null)
            {
                return NotFound($"Todo item with id {id} not found");
            }

            existingTodoItem.Title = updatedTodoItem.Title;
            existingTodoItem.Date = updatedTodoItem.Date;
            existingTodoItem.Completed = updatedTodoItem.Completed;
            _applicationDbContext.SaveChanges();

            return Ok(existingTodoItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == id);

            if (todoItem == null)
            {
                return NotFound($"Todo item with id {id} not found");
            }


            _applicationDbContext.TodoItems.Remove(todoItem);
            _applicationDbContext.SaveChanges();


            return NoContent();
        }


    }

    public class TodoItem
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class TodoItemCreateModel
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

}    
