using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Services
{
    public interface IStaffInTaskService
    {
        void AddStaffInTask([FromBody] StaffInTask staffInTask);
        List<StaffInTask> GetStaffInTaskList();
        StaffInTask GetStaffInTaskByID(int id);
        void UpdateStaffTask([FromBody] StaffInTask staffInTask, int id);
        void DeleteStaffInTask(int id);
    }
}
