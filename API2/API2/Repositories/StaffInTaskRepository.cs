using API2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API2.Repositories
{
    public class StaffInTaskRepository : IStaffInTaskRepository
    {
        private readonly Api2Context _Context;
        public StaffInTaskRepository(Api2Context context)
        {
            _Context = context;
        }
        public void AddStaffInTask([FromBody] StaffInTask staffInTask)
        {
            try
            {
                _Context.StaffInTasks.Add(staffInTask);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public List<StaffInTask> GetStaffInTaskList()
        {
            return _Context.StaffInTasks.ToList();
        }
        public StaffInTask GetStaffInTaskByID(int id)
        {
            var StaffTask = _Context.StaffInTasks
              .FirstOrDefault(p => p.Id == id);
            return StaffTask;
        }
        public void UpdateStaffInTask([FromBody] StaffInTask staffInTask, int id)
        {
            try
            {
                var existingStaffTask = _Context.StaffInTasks.FirstOrDefault(s => s.Id == id);
                if (existingStaffTask != null)
                {
                    existingStaffTask.Idstaff = staffInTask.Idstaff;
                    existingStaffTask.Idstask = staffInTask.Idstask;
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public void DeleteStaffInTask(int id)
        {
            try
            {
                var existingStaffTask = _Context.StaffInTasks.FirstOrDefault(s => s.Id == id);
                if (existingStaffTask != null)
                {
                    _Context.Remove(existingStaffTask);
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi xóa!");
            }
        }
    }
}
