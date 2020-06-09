
namespace Repository.IRepository
{
    using Model.UserModel;
    using System.Threading.Tasks;

    /// <summary>
    /// IAccount Respository consists of all abstract methods
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Registers the account.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        Task<int> RegisterAccount(RegisterModel register);

        /// <summary>
        /// Logins the specified user.
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
        /// Email login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        Task<string> EmailLogin(LoginModel login);

        /// <summary>
        /// Facebook login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        Task<string> FaceBookLogin(LoginModel login);
    }
}