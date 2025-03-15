using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BX.Business.Managers;
using BX.Models;

namespace BX.Backend.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> FindPropertyById(int id)
        {
            var property = await _propertyManager.GetPropertyAsync(id);
            if (property != null)
                return Ok(property);
            return NotFound();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchText, string status)
        {
            var properties = await _propertyManager.GetFilteredPropertiesAsync(searchText, status);
            if (properties != null)
                return Ok(properties);
            return Empty;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            var result = await _propertyManager.CreatePropertyAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Property property)
        {
            var result = await _propertyManager.UpdatePropertyAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region PATCH
        [HttpPatch]
        public async Task<IActionResult> UpdateStatus([FromBody] Property property)
        {
            var result = await _propertyManager.UpdatePropertyStatusAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDetails([FromBody] Property property)
        {
            var result = await _propertyManager.UpdatePropertyDetailsAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Property property)
        {
            var result = await _propertyManager.DeletePropertyAsync(property);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion
    }
}
