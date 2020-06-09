
namespace Repository.RepositoryClasses
{
    using Experimental.System.Messaging;
    using global::Repository.Context;
    using global::Repository.IRepository;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Model.UserModel;
    using StackExchange.Redis;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountRepository
    {
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;
        public AccountRepository(UserContext userContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.userContext = userContext;
        }

        public AccountRepository()
        {
        }

        public async Task<string> EmailLogin(LoginModel login)
        {
            var result = this.userContext.Accountregister.Where(option => option.Email == login.Email).SingleOrDefault();
            if (result != null)
            {
                var key = configuration["Jwt:secretKey"];
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var signInCr = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:url"],
                    audience: configuration["Jwt:url"],
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signInCr);
                var securityToken = new JwtSecurityTokenHandler().WriteToken(token);
                var cacheKey = login.Email;
                ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase data = multiplexer.GetDatabase();
                data.StringSet(cacheKey, token.ToString());
                data.StringGet(cacheKey);
                result.Status = true;
                await this.userContext.SaveChangesAsync();
                return securityToken;
            }
            return default;
        }

        public async Task<string> FaceBookLogin(LoginModel login)
        {
            var result = this.userContext.Accountregister.Where(option => option.Email == login.Email).SingleOrDefault();
            if (result != null)
            {
                var key = configuration["Jwt:secretKey"];
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var signInCr = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:url"],
                    audience: configuration["Jwt:url"],
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signInCr);
                var securityToken = new JwtSecurityTokenHandler().WriteToken(token);
                var cacheKey = login.Email;
                ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase data = multiplexer.GetDatabase();
                data.StringSet($"cacheKey", token.ToString());
                data.StringGet($"cacheKey");
                result.Status = true;
                await this.userContext.SaveChangesAsync();
                return securityToken;
            }
            return default;
        }

        public async Task<string> ForgotPassword(ForgotPassword forgotPassword)
        {
            string email = forgotPassword.Email;
            var user = CheckEmail(forgotPassword.Email);
            if (user == true)
            {
                string Message = forgotPassword.Email;
                MessageQueue Myqueue;

                if (MessageQueue.Exists(@".\private$\Myqueue"))
                {
                    Myqueue = new MessageQueue(@".\private$\Myqueue");
                }
                else
                {
                    Myqueue = MessageQueue.Create(@".\private$\Myqueue");
                }
                Message message = new Message();
                message.Formatter = new BinaryMessageFormatter();
                message.Body = user;
                message.Label = "MsmqMessage";
                if (Message.Contains(email))
                {
                    message.Priority = MessagePriority.High;
                }
                else
                {
                    message.Priority = MessagePriority.Low;
                }
                var fromemailaddress = new MailAddress("tejasmiley129@gmail.com");
                var Password = "9553302822";
                var toEmailaddress = new MailAddress(forgotPassword.Email);
                string subject = "Reset Password";
                string body = "To reset your password click the  given link :- " +  "http://localhost:4200/resetPassword/";
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromemailaddress.Address, Password)
                };
                using (var messages = new MailMessage(fromemailaddress, toEmailaddress)
                {
                    Subject = subject,
                    Body = body
                })
                    try
                    {
                        Myqueue.Send(Message);

                        smtp.Send(messages);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                await Task.Run(() => this.userContext.SaveChangesAsync());
                return "Sucess";
            }
            return null;

        }
        public Task<int> RegisterAccount(RegisterModel register)
        {
            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Password = register.Password
            };
            registerModel.Status = true;
            var rrr = this.userContext.Accountregister.Add(register);
            var result = this.userContext.SaveChanges();
            return Task.Run(() => result);
        }

        public string Login(LoginModel login)
        {
            if (CheckEmail(login.Email))
            {
                if (CheckPassword(login.Email, login.Password))
                {
                    //var tokenDescriptor = new SecurityTokenDescriptor
                    //{
                    //    Subject = new ClaimsIdentity(new Claim[]
                    //    {
                    //           new Claim("Email", login.Email),
                    //            new Claim("Password",login.Password)
                    //    }),
                    //    Expires = DateTime.UtcNow.AddDays(1),
                    //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    //};
                    var key = configuration["Jwt:secretKey"];
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var signInCr = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:url"],
                        audience: configuration["Jwt:url"],
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signInCr);
                    var securityToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return securityToken;
                }
            }
            return "invalid";
        }

        public bool CheckEmail(string email)
        {
            var result = userContext.Accountregister.Where(option => option.Email == email).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPassword(string email, string password)
        {
            var result = userContext.Accountregister.Where(option => option.Email == email && option.Password == password).SingleOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> ResetPassword(ResetPassword reset)
        {
            string email = reset.Email;
            string password = reset.NewPassword;
            RegisterModel model = this.userContext.Accountregister.Where<RegisterModel>(option =>
              option.Email == email).SingleOrDefault();
            if (model != null)
            {
                string pwd = reset.ConfirmPassword;
                model.Password = pwd;
                this.userContext.Update(model);
                await Task.Run(() => this.userContext.SaveChangesAsync());
                return "success";
            }
            return null;
        }
    }

}
