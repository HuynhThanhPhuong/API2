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
            try
            {
                _staffService.AddStaff(staff);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAllStaffByID(int id)
        {
            var Staff = _staffService.GetStaffListByID(id);
            return Ok(Staff);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStaff([FromBody] Staff staff, int id)
        {
            try
            {
                var checkStaff = _staffService.GetStaffListByID(id);
                if (checkStaff == null)
                {
                    return NotFound("Staff not found.");
                }
                _staffService.UpdateStaff(staff, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            try
            {
                var checkStaff = _staffService.GetStaffListByID(id);
                if (checkStaff == null)
                {
                    return NotFound("Staff not found.");
                }
                _staffService.DeleteStaff(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
