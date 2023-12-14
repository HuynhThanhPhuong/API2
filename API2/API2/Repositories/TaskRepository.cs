using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Api2Context _Context;
        public TaskRepository(Api2Context context)
        {
            _Context = context;
        }
        public void AddTask([FromBody] Models.Task task)
        {
            try
            {
                _Context.Tasks.Add(task);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public List<Models.Task> GetListTask(string? term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return _Context.Tasks.ToList();
            }
            var filteredTask = _Context.Tasks
              .Where(p => p.Name.ToLower().Contains(term.ToLower()))
              .ToList();

            return filteredTask;
        }
        public Models.Task GetListTaskById(int id)
        {
            var lstTask = _Context.Tasks
              .FirstOrDefault(p => p.Id == id);

            return lstTask;
        }
        public void UpdateTask([FromBody] Models.Task task,int id)
        {
            try
            {
                var checkTask = _Context.Tasks.FirstOrDefault(p => p.Id == id);
                if (checkTask != null)
                {
                    checkTask.Name = task.Name;
                    checkTask.Idparent = task.Idparent;
                    checkTask.Label = task.Label;
                    checkTask.Type = task.Type;
                    checkTask.StartDate = task.StartDate;
                    checkTask.EndDate = task.EndDate;
                    checkTask.Duration = task.Duration;
                    checkTask.Progress = task.Progress;
                    checkTask.IsUnscheduled = task.IsUnscheduled;
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public void DeleteTask(int id)
        {
            try
            {
                var checkTask = _Context.Tasks.FirstOrDefault(p => p.Id == id);
                if (checkTask != null)
                {
                    _Context.Remove(checkTask);
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi xóa!");
            }
        }
    }
}
