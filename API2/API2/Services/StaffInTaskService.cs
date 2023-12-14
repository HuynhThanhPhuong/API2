using API2.Models;
using API2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API2.Services
{
    public class StaffInTaskService : IStaffInTaskService
    {
        private readonly IStaffInTaskRepository _staffInTaskRepository;
        public StaffInTaskService(IStaffInTaskRepository staffInTaskRepository)
        {
            _staffInTaskRepository = staffInTaskRepository;
        }
        public void AddStaffInTask([FromBody] StaffInTask staffInTask)
        {
            _staffInTaskRepository.AddStaffInTask(staffInTask);
        }
        public List<StaffInTask> GetStaffInTaskList()
        {
            return _staffInTaskRepository.GetStaffInTaskList();
        }
        public StaffInTask GetStaffInTaskByID(int id)
        {
            return _staffInTaskRepository.GetStaffInTaskByID(id);
        }
        public void UpdateStaffTask([FromBody] StaffInTask staffInTask, int id)
        {
            _staffInTaskRepository.UpdateStaffInTask(staffInTask, id);
        }
        public void DeleteStaffInTask(int id)
        {
            _staffInTaskRepository.DeleteStaffInTask(id);
        }
    }
}
