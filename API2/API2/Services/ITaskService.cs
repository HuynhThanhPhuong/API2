using Microsoft.AspNetCore.Mvc;

namespace API2.Services
{
    public interface ITaskService
    {
        void AddTask([FromBody] API2.Models.Task task);
        List<Models.Task> GetListTask(string? Term);
        List<Models.Task> GetListTaskById(int id);
        void UpdateTask([FromBody] API2.Models.Task task, int id);
        void DeleteTask(int id);
    }
}
