using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Repositories
{
    public interface IStaffInTaskRepository
    {
        void AddStaffInTask([FromBody] StaffInTask staffInTask);
        List<StaffInTask> GetStaffInTaskList();
        StaffInTask GetStaffInTaskByID(int id);
        void UpdateStaffInTask([FromBody] StaffInTask staffInTask, int id);
        void DeleteStaffInTask(int id);
    }
}
