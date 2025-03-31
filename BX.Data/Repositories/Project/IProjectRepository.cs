using BX.Models;

namespace BX.Data.Repositories
{
    public interface IProjectRepository
    {
        Task<bool> CreateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(Project project);
        Task<bool> ExistsAsync(Project project);
        Task<Project> GetProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<bool> UpdateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetFilteredProjectsAsync(string searchText, string status);
        Task<Project> GetProjectByPropertyId(int projectId);
    }
}