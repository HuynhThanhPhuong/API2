using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost]
        public IActionResult AddTask([FromBody] API2.Models.Task task)
        {
            try
            {
                _taskService.AddTask(task);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllTasks(string? Term) 
        {
            var Task = _taskService.GetListTask(Term);
            return Ok(Task);
        }
        [HttpGet("{id}")]
        public IActionResult GetTasksById(int id)
        {
            var Task = _taskService.GetListTaskById(id);
            return Ok(Task);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask([FromBody] API2.Models.Task task, int id)
        {
            try
            {
                var checkTask = _taskService.GetListTaskById(id);
                if (checkTask == null)
                {
                    return NotFound("Task not found.");
                }
                _taskService.UpdateTask(task, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                var checkTask = _taskService.GetListTaskById(id);
                if (checkTask == null)
                {
                    return NotFound("Task not found.");
                }
                _taskService.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
