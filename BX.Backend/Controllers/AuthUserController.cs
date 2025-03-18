
using BX.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace BX.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthUserController> _logger;
        private readonly string? errorMessage;

        public AuthUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AuthUserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel input)
        {
        var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario ha iniciado sesión correctamente.");

                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();

                    // Redirigir según el rol del usuario
                    string redirectUrl = role switch
                    {
                        "Cliente" => "/dashboard-cliente",
                        "MOBS" => "/dashboard-mob",
                        "Admin" => "/dashboard-admin",
                        "Bancario" => "/dashboard-bancario",
                        _ => "/"
                    };

                    // Redirección
                    return Ok(new { success = "true", redirectUrl });
                }
            }
            //else if (result.RequiresTwoFactor)
            //{
            //    //NavigationManager.NavigateTo("Account/LoginWith2fa");
            //}
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("Cuenta bloqueada.");
                //NavigationManager.NavigateTo("Account/Lockout");
                return BadRequest(new { error = "Cuenta bloqueada." });
            }

            //errorMessage = "⚠ Error: Usuario o contraseña incorrectos.";
            return BadRequest(new { error = "Usuario o contraseña incorrectos." });
            
        }


    }
}
