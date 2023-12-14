using Microsoft.AspNetCore.Mvc;

namespace API2.Repositories
{
    public interface ITaskRepository
    {
        void AddTask([FromBody] Models.Task task);
        List<Models.Task> GetListTask(string? term);
        Models.Task GetListTaskById(int id);
        void UpdateTask([FromBody] Models.Task task,int id);
        void DeleteTask(int id);
    }
}
