using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffInTasksController : ControllerBase
    {
        private readonly IStaffInTaskService _staffInTaskService;
        private readonly IStaffService _staffService;
        private readonly ITaskService _taskService;

        public StaffInTasksController(IStaffInTaskService staffInTaskService, IStaffService staffService, ITaskService taskService)
        {
            _staffInTaskService = staffInTaskService;
            _staffService = staffService;
            _taskService = taskService;
        }
        [HttpPost]
        public IActionResult AddStaffInTask([FromBody] StaffInTask staffInTask)
        {
            try
            {
                var Staff = _staffService.GetStaffListByID(staffInTask.Idstaff);
                if (Staff == null)
                {
                    return NotFound("Staff is not Exist!");
                }
                var Task = _taskService.GetListTaskById(staffInTask.Idstask);
                if (Task == null)
                {
                    return NotFound("Task is not Exist!");
                }
                _staffInTaskService.AddStaffInTask(staffInTask);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllStaffInTask()
        {
            var Staff = _staffInTaskService.GetStaffInTaskList();
            return Ok(Staff);
        }
        [HttpGet("{id}")]
        public IActionResult GetStaffInTaskByID(int id)
        {
            var StaffinTask = _staffInTaskService.GetStaffInTaskByID(id);
            return Ok(StaffinTask);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStaff([FromBody] StaffInTask staffInTask, int id)
        {
            try
            {
                var Staff = _staffService.GetStaffListByID(staffInTask.Idstaff);
                if (Staff == null)
                {
                    return NotFound("Staff is not Exist!");
                }
                var Task = _taskService.GetListTaskById(staffInTask.Idstask);
                if (Task == null)
                {
                    return NotFound("Task is not Exist!");
                }
                _staffInTaskService.UpdateStaffTask(staffInTask, id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaffInTask(int id)
        {
            try
            {
                var checkStaff = _staffInTaskService.GetStaffInTaskByID(id);
                if (checkStaff == null)
                {
                    return NotFound("StaffInTask not found.");
                }
                _staffInTaskService.DeleteStaffInTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
