using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using FreeAdCopyAutomation.PageObjects;

namespace FreeAdCopyAutomation.PageMethods
{
    public class DashboardMethods
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly DashBoardObjects _dashboardElement;
        private readonly LoginObjects _loginElements;
        private readonly Utilities _utils;

        public DashboardMethods(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _dashboardElement = new DashBoardObjects(driver);
            _loginElements = new LoginObjects(driver);
            _utils = new Utilities(driver);
        }

        // Email
        public void SelectEmailCategory()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.EmailCategory));
            _utils.Click(_dashboardElement.EmailCategory);
            Assert.That(_driver.Url.Contains("/templates"), Is.True, "URL should include '/templates'");
        }

        public void SelectEmailSequence()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.EmailSequence));
            _utils.Click(_dashboardElement.EmailSequence);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("subcategory"));
            Assert.That(_driver.Url.Contains("subcategory"), Is.True, "URL should include 'subcategory'");
        }

        public void SelectEmailTemplate()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.EmailTemplate));
            _utils.Click(_dashboardElement.EmailTemplate);
        }

        // Market Research
        public void SelectMarketResCategory()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.MarketResCategory));
            _utils.Click(_dashboardElement.MarketResCategory);

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/market-research"));
            Assert.That(_driver.Url.Contains("/market-research"), Is.True, "URL should include '/market-research'");
        }

        public void SelectMarketResTemplate()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.MarketTemplate));
            _utils.Click(_dashboardElement.MarketTemplate);
        }

        public void ClickProfileIcon()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.ProfileIcon));
            Assert.That(_driver.FindElement(_dashboardElement.ProfileIcon).Displayed, Is.True, "Profile icon should be visible");

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", _driver.FindElement(_dashboardElement.ProfileIcon)); ;

        }

        public void SelectSettingsTab()
        {
            _utils.Click(_dashboardElement.SettingsTab);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("/settings"));
            Assert.That(_driver.Url.Contains("/settings"), Is.True, "URL should include '/settings'");
        }

        public void SelectReportBugTab()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.ReportBugTab));
            _utils.Click(_dashboardElement.ReportBugTab);
        }


        public void ToastNotify(string toastMessage)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_loginElements.Toast));
            Assert.That(_driver.FindElement(_loginElements.Toast).Text, Is.EqualTo(toastMessage), "Toast notification should match expected message");
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loginElements.Toast));
        }

        public void SubmitBugReport(string bugDetail)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_dashboardElement.ReportBug));
            _utils.Click(_dashboardElement.ReportBug);
            _utils.EnterText(_dashboardElement.ReportBug, bugDetail);
            _utils.Click(_dashboardElement.ReportSubmitBtn);
        }
    }
}
