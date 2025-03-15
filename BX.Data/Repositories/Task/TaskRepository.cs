using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;

namespace BX.Data.Repositories
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Task>> GetTasksAsync()
        {
            return await ReadAsync();
        }

        public async Task<Task> GetTaskAsync(int id)
        {
            return (await ReadAsync()).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Task> GetTaskByIdAsync(int id)
        {
            return await ReadOneAsync(id);
        }

        public async Task<bool> CreateTaskAsync(Task task)
        {
            return await CreateAsync(task);
        }

        public async Task<bool> UpdateTaskAsync(Task task)
        {
            return await UpdateAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(Task task)
        {
            return await DeleteAsync(task);
        }

        public async Task<bool> ExistsAsync(Task task)
        {
            return await ExistsAsync(task);
        }


    }
}
