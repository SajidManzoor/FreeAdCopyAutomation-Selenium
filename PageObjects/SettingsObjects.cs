using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IWebElement UserNameField => _driver.FindElement(By.Id("text"));
        public IWebElement UpdateSettingsButton => _driver.FindElement(By.CssSelector(".text-gray-500 > .text-white > .flex"));
        public IWebElement UpdateToast => _driver.FindElement(By.CssSelector(".Toastify__toast-body > :nth-child(2)"));
        public IWebElement PasswordSettingTab => _driver.FindElement(By.CssSelector(".border-b > .flex > :nth-child(4)"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement NewPasswordField => _driver.FindElement(By.Id("newPassword"));
        public IWebElement ConfirmPasswordField => _driver.FindElement(By.Id("confirmpassword"));
        public IWebElement UpdatePasswordButton => _driver.FindElement(By.XPath("//span[.='Update Password']"));
        public IWebElement LanguageDropdown => _driver.FindElement(By.CssSelector(".inline-block #menu-button"));
        public IWebElement AccountSettingsText => _driver.FindElement(By.CssSelector(".space-y-6 > .text-xl"));
        public ReadOnlyCollection<IWebElement> TabList => _driver.FindElements(By.CssSelector(".pb-1 p"));

        // Subscription Section
        public IWebElement UpgradePlanButton => _driver.FindElement(By.XPath("//button[contains(text(),'Upgrade Plan')]"));
        public ReadOnlyCollection<IWebElement> UpgradeButtonList => _driver.FindElements(By.CssSelector(".bg-gray-900"));
        public void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
