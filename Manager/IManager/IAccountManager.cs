
namespace Manager.IManager
{
    using Model.UserModel;
    using System.Threading.Tasks;

    /// <summary>
    /// IAccountManager interface for creating abstract methods
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        Task<bool> Register(RegisterModel register);

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
         string Login(LoginModel login);

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="forgotPassword">The forgot password.</param>
        /// <returns></returns>
        Task<string> ForgotPassword(ForgotPassword forgotPassword);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        Task<string> ResetPassword(ResetPassword reset);

        /// <summary>
        /// Emails the login.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        Task<string> EmailLogin(LoginModel loginModel);

        /// <summary>
        /// Faces the book login.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        Task<string> FaceBookLogin(LoginModel loginModel);
    }
}