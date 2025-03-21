
using BX.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BX.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthUserController> _logger;
        //private readonly IEmailSender<ApplicationUser> _emailSender;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly string? errorMessage;

        public AuthUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AuthUserController> logger, IUserStore<ApplicationUser> userStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userStore = userStore;
        }

        #region POST
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario ha iniciado sesión correctamente.");

                var user = await _userManager.FindByEmailAsync(model.Email);
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
            //else if (result.IsLockedOut)
            //{
            //    _logger.LogWarning("Cuenta bloqueada.");
            //    var blockUrl = "Account/Lockout";
            //    return BadRequest(new { error = "Cuenta bloqueada.", blockUrl });
            //}

            var errorMessage = "⚠ Error: Usuario o contraseña incorrectos.";
            return BadRequest(new { error = errorMessage });

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            var user = CreateUser();

            // Asignar el nombre completo como UserName en Identity
            await _userStore.SetUserNameAsync(user, model.FullName, CancellationToken.None);

            var emailStore = GetEmailStore();
            await emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

            // Guardar Nombre y Teléfono en Identity
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario registrado correctamente.");

                // 🔥 ASIGNAR ROL "Cliente" AUTOMÁTICAMENTE 🔥
                if (!await _userManager.IsInRoleAsync(user, "Cliente"))
                {
                    await _userManager.AddToRoleAsync(user, "Cliente");
                }

                // Confirmación de email
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = $"Account/ConfirmEmail?userId={userId}&code={code}";


                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    var confirmationURL = $"Account/RegisterConfirmation?email={model.Email}";
                    return BadRequest(new { state = "Requires account confirmation", confirmationURL });
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { success = "true", user, callbackUrl });

            }

            var identityErrors = result.Errors;
            return BadRequest(new { identityErrors });

        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return new ApplicationUser();
            }
            catch
            {
                throw new InvalidOperationException($"No se pudo crear una instancia de '{nameof(ApplicationUser)}'.");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("El sistema requiere un UserStore que soporte emails.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model) 
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                var urlToReturn = "Account/ForgotPasswordConfirmation";
                return BadRequest(new { urlToReturn });
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = $"Account/ResetPassword?code={code}";


            var passwordConfirmationUrl = "Account/ForgotPasswordConfirmation";
            return Ok(new { user, passwordConfirmationUrl, callbackUrl });
        }

        #endregion

        #region GET
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                var error = "El UserId o el Code no se encuentran disponibles. Por favor verifique";
                return BadRequest(new { error });
            }

            var user = await _userManager.FindByIdAsync(userId);
            
            if(user == null)
            {
                var error = $"No se encontro un usuario bajo el nombre de usuario{userId}";
                return NotFound(new { error });
            }

            var decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, decodedCode);

            if (result.Succeeded)
            {
                var confirmMessage = "Gracias por confirmar su correo!";
                return Ok( new { confirmMessage });
            }
            else
            {
                var errorMessage = "Hubo un error al confirmar su correo.";
                return BadRequest(new { errorMessage });
            }
        }
        #endregion
    }
}

    



    

