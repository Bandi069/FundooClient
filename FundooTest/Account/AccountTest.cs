// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LoginTest.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="tejasri"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// AccountTest is used to test the methods.
    /// </summary>
    public class AccountTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Login Test is used to test the login method in account
        /// </summary>
        [Test]
        public void LoginTest()
        {
            AccountRepository repository = new AccountRepository();
            LoginModel login = new LoginModel
            {
                Email = "radhag@gmail.com",
                Password = "radha@3716"
            };
            Assert.IsNotNull(repository.Login(login));
        }

        /// <summary>
        /// Register Test is used to test the register method in account
        /// </summary>
        [Test]
        public void RegisterTest()
        {
            RegisterModel register = new RegisterModel();
            register.FirstName = "a";
            register.LastName = "aa";
            register.Email = "aa@gmail.com";
            register.Password = "a@3716";
            AccountManager manager = new AccountManager();
            Assert.IsNotNull(manager.Register(register));
        }

        /// <summary>
        /// ForgotPassword is used to test the forgot password method in account
        /// </summary>
        [Test]
        public void ForgotPassword()
        {
            ForgotPassword forgot = new ForgotPassword();
            forgot.Email = "tejasmiley129@gmail.com";
            var result = new AccountManager();
            Assert.IsNotNull(result.ForgotPassword(forgot));
        }

        /// <summary>
        /// ResetPassword is used to test the reset password method in account
        /// </summary>
        [Test]
        public void ResetPasswordTest()
        {
            ResetPassword reset = new ResetPassword()
            {
                Email = "tejasmiely129@gmail.com",
                Password = "hello",
                NewPassword = "hell@3716",
                ConfirmPassword = "hell@3716"
            };
            AccountManager manager = new AccountManager();
            Assert.IsNotNull(manager.ResetPassword(reset));
        }

        /// <summary>
        /// Email Login Test is used to test the email login in account
        /// </summary>
        [Test]
        public void EmailLoginTest()
        {
            LoginModel login = new LoginModel()
            {
                Email = "tejasmiley129@gmail.com",
                Password = "hell@3716"
            };
            AccountManager manager = new AccountManager();
            Assert.IsNotNull(manager.EmailLogin(login));
        }

        /// <summary>
        /// Face Book Login is used to test the facebook login in account
        /// </summary>
        [Test]
        public void FaceBookLoginTest()
        {
            LoginModel login = new LoginModel()
            {
                Email = "tejasmiley129@gmail.com",
                Password = "hello@3716"
            };
            AccountManager manager = new AccountManager();
            Assert.IsNotNull(manager.FaceBookLogin(login));
        }
    }

}