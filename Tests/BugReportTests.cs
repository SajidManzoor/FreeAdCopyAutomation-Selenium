using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using FreeAdCopyAutomation.PageMethods;
using FreeAdCopyAutomation.PageObjects;
using Allure.NUnit;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace FreeAdCopyAutomation.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class BugReportTests
    {
        private IWebDriver _driver;
        private HomePageMethods _homePage;
        private LoginMethods _loginPage;
        private DashBoardObjects _dashboard;
        private DashboardMethods _dashboardMethods;

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
        [AllureDescription("Submit Bug Report")]
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
