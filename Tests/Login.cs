using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FreeAdCopyAutomation.PageMethods;
using FreeAdCopyAutomation.PageObjects;

namespace FreeAdCopyAutomation.Tests
{
    [TestFixture]
    public class Login
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options); 
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Environment.BaseUrl);
            _loginPage = new LoginMethods(_driver);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Test]
        public void ValidLoginTest()
        {
            _loginPage.ClickLoginNavbar();
            //_loginPage.EnterEmail("sajidfree7727@gmail.com");
            _loginPage.EnterEmail(Environment.ValidEmail);
            //_loginPage.EnterPassword("webdir123R");
            _loginPage.EnterPassword(Environment.ValidPassword); 
            _loginPage.SigninBtn();
            //_loginPage.ToastNotification("Login successfully");
            _loginPage.ToastNotification(Environment.LoginSuccessToastMessage);
            _loginPage.LoginValidation();
            _loginPage.VerifyLoginToast();
        }

        [Test]
        public void InvalidLoginTest()
        {
            _loginPage.ClickLoginNavbar();
            _loginPage.EnterEmail(Environment.InValidEmail); 
            _loginPage.EnterPassword(Environment.ValidPassword); 
            _loginPage.SigninBtn();
            _loginPage.ToastNotification(Environment.AuthenticationErrorMessage);
        }
    }
}
