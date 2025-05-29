using FreeAdCopyAutomation.PageMethods;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace FreeAdCopyAutomation.Tests
{
    [AllureNUnit]
    class AccountSettingsTests
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;
        private HomePageMethods _homePage;
        private DashboardMethods _dashboardPage;
        private SettingsMethods _settingsPage;
        private Utilities _utilities;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Environment.BaseUrl);
            _loginPage = new LoginMethods(_driver);
            _homePage = new HomePageMethods(_driver);
            _dashboardPage = new DashboardMethods(_driver);
            _settingsPage = new SettingsMethods(_driver);
            _utilities = new Utilities(_driver);
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

        [AllureDescription("Change Username")]
        [Test]
        public void ChangeUsername()
        {
            _loginPage.ClickLoginNavbar();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword);
            _loginPage.SigninBtn();
            _dashboardPage.ClickProfileIcon();
            _dashboardPage.SelectSettingsTab();
            string username = _utilities.GenerateRandomString(10);
            _settingsPage.UpdateUsername(username);
        }
        [AllureDescription("Change Password")]
        [Test]
        public void ChangePassword()
        {
            _loginPage.ClickLoginNavbar();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword);
            _loginPage.SigninBtn();
            _dashboardPage.ToastNotify(Environment.LoginSuccessToastMessage);
            _dashboardPage.ClickProfileIcon();
            _dashboardPage.SelectSettingsTab();
            _settingsPage.UpdatePassword(Environment.ValidPassword, Environment.NewPassword, Environment.ConfirmNewPassword);
            _settingsPage.ClickUpdatePasswordButton();
            _dashboardPage.ToastNotify(Environment.PasswordMismatchToastMessage);
        }
    }
}
