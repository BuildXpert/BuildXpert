using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;
using Microsoft.EntityFrameworkCore;

namespace BX.Data.Repositories
{
    public class ProjectRepository : RepositoryBase<Project,int>, IProjectRepository
    {
        public ProjectRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await ReadAsync();
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return (await ReadAsync()).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await ReadOneAsync(id);
        }

        public async Task<bool> CreateProjectAsync(Project project)
        {
            return await CreateAsync(project);
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            return await UpdateAsync(project);
        }

        public async Task<bool> DeleteProjectAsync(Project project)
        {
            return await DeleteAsync(project);
        }

        public async Task<bool> ExistsAsync(Project project)
        {
            return await ExistsAsync(project);
        }

        public async Task<IEnumerable<Project>> GetFilteredProjectsAsync(string searchText, string status)
        {
            IQueryable<Project> query = ReadQueriableAsync();
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(p => p.Name.Contains(searchText) || p.Description.Contains(searchText));
            }

            if (!string.IsNullOrEmpty(status))
            {
                //query = query.Where(p => p.Status == status);
            }
            return await query.ToListAsync();
        }

        public async Task<Project> GetProjectByPropertyId(int projectId)
        {
            IQueryable<Project> queryableProject = ReadQueriableAsync();
            queryableProject = queryableProject.Where(p => p.PropertyId == projectId);
            var result = await queryableProject.ToListAsync();
            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }
    }
}
