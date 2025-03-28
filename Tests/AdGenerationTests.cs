using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FreeAdCopyAutomation.PageMethods;
using System.IO;

namespace FreeAdCopyAutomation.Tests
{
    class AdGenerationTests
    {
        private IWebDriver _driver;
        private LoginMethods _loginPage;
        private HomePageMethods _homePage;
        private DashboardMethods _dashboardPage;
        private AdsPageMethods _adsPage;
        private List<Dictionary<string, string>> _testData;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://freeadcopy.com/"); // Replace with your base URL
            _loginPage = new LoginMethods(_driver);
            _homePage = new HomePageMethods(_driver);
            _dashboardPage = new DashboardMethods(_driver);
            _adsPage = new AdsPageMethods(_driver);
            _testData = LoadTestData("DataFile.csv");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Test]
        public void GenerateAdWithEmailTemplate()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail("sajidfree7727@gmail.com");
            _loginPage.EnterPassword("webdir123R");
            _loginPage.SigninBtn();
            _homePage.ClickTemplateOption();

            _dashboardPage.SelectEmailCategory();
            _dashboardPage.SelectEmailSequence();
            _dashboardPage.SelectEmailTemplate();

            _adsPage.FillAdsForm("Test", "Test", "Test", "Test");

            //_adsPage.ClickGenerateAdBtn();
            //_dashboardPage.ToastNotify("Generating Ads...");
        }
        [Test]
        public void GenerateAdWithMarketResearchTemplate()
        {
            _homePage.NavigationToLogin();
            _loginPage.EnterEmail("sajidfree7727@gmail.com");
            _loginPage.EnterPassword("webdir123R");
            _loginPage.SigninBtn();
            _homePage.ClickTemplateOption();

            _dashboardPage.SelectMarketResCategory();
            _dashboardPage.SelectMarketResTemplate();

            _adsPage.FillAdsFormMarketRes("Test", "Test");

            //_adsPage.ClickGenerateAdBtn();
            //_dashboardPage.ToastNotify("Generating Ads...");
        }


        private List<Dictionary<string, string>> LoadTestData(string filePath)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (File.Exists(fullPath))
            {
                string[] lines = File.ReadAllLines(fullPath);
                if (lines.Length > 1)
                {
                    string[] headers = lines[0].Split(',');
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(',');
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int j = 0; j < headers.Length; j++)
                        {
                            row.Add(headers[j].Trim(), values[j].Trim());
                        }
                        data.Add(row);
                    }
                }
            }
            return data;
        }
    }
}
