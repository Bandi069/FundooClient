
namespace Manager.Manager
{
    using Model.UserModel;
    using Repository.IRepository;
    using System.Threading.Tasks;

    /// <summary>
    /// Account Manager class implements IAccount Manager interface
    /// </summary>
    /// <seealso cref="Manager.IManager.IAccountManager" />
    public class AccountManager : IManager.IAccountManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IAccountRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManager"/> class.
        /// </summary>
        public AccountManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManager"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        public AccountManager(IAccountRepository accountRepository)
        {
            this.repository = accountRepository;
        }

        /// <summary>
        /// Email login.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        public async Task<string> EmailLogin(LoginModel loginModel)
        {
            return await this.repository.EmailLogin(loginModel);
        }

        /// <summary>
        /// Facebook login.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        public async Task<string> FaceBookLogin(LoginModel loginModel)
        {
            return await this.repository.FaceBookLogin(loginModel);
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="forgotPassword">The forgot password.</param>
        /// <returns></returns>
        public async Task<string> ForgotPassword(ForgotPassword forgotPassword)
        {
            return await this.repository.ForgotPassword(forgotPassword);
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public  string Login(LoginModel login)
        {
            var a =  this.repository.Login(login);
            return a;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns></returns>
        public async Task<bool> Register(RegisterModel register)
        {
           await this.repository.RegisterAccount(register);
            return true;
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>
        public async Task<string> ResetPassword(ResetPassword reset)
        {
           return await this.repository.ResetPassword(reset);
        }
    }
}