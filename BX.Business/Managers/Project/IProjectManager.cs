using BX.Models;
using BX.Models.DTO;

namespace BX.Business.Managers
{
    public interface IProjectManager
    {
        Task<bool> CreateProjectAsync(ProjectDto project);
        Task<bool> DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetFilteredProjectsAsync(string searchText, string status);
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<bool> UpdateProjectAsync(Project newProject);
    }
}