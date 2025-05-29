using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using FreeAdCopyAutomation.PageMethods;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;


namespace FreeAdCopyAutomation.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Environment.BaseUrl);
            _loginPage = new LoginMethods(_driver);
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = _driver.TakeScreenshot();
                var screenshotPath = $"{TestContext.CurrentContext.Test.Name}.png";
                screenshot.SaveAsFile(screenshotPath);
                AllureApi.AddAttachment("Screenshot on Failure", "image/png", screenshotPath);
            }
            _driver.Quit();
        }

        [Test]
        [AllureDescription("Login")]
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
        public void InvalidLoginTest()
        {
            _loginPage.ClickLoginNavbar();
            _loginPage.SigninBtn();
            _loginPage.ToastNotification(Environment.AuthenticationErrorMessage);
        }
    }
}
