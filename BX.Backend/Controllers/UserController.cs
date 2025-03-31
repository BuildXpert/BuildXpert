using BX.Business.Managers;
using BX.Models;
using BX.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BX.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        #region DEPENDENCY INJECTION
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region GET
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userManager.GetUsersAsync();
            if (users != null)
                return Ok(users);
            return Empty;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            var user = await _userManager.GetUserByIdAsync(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? searchText, string? status)
        {
            var users = await _userManager.GetFilteredUsersAsync(searchText, status);
            if (users != null)
                return Ok(users);
            return Empty;
        }
        #endregion

        #region POST
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ApplicationUser user)
        {
            var result = await _userManager.CreateUserAsync(user);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion

        #region PUT
        #endregion

        #region PATCH
        //[HttpPatch("update")]
        //public async Task<IActionResult> Update([FromBody] User user)
        //{
        //    var result = await _userManager.UpdateUserAsync(user);
        //    if (result)
        //        return Ok();
        //    return BadRequest();
        //}
        #endregion

        #region DELETE
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userManager.DeleteUserAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
        #endregion
    }

}

