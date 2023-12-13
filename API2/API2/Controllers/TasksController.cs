using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _taskService.AddTask(task);
            return Ok(task);
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
            _taskService.UpdateTask(task, id);
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
