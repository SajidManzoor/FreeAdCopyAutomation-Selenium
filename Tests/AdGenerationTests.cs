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
    [AllureNUnit]
    class AdGenerationTests
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;
        private HomePageMethods _homePage;
        private DashboardMethods _dashboardPage;
        private AdsPageMethods _adsPage;

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
            _adsPage = new AdsPageMethods(_driver);
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
        [AllureDescription("Generate Ad with Email Template")]
        [Test]
        public void GenerateAdWithEmailTemplate()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword);
            _loginPage.SigninBtn();
            _homePage.ClickTemplateOption();

            _dashboardPage.SelectEmailCategory();
            _dashboardPage.SelectEmailSequence();
            _dashboardPage.SelectEmailTemplate();

            _adsPage.FillAdsForm(Environment.TargetMarketText, Environment.PainPointText, Environment.DislikeText, Environment.UniqueSolText);

            //_adsPage.ClickGenerateAdBtn();
            //_dashboardPage.ToastNotify("Generating Ads...");
        }
        [AllureDescription("Generate Ad with Market Research Template")]
        [Test]
        public void GenerateAdWithMarketResearchTemplate()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail(Environment.ValidEmail);
            _loginPage.EnterPassword(Environment.ValidPassword);
            _loginPage.SigninBtn();
            _homePage.ClickTemplateOption();

            _dashboardPage.SelectMarketResCategory();
            _dashboardPage.SelectMarketResTemplate();

            _adsPage.FillAdsFormMarketRes(Environment.TargetMarketText, Environment.UniqueSolText);

            //_adsPage.ClickGenerateAdBtn();
            //_dashboardPage.ToastNotify("Generating Ads...");
        }
    }
}
