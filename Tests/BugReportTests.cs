using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using System.IO; // For reading test data
using FreeAdCopyAutomation.PageMethods;
using FreeAdCopyAutomation.PageObjects;

namespace FreeAdCopyAutomation.Tests
{
    [TestFixture]
    public class BugReportTests
    {
        private IWebDriver _driver;
        private HomePageMethods _homePage;
        private LoginMethods _loginPage;
        private DashBoardObjects _dashboard;
        private DashboardMethods _dashboardMethods;
        private List<Dictionary<string, string>> _testData;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options); 
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Environment.BaseUrl);
            _homePage = new HomePageMethods(_driver);
            _loginPage = new LoginMethods(_driver);
            _dashboard = new DashBoardObjects(_driver);
            _dashboardMethods = new DashboardMethods(_driver);
            //_testData = LoadTestData("testData.csv"); // Adjust file path if needed
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Test]
        public void SubmitBugReportTest()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword);
            _loginPage.SigninBtn();

            _dashboardMethods.ClickProfileIcon();
            _dashboardMethods.SelectReportBugTab();

            _dashboardMethods.SubmitBugReport(Environment.BugDetail);

        }

    }
}
