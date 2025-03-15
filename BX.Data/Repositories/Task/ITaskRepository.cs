
namespace BX.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<bool> CreateTaskAsync(Task task);
        Task<bool> DeleteTaskAsync(Task task);
        Task<bool> ExistsAsync(Task task);
        Task<Task> GetTaskAsync(int id);
        Task<Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Task>> GetTasksAsync();
        Task<bool> UpdateTaskAsync(Task task);
    }
}