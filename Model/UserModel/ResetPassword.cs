
using System.ComponentModel.DataAnnotations;

namespace Model.UserModel
{
    /// <summary>
    /// Reset Password class is used to reset the existing password
    /// </summary>
    public class ResetPassword
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// Creates new password.
        /// </summary>
        private string newPassword;

        /// <summary>
        /// The confirm password
        /// </summary>
        private string confirmPassword;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
         [Required, DataType(DataType.Password)]
        public string NewPassword { get => newPassword; set => newPassword = value; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [Required, Compare("Password", ErrorMessage = "Passwords does not match"),
           DataType(DataType.Password)]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}