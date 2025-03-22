using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BX.Business.Managers;
using BX.Models;

namespace BX.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        #region DEPENDENCY INJECTION
        private readonly IPropertyManager _propertyManager;

        public PropertyController(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var properties = await _propertyManager.GetPropertiesAsync();
            if (properties != null) 
                return Ok(properties);
            return Empty;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var property = await _propertyManager.GetPropertyByIdAsync(id);
            if (property != null)
                return Ok(property);
            return NotFound();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? searchText, string? status)
        {
            var properties = await _propertyManager.GetFilteredPropertiesAsync(searchText, status);
            if (properties != null)
                return Ok(properties);
            return Empty;
        }
        #endregion

        #region POST
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            var result = await _propertyManager.CreatePropertyAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region PUT
        #endregion

        #region PATCH
        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] Property property)
        {
            var result = await _propertyManager.UpdatePropertyAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region DELETE
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _propertyManager.DeletePropertyAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion
    }
}
