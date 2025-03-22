using BX.Business.Managers;
using BX.Models;
using BX.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BX.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        #region DEPENDENCY INJECTION
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projects = await _projectManager.GetProjectsAsync();
            if (projects != null)
                return Ok(projects);
            return Empty;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var project = await _projectManager.GetProjectByIdAsync(id);
            if (project != null)
                return Ok(project);
            return NotFound();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? searchText, string? status)
        {
            var properties = await _projectManager.GetFilteredProjectsAsync(searchText, status);
            if (properties != null)
                return Ok(properties);
            return Empty;
        }
        #endregion

        #region POST
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProjectDto project)
        {
            var result = await _projectManager.CreateProjectAsync(project);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region PUT
        #endregion

        #region PATCH
        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] Project project)
        {
            var result = await _projectManager.UpdateProjectAsync(project);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region DELETE
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectManager.DeleteProjectAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion
    }
}
