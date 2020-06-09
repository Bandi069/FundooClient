
namespace FundooApp.Controllers
{
    using Manager.IManager;
    using Microsoft.AspNetCore.Mvc;
    using Model.UserModel;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// AccountController class extends ControllerBase
    /// </summary>
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager accountManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public AccountController(IAccountManager manager)
        {
            this.accountManager = manager;
        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody]RegisterModel register)
        {
            try
            {
                var res = await this.accountManager.Register(register);
                return Ok(new { res });
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Logins the specified login details.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            try
            {
                var result = this.accountManager.Login(loginModel);
                if (result != null)
                {
                    return Ok(new { Token = result });
                }
                else
                {
                    return BadRequest("invalid credentials");
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Forgot password.
        /// </summary>
        /// <param name="forgotPassword">The forgot password.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("forget")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPassword forgotPassword)
        {
            try
            {

               // string url = Url.Action("resetPassword", "", new { email = forgotPassword.Email }, Request.Scheme);
                var result = await this.accountManager.ForgotPassword( forgotPassword);

                return Ok(result);
            }
            ///localhost//api/reset/email=a@gmail.com
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("reset")]
        public async Task<IActionResult> ResetPassword(ResetPassword reset)
        {
            try
            {
                var result = await this.accountManager.ResetPassword(reset);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Email login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("emailLogin")]
        public async Task<IActionResult> EmailLogin([FromBody]LoginModel login)
        {
            try
            {
                var result = await this.accountManager.EmailLogin(login);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Facebook login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("faceBookLogin")]
        public async Task<IActionResult> FaceBookLogin([FromBody]LoginModel login)
        {
            try
            {
                var result = await this.accountManager.FaceBookLogin(login);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}