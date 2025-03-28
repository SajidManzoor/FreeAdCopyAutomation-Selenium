using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeAdCopyAutomation.PageMethods;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FreeAdCopyAutomation.Tests
{
    class AccountSettings
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;
        private HomePageMethods _homePage;
        private DashboardMethods _dashboardPage;
        private SettingsMethods _settingsPage;
        private Utilities _utilities;
        private List<Dictionary<string, string>> _testData;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://freeadcopy.com/"); 
            _loginPage = new LoginMethods(_driver);
            _homePage = new HomePageMethods(_driver);
            _dashboardPage=new DashboardMethods(_driver);
            _settingsPage = new SettingsMethods(_driver);
            _utilities = new Utilities();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Test]
        public void ChangeUsername()
        {
            // Login to app and Click on the template from side bar
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail("sajidfree7727@gmail.com");
            _loginPage.EnterPassword("webdir123R");
            _loginPage.SigninBtn();
            _dashboardPage.ClickProfileIcon();
            _dashboardPage.SelectSettingsTab();
            string username = _utilities.GenerateRandomString(10);
            _settingsPage.UpdateUsername(username);
        }
        [Test]
        public void ChangePassword()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail("sajidfree7727@gmail.com");
            _loginPage.EnterPassword("webdir123R");
            _loginPage.SigninBtn();
            _dashboardPage.ToastNotify("Login successfully");
            _dashboardPage.ClickProfileIcon();
            _dashboardPage.SelectSettingsTab();
            //_settingsPage.PasswordSettingTab();
            _settingsPage.UpdatePassword("webdir123R", "asdfghj","qwrtyuz");
            _settingsPage.ClickUpdatePasswordButton();
            _dashboardPage.ToastNotify("Password doesn't match");
        }
    }
}
