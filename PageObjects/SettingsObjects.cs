using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace FreeAdCopyAutomation.PageObjects
{
    class SettingsObjects
    {
        private readonly IWebDriver _driver;

        public SettingsObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public By UserNameField =>By.Id("text");
        public By UpdateSettingsButton =>By.CssSelector(".text-gray-500 > .text-white > .flex");
        public By UpdateToast =>By.CssSelector(".Toastify__toast-body > :nth-child(2)");
        public By PasswordSettingTab =>By.CssSelector(".border-b > .flex > :nth-child(4)");
        public By PasswordField =>By.Id("password");
        public By NewPasswordField =>By.Id("newPassword");
        public By ConfirmPasswordField =>By.Id("confirmpassword");
        public By UpdatePasswordButton =>By.XPath("//span[.='Update Password']");
        public By LanguageDropdown =>By.CssSelector(".inline-block #menu-button");
        public By AccountSettingsText =>By.CssSelector(".space-y-6 > .text-xl");
        public ReadOnlyCollection<IWebElement> TabList => _driver.FindElements(By.CssSelector(".pb-1 p"));

        // Subscription Section
        public By UpgradePlanButton => By.XPath("//button[contains(text(),'Upgrade Plan')]");
        public ReadOnlyCollection<IWebElement> UpgradeButtonList => _driver.FindElements(By.CssSelector(".bg-gray-900"));
        public void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
