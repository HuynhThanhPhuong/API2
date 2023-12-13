using API2.Models;
using API2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API2.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void AddTask([FromBody] API2.Models.Task task)
        {
            _taskRepository.AddTask(task);
        }
        public List<Models.Task> GetListTask(string? Term)
        {
            return _taskRepository.GetListTask(Term);
        }
        public List<Models.Task> GetListTaskById(int id)
        {
            return _taskRepository.GetListTaskById(id);
        }
        public void UpdateTask([FromBody] API2.Models.Task task,int id)
        {
            _taskRepository.UpdateTask(task, id);
        }
        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }
    }
}
