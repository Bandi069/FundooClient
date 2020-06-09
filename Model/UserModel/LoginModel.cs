
namespace Model.UserModel
{
    /// <summary>
    /// Login Model class is used to get and set email ans password properties
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// The password
        /// </summary>
        private string password;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}