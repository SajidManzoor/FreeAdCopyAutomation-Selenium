using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FreeAdCopyAutomation.PageMethods;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace FreeAdCopyAutomation.Tests
{
    [TestFixture]
    [AllureNUnit]
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
        [AllureDescription("Login")]
        [AllureIssue("Issue-1")]
        [AllureTms("TMS-1")]

        public void ValidLoginTest()
        {
            _loginPage.ClickLoginNavbar();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword); 
            _loginPage.SigninBtn();
            _loginPage.ToastNotification(Environment.LoginSuccessToastMessage);
            _loginPage.LoginValidation();
            _loginPage.VerifyLoginToast();
        }

        [Test]
        [AllureDescription("Invalid Login")]
        [AllureIssue("Issue-2")]
        [AllureTms("TMS-2")]
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
