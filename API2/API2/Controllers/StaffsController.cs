using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        public IActionResult GetAllStaff(string? term)
        {
            var Staff = _staffService.GetStaffList(term);
            return Ok(Staff);
        }
        [HttpPost]
        public IActionResult AddStaff([FromBody] Staff staff)
        {
            _staffService.AddStaff(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAllStaffByID(int id)
        {
            var Staff = _staffService.GetStaffListByID(id);
            return Ok(Staff);
        }
        [HttpPut]
        public IActionResult UpdateStaff([FromBody] Staff staff)
        {
            _staffService.UpdateStaff(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            _staffService.DeleteStaff(id);
            return Ok();
        }
    }
}
