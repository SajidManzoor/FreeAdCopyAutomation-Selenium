using FreeAdCopyAutomation.PageMethods;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Allure.NUnit;

namespace FreeAdCopyAutomation.Tests
{
    [AllureNUnit]
    class AccountSettings
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
            options.AddArgument("--headless");
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
            //_driver.Quit();
        }

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
