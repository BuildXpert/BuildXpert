using BX.Data.Repositories;
using BX.Models;
using BX.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BX.Business.Managers
{
    public class ProjectManager : IProjectManager
    {
        #region DEPENDENCY INJECTION
        private readonly IProjectRepository _projectRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IUserRepository _userRepository;
        public ProjectManager(IProjectRepository projectRepository, 
            IPropertyRepository propertyRepository, 
            IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region GET
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects = await _projectRepository.GetProjectsAsync();
            if (projects == null) return projects;
            foreach (var project in projects)
            {
                await ProcessVirtualReferences(project);
            }
            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null) return project;
            await ProcessVirtualReferences(project);
            return project;
        }
        public async Task<IEnumerable<Project>> GetFilteredProjectsAsync(string searchText, string status)
        {
            return await _projectRepository.GetFilteredProjectsAsync(searchText, status);
        }
        #endregion

        #region POST
        public async Task<bool> CreateProjectAsync(ProjectDto input)
        {
            var property = input.ToProperty();
            if (input.PropertyId == null)
            {
                if (!await _propertyRepository.CreatePropertyAsync(property))
                {
                    return false;
                }
            }
            var project = input.ToProject();
            project.PropertyId = property.Id;
            return await _projectRepository.CreateProjectAsync(project);
        }
        #endregion

        #region PUT
        #endregion

        #region PATCH
        public async Task<bool> UpdateProjectAsync(Project newProject)
        {
            Project existingProject = await _projectRepository.GetProjectByIdAsync(newProject.Id);
            if (existingProject == null) return false;
            UpdateProjectAttributes(existingProject, newProject);
            return await _projectRepository.UpdateProjectAsync(existingProject);
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteProjectAsync(int id)
        {
            Project project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return false;
            }
            return await _projectRepository.DeleteProjectAsync(project);
        }
        #endregion

        #region Helper Methods
        private void UpdateProjectAttributes(Project existingProject, Project project)
        {
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.Property.Price = project.Property.Price;
            existingProject.Status = project.Status;
            existingProject.CreatedDate = project.CreatedDate;
            existingProject.Property.ConstructionType = project.Property.ConstructionType;
            existingProject.Property.Province = project.Property.Province;
            existingProject.Property.Canton = project.Property.Canton;
            existingProject.Property.ConstructionSize = project.Property.ConstructionSize;
            existingProject.Property.LandSize = project.Property.LandSize;
            existingProject.Property.Bedrooms = project.Property.Bedrooms;
            existingProject.Property.Bathrooms = project.Property.Bathrooms;
            existingProject.Property.Price = project.Property.Price;
            existingProject.Property.Floors = project.Property.Floors;
            existingProject.Property.HasGarage = project.Property.HasGarage;
            existingProject.Property.GarageCapacity = project.Property.GarageCapacity;
            existingProject.Property.IsCondominium = project.Property.IsCondominium;
        }

        private async Task ProcessVirtualReferences(Project project)
        {
            project.Property = await _propertyRepository.GetPropertyByIdAsync(project.PropertyId);
            project.Property.Project = null;
            project.Admin = await _userRepository.GetUserByIdAsync(project.AdminId);
            project.Admin.Projects = null;
            project.Admin.ProjectsAsAdmin = null;
            project.Client = await _userRepository.GetUserByIdAsync(project.ClientId);
            project.Client.Projects= null;
            project.Client.ProjectsAsAdmin = null;
        }
        #endregion
    }
}
