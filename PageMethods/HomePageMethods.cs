using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using FreeAdCopyAutomation.PageObjects;

namespace FreeAdCopyAutomation.PageMethods
{
    public class HomePageMethods
    {
        private readonly IWebDriver _driver;
        private readonly HomePageObjects _elements;
        private readonly WebDriverWait _wait;
        private readonly Utilities _utils;
        public HomePageMethods(IWebDriver driver)
        {
            _driver = driver;
            _elements = new HomePageObjects(driver);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _utils = new Utilities(driver);
        }

        public void NavigationToLogin()
        {
            _utils.Click(_elements.LoginNavbar);
        }

        public void ClickTemplateOption()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_elements.TemplateOption));
            _utils.Click(_elements.TemplateOption);
            _wait.Until(ExpectedConditions.UrlContains("/templates"));
        }
    }
}
